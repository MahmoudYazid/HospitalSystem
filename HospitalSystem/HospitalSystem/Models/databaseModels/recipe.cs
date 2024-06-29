using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HospitalSystem.Models.databaseModels
{
    public class recipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        [ForeignKey("doctorModel")]
        [Required]
        public int DoctorId { get; set; }
        [ForeignKey("patientModel")]
        [Required]
        public int PatientId { get; set; }
        [Required]
        public DateTime time { get; set; }
        [Required]

        public String drugs { get; set; }

        public doctorModel doctorModel { get; set; }
        public patientModel patientModel { get; set; }
    }
}
