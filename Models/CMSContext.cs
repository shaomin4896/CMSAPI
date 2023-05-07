using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


public class CMSContext : DbContext
{
    public CMSContext(DbContextOptions<CMSContext> options) : base(options)
    {
    }

    public DbSet<CmsUser> CmsUser { get; set; }
}

public class CmsUser
{
    public int Id { get; set; }
    public string Account { get; set; }
    public string Password { get; set; }
    public RoleType RoleType { get; set; }
}