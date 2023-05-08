using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CaseManagementAPI.Models;

namespace CaseManagementAPI.Extensions
{
    public static class ClaimHelper
    {
        public static CmsUser? Get(this ClaimsPrincipal user)
        {
            return user.Identity?.Name?.JsonDeserialize<CmsUser>();
        }
    }
}