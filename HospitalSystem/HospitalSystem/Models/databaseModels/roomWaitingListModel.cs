using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HospitalSystem.Models.databaseModels
{
    public class roomWaitingListModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime time { get; set; }

        [ForeignKey("patientModel")]
        public int PatientId { get; set; }
        public patientModel patientModel { get; set; }
    }
}
