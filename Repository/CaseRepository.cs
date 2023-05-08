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
            .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddHealthHistoryAsync(CmsCase cmsCase, HealthHistory healthHistory)
        {
            cmsCase.HealthHistories.Add(healthHistory);
            await _appContext.SaveChangesAsync();
        }
    }
}