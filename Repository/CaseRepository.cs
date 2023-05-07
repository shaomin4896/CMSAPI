using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseManagementAPI.Models;

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
    }
}