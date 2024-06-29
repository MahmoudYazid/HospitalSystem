using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HospitalSystem.Models.databaseModels
{
    public class ClinicModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string speciality{ get; set; }

    }
}
