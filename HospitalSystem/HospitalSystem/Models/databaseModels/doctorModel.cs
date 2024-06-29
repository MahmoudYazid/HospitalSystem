using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalSystem.Models.databaseModels
{
    public class doctorModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string speciality { get; set; }
        [Required]
        public string name{ get; set; }
        [ForeignKey("clinicModel")]
        [Required]
        public int clinicID { get; set; }

        public ClinicModel clinicModel { get; set; }

    }
}
