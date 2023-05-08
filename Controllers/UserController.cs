using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseManagementAPI.Models;
using CaseManagementAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CaseManagementAPI.Extensions;

namespace CaseManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        private readonly JwtHelpers _jwtHelpers;

        public UserController(UserRepository userRepository, JwtHelpers jwtHelpers)
        {
            _userRepository = userRepository;
            _jwtHelpers = jwtHelpers;
        }

        [HttpPost("login")]
        public async Task<string?> LoginByAccountAndPassword(string account, string password)
        {
            CmsUser? cmsUser = await _userRepository.GetUserByAccAndPwdAsync(account, password);
            if (cmsUser == null) return null;
            return _jwtHelpers.GenerateToken(cmsUser);
        }

        [HttpPost("register")]
        public async Task<int> Register(CmsUser cmsUser)
        {
            await _userRepository.CreateUserAsync(cmsUser);
            return cmsUser.Id;
        }

        [HttpGet("current")]
        [Authorize]
        public CmsUser? GetCurrentUser()
        {
            return User.Get();
        }

        [HttpGet("get")]
        public async Task<CmsUser?> GetUserById(int id)
        {
            return await _userRepository.GetCmsUserAsync(id);
        }
    }
}