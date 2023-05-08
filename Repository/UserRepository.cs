using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CaseManagementAPI.Repository
{
    public class UserRepository
    {
        private readonly CMSContext _appContext;

        public UserRepository(CMSContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<CmsUser?> GetUserByAccAndPwdAsync(string acc, string pwd)
        {
            return await _appContext.CmsUser
            .Where(x => x.Account == acc && x.Password == pwd)
            .FirstOrDefaultAsync();
        }

        public async Task<CmsUser?> CreateUserAsync(CmsUser user)
        {  
            _appContext.CmsUser.Add(user);
            await _appContext.SaveChangesAsync();
            return user;
        }

        public async Task<CmsUser?> GetCmsUserAsync(int id)
        {
            return await _appContext.CmsUser.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}