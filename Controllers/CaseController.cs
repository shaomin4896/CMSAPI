using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseManagementAPI.Models;
using CaseManagementAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CaseController : ControllerBase
    {
        private readonly CaseRepository _caseRepository;
        private readonly UserRepository _userRepository;

        public CaseController(CaseRepository caseRepository, UserRepository userRepository)
        {
            _caseRepository = caseRepository;
            _userRepository = userRepository;
        }

        [HttpPost("new")]
        public async Task<int> NewCase(CmsCase cmsCase)
        {
            await _caseRepository.AddCmsCase(cmsCase);
            return cmsCase.Id;
        }

        [HttpPost("health")]
        public async Task AddHealthHistory(int caseId , int managerId, HealthHistory healthHistory)
        {
            var manager = await _userRepository.GetCmsUserAsync(managerId);
            healthHistory.Manager = manager;
            var @case = await _caseRepository.GetCmsCaseAsync(caseId);
            await _caseRepository.AddHealthHistoryAsync(@case, healthHistory);
        }
    }
}