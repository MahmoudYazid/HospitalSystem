using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalSystem.Models.databaseModels
{
    public class appointmentModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("doctorModel")]
        public int DoctorId { get; set; }
        [ForeignKey("patientModel")]
        public int PatientId { get; set; }
        public string status { get; set; }

        public DateTime time { get; set; }

        public doctorModel doctorModel { get; set; }
        public patientModel patientModel { get; set; }

    }
}
