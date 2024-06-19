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
        public int DoctorId { get; set; }
        [ForeignKey("patientModel")]
        public int PatientId { get; set; }
        public DateTime time { get; set; }

        public IEnumerable<string> drugs { get; set; }
        public doctorModel doctorModel { get; set; }
        public patientModel patientModel { get; set; }
    }
}
