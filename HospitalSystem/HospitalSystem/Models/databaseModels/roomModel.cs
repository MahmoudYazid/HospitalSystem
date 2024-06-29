using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalSystem.Models.databaseModels
{
    public class roomModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        [Required]
        public string statement { get; set; }
        [Required]
        public string type { get; set; }
        [ForeignKey("patientModel")]
        [Required]
        public int? PatientId { get; set; } = null; 
        public patientModel patientModel { get; set; }
    }
}
