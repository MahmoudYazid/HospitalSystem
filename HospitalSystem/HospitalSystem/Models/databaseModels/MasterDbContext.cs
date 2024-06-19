using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
namespace HospitalSystem.Models.databaseModels
{
    public class MasterDbContext:Microsoft.EntityFrameworkCore.DbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<appointmentModel> appointmentDb {  get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<ClinicModel> clinicDb { get; set;}
        public Microsoft.EntityFrameworkCore.DbSet<doctorModel> doctorDb { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<patientModel> patientDb { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<recipe> recipesDb { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<reportsModel> reportsDb { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<roomModel> roomDb { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<roomWaitingListModel> roomWaitingListDb { get; set; }

        public MasterDbContext(DbContextOptions<MasterDbContext> options) : base(options) { 
        
        
        }
    }
}
