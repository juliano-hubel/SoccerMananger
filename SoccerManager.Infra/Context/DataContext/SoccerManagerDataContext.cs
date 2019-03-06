using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using SoccerManager.Domain.Entities;
using SoccerManager.Infra.Mappigns;
using SoccerManager.Shared;

namespace SoccerManager.Infra.Context.DataContext
{
    public class SoccerManagerDataContext : DbContext
    {

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Administrator> Administrators{ get; set; }
        public DbSet<BankAccount> BankAccounts{ get; set; }
        public DbSet<Classroom> Classrooms{ get; set; }
        public DbSet<ClassroomHistory> ClassroomHistories{ get; set; }        
        public DbSet<Health> Healths{ get; set; }
        public DbSet<Match> Matches{ get; set; }        
        public DbSet<Player> Players{ get; set; }
        public DbSet<Student> Students{ get; set; }
        public DbSet<StudentCategory> StudentCategories{ get; set; }
        public DbSet<Teacher> Teachers{ get; set; }
        public DbSet<Team> Teams{ get; set; }
        public DbSet<StudentsClassrooms> StudentsClassrooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Settings.ConnectionString);            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.ApplyConfiguration(new AddressMap());
            modelBuilder.ApplyConfiguration(new AdministratorMap());
            modelBuilder.ApplyConfiguration(new BankAccountMap());
            modelBuilder.ApplyConfiguration(new StudentMap());
            modelBuilder.ApplyConfiguration(new TeacherMap());
            modelBuilder.ApplyConfiguration(new ClassroomHistoryMap());
            modelBuilder.ApplyConfiguration(new ClassroomMap());
            modelBuilder.ApplyConfiguration(new HealthMap());
            modelBuilder.ApplyConfiguration(new MatchMap());
            modelBuilder.ApplyConfiguration(new PlayerMap());
            modelBuilder.ApplyConfiguration(new StudentCategoryMap());
            modelBuilder.ApplyConfiguration(new TeamMap());
            modelBuilder.ApplyConfiguration(new CardMap());
            modelBuilder.ApplyConfiguration(new FaultMap());
            modelBuilder.ApplyConfiguration(new GoalMap());
            modelBuilder.ApplyConfiguration(new StudentsClassroomsMap());
        }


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Configurations.Add(new AddressMap());
        //    modelBuilder.Configurations.Add(new AdministratorMap());
        //    modelBuilder.Configurations.Add(new BankAccountMap());
        //    modelBuilder.Configurations.Add(new ClassroomHistoryMap());
        //    modelBuilder.Configurations.Add(new ClassroomMap());
        //    modelBuilder.Configurations.Add(new HealthMap());
        //    modelBuilder.Configurations.Add(new MatchMap());
        //    modelBuilder.Configurations.Add(new PlayerMap());
        //    modelBuilder.Configurations.Add(new StudentCategoryMap());
        //    modelBuilder.Configurations.Add(new StudentMap());
        //    modelBuilder.Configurations.Add(new TeacherMap());
        //    modelBuilder.Configurations.Add(new TeamMap());
        //}
    }
}
