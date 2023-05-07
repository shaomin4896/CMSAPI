using System.Collections.Generic;
using CaseManagementAPI.Models;
using Microsoft.EntityFrameworkCore;


public class CMSContext : DbContext
{
    public CMSContext(DbContextOptions<CMSContext> options) : base(options)
    {
    }

    public DbSet<CmsUser> CmsUser { get; set; }
    public DbSet<CmsCase> Case { get; set; }
    public DbSet<BloodTest> BloodTest { get; set; }
    public DbSet<EyeTest> EyeTest { get; set; }
    public DbSet<FootTest> FootTest { get; set; }
    public DbSet<UrineTest> UrineTest { get; set; }
}

