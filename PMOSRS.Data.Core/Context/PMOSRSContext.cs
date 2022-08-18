using Microsoft.EntityFrameworkCore;
using PMOSRS.Model.Enums;
using PMOSRS.Model.Models.Base;
using PMOSRS.Model.Models.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PMOSRS.Model.Models.Context
{
    public class PMOSRSContext : DbContext
    {
        public PMOSRSContext()
        {

        }
        public PMOSRSContext(DbContextOptions<PMOSRSContext> dbContextOptions): base(dbContextOptions)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conString= "Server=DESKTOP-TNT1E26\\SQLEXPRESS;Database=PMOSRSDb;Trusted_Connection=True";
            optionsBuilder.UseSqlServer(conString);

        }

        public DbSet<t_Files> t_Files { get; set; }
        public DbSet<t_Projects> t_Projects { get; set; }
        public DbSet<t_ProjectUserMaps> t_ProjectUserMaps { get; set; }
        public DbSet<t_Roles> t_Roles { get; set; }
        public DbSet<t_RoleUserMaps> t_RoleUserMaps { get; set; }
        public DbSet<t_Settings> t_Settings { get; set; }
        public DbSet<t_SRSs> t_SRSs { get; set; }
        public DbSet<t_SRSStates> t_SRSStates { get; set; }
        public DbSet<t_TIDs> t_TIDs { get; set; }
        public DbSet<t_TIDStates> t_TIDStates { get; set; }
        public DbSet<t_TSs> t_TSs { get; set; }
        public DbSet<t_Users> t_Users { get; set; }
        public DbSet<t_IsDeletedEnums> t_IsDeletedEnums { get; set; }
        public DbSet<t_Authorities> t_Authorities { get; set; }
        public DbSet<t_AuthorityRoleMaps> t_AuthorityRoleMaps { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();



            foreach (var item in datas)
            {
                var result = item.State;


                switch (result)
                {
                    case EntityState.Added:
                        {
                            item.Entity.Id = Guid.NewGuid();
                            item.Entity.CreateDate = DateTime.Now;
                            item.Entity.IsDeleted = (int)IsDeletedEnum.NotDeleted;
                            break;
                        }
                    case EntityState.Modified:
                        {
                            item.Entity.UpdateDate = DateTime.Now;
                            break;
                        }
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
