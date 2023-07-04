using blood_bank.Models;
using Microsoft.EntityFrameworkCore;

namespace blood_bank.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Userprofile> Userprofiles { get; set; }

        public DbSet<AdminHomeData> AdminHomeDatas { get; set; }

        public DbSet<UserNotification> UserNotifications { get; set; }
        public DbSet<EventData> EventDatas { get; set; }

        public DbSet<HospitalData> HospitalDatas { get; set; }

        public DbSet<EventDesc> EventDescs { get; set; }

        public DbSet<HospitalDesc> HospitalDescs { get; set; }

        public DbSet<VolunteerData> VolunteerDatas { get; set; }

        public DbSet<ReportData> ReportDatas { get; set; }

        public DbSet<BloodStory> BloodStories { get; set; }

        public DbSet<Transaction> Transactions { get; set; }
    }
}