using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CaseManagementAPI.Repository
{
    public class CaseRepository
    {
        private readonly CMSContext _appContext;

        public CaseRepository(CMSContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<int> AddCmsCase(CmsCase cmsCase)
        {
            _appContext.Case.Add(cmsCase);
            await _appContext.SaveChangesAsync();
            return cmsCase.Id;
        }

        public async Task<CmsCase?> GetCmsCaseAsync(int id)
        {
            return await _appContext.Case
            .Include(x => x.HealthHistories)
            .Include(x => x.EyeTests)
            .Include(x => x.FootTests)
            .Include(x => x.BloodTests)
            .Include(x => x.UrineTests)
            .Include(x => x.BloodPressureTests)
            .Include(x => x.PatientSelfHistories)
                .ThenInclude(x => x.BloodPressureTest)
            .Include(x => x.PatientSelfHistories)
                .ThenInclude(x => x.FootTest)
            .Include(x => x.PatientSelfHistories)
                .ThenInclude(x => x.BloodTest)
            .Include(x => x.Manger)
            .Include(x => x.Patient)
            .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddHealthHistoryAsync(CmsCase cmsCase, HealthHistory healthHistory)
        {
            cmsCase.HealthHistories.Add(healthHistory);
            await _appContext.SaveChangesAsync();
        }

        public async Task AddEyeTest(CmsCase cmsCase, EyeTest eyeTest)
        {
            cmsCase.EyeTests.Add(eyeTest);
            await _appContext.SaveChangesAsync();
        }

        public async Task AddFoodTest(CmsCase cmsCase, FootTest footTest)
        {
            cmsCase.FootTests.Add(footTest);
            await _appContext.SaveChangesAsync();
        }

        public async Task AddUrineTest(CmsCase cmsCase, UrineTest urineTest)
        {
            cmsCase.UrineTests.Add(urineTest);
            await _appContext.SaveChangesAsync();
        }

        public async Task AddBloodTest(CmsCase cmsCase, BloodTest bloodTest)
        {
            cmsCase.BloodTests.Add(bloodTest);
            await _appContext.SaveChangesAsync();
        }

        public async Task AddBloodPressure(CmsCase cmsCase , BloodPressureTest bloodPressureTest)
        {
            cmsCase.BloodPressureTests.Add(bloodPressureTest);
            await _appContext.SaveChangesAsync();
        }

        public async Task AddPatientSelfHistory(CmsCase cmsCase , PatientSelfHistory patientSelfHistory)
        {
            cmsCase.PatientSelfHistories.Add(patientSelfHistory);
            await _appContext.SaveChangesAsync();
        }
    }
}