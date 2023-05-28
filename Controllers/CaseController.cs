using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CaseManagementAPI.Models;
using CaseManagementAPI.Repository;
using CaseManagementApp.Models.ControlItems;
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
            var manger = await _userRepository.GetCmsUserByNameAsync(cmsCase.Manger.Name);
            cmsCase.Manger = manger;
            await _caseRepository.AddCmsCase(cmsCase);
            return cmsCase.Id;
        }

        [HttpGet("{caseId}")]
        public async Task<CmsCase?> GetCaseByIdAsync(int caseId)
        {
            var @case = await _caseRepository.GetCmsCaseAsync(caseId);
            return @case;
        }

        [HttpPost("health/{caseId}/{managerId}")]
        public async Task AddHealthHistory(int caseId, int managerId, HealthHistory healthHistory)
        {
            var manager = await _userRepository.GetCmsUserAsync(managerId);
            healthHistory.Manager = manager;
            var @case = await _caseRepository.GetCmsCaseAsync(caseId);
            await _caseRepository.AddHealthHistoryAsync(@case, healthHistory);
        }

        [HttpPost("eyetest/{caseId}")]
        public async Task AddEyeTest(int caseId, EyeTest eyeTest)
        {
            var @case = await _caseRepository.GetCmsCaseAsync(caseId);
            await _caseRepository.AddEyeTest(@case, eyeTest);
        }

        [HttpPost("foottest/{caseId}")]
        public async Task AddFootTest(int caseId, FootTest footTest)
        {
            var @case = await _caseRepository.GetCmsCaseAsync(caseId);
            await _caseRepository.AddFoodTest(@case, footTest);
        }

        [HttpPost("urinetest/{caseId}")]
        public async Task AddUrineTest(int caseId, UrineTest urineTest)
        {
            var @case = await _caseRepository.GetCmsCaseAsync(caseId);
            await _caseRepository.AddUrineTest(@case, urineTest);
        }

        [HttpPost("bloodtest/{caseId}")]
        public async Task AddBloodTest(int caseId, BloodTest bloodTest)
        {
            var @case = await _caseRepository.GetCmsCaseAsync(caseId);
            await _caseRepository.AddBloodTest(@case, bloodTest);
        }

        [HttpPost("bloodPressure/{caseId}")]
        public async Task AddBloodPressure(int caseId, BloodPressureTest bloodPressureTest)
        {
            var @case = await _caseRepository.GetCmsCaseAsync(caseId);
            await _caseRepository.AddBloodPressure(@case, bloodPressureTest);
        }

        [HttpPost("patientSelf/{caseId}")]
        public async Task AddPatientSelf(int caseId, PatientSelfHistory patientSelfHistory)
        {
            var @case = await _caseRepository.GetCmsCaseAsync(caseId);
            await _caseRepository.AddPatientSelfHistory(@case, patientSelfHistory);
        }

        [HttpPost("query")]
        public async Task<List<CmsCase>> QueryCase(QueryPayload queryPayload)
        {
            List<Expression<Func<CmsCase, bool>>> conditions = new List<Expression<Func<CmsCase, bool>>>();
            if (queryPayload.CaseId != null)
                conditions.Add(x => x.Id == queryPayload.CaseId);
            if (queryPayload.PatientName != null)
                conditions.Add(x => x.PatientName == queryPayload.PatientName);
            if (queryPayload.CustomerId != null)
                conditions.Add(x => x.CustomerId == queryPayload.CustomerId);
            if (queryPayload.TestDate != null)
            {
                conditions.Add((x) => 
                    x.EyeTests.Any(t => t.TestDate.Date == queryPayload.TestDate) ||
                    x.FootTests.Any(t => t.TestDate.Date == queryPayload.TestDate) ||
                    x.BloodTests.Any(t => t.TestDate.Date == queryPayload.TestDate) ||
                    x.UrineTests.Any(t => t.TestDate.Date == queryPayload.TestDate) ||
                    x.BloodPressureTests.Any(t => t.TestDate.Date == queryPayload.TestDate) ||
                    x.PatientSelfHistories.Any(p => p.FootTest.TestDate.Date == queryPayload.TestDate) ||
                    x.PatientSelfHistories.Any(p => p.BloodTest.TestDate.Date == queryPayload.TestDate) ||
                    x.PatientSelfHistories.Any(p => p.BloodPressureTest.TestDate.Date == queryPayload.TestDate) ||
                    x.HealthHistories.Any(h => h.TraceDate.Date == queryPayload.TestDate)
                );
            }

            var res = await _caseRepository.GetCasesByConditions(conditions);
            return res;
        }

        [HttpGet("patientCase/{patientId}")]
        public async Task<CmsCase> GetCmsCaseByPatientIdAsync(int patientId)
        {
            return await _caseRepository.GetCaseByPatientId(patientId);
        }
    }
}