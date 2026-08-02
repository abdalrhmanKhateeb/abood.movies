using Abood.Movies.Customers;
using Abood.Movies.Directors;
using Abood.Movies.Movies;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Abood.Movies.Rentals;
namespace Abood.Movies.EntityFrameworkCore;


[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class MoviesDbContext :
    AbpDbContext<MoviesDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    public DbSet<Director> Directors { get; set; }
    public DbSet<Movie> Movies { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Rental> Rentals { get; set; }

    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }
    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public MoviesDbContext(DbContextOptions<MoviesDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();
        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(MoviesConsts.DbTablePrefix + "YourEntities", MoviesConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
        builder.Entity<Movie>(b =>
        {
            b.ToTable(MoviesConsts.DbTablePrefix + "Movies",
                MoviesConsts.DbSchema);

            b.ConfigureByConvention();

            b.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(128);

            b.HasOne(x => x.Director)
                .WithMany()
                .HasForeignKey(x => x.DirectorId)
                .IsRequired();
        });

        builder.Entity<Director>(b =>
        {
            b.ToTable(MoviesConsts.DbTablePrefix + "Directors",
                MoviesConsts.DbSchema);

            b.ConfigureByConvention();

            b.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(128);
        });
        builder.Entity<Customer>(b =>
        {
            b.ToTable(MoviesConsts.DbTablePrefix + "Customers",
                MoviesConsts.DbSchema);

            b.ConfigureByConvention();

            b.Property(x => x.FullName)
                .IsRequired()
                .HasMaxLength(128);

            b.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(256);

            b.Property(x => x.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);
        });
        builder.Entity<Rental>(b =>
        {
            b.ToTable(MoviesConsts.DbTablePrefix + "Rentals",
                MoviesConsts.DbSchema);

            b.ConfigureByConvention();
            b.HasOne(x => x.Customer)
                .WithMany()
                .HasForeignKey(x => x.CustomerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            b.HasOne(x => x.Movie)
                .WithMany()
                .HasForeignKey(x => x.MovieId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
   
    