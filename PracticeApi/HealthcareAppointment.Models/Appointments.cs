using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PraticeWebApi1.Models
{
    public class Appointments
    {
        [Key]
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }

        [ForeignKey("PatientId")]
        public Users Patient { get; set; }
        public Guid DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Users Doctor { get; set; }
        public DateTime Date { get; set; }
        public EnumStatus Status { get; set; }
        
    }
}
