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

        public CaseController(CaseRepository caseRepository)
        {
            _caseRepository = caseRepository;
        }

        [HttpPost("new")]
        [Authorize]
        public async Task<int> NewCase(CmsCase cmsCase)
        {
            await _caseRepository.AddCmsCase(cmsCase);
            return cmsCase.Id;
        }
    }
}