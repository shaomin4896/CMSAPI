using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseManagementAPI.Models;
using CaseManagementAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("login")]
        public async Task<string?> LoginByAccountAndPassword(string account, string password)
        {
            CmsUser? cmsUser = await _userRepository.GetUserByAccAndPwdAsync(account, password);
            if (cmsUser == null) return null;
            return cmsUser.Name;           
        }

        [HttpPost("register")]
        public async Task<int> Register(CmsUser cmsUser)
        {
            await _userRepository.CreateUserAsync(cmsUser);
            return cmsUser.Id;
        }
    }
}