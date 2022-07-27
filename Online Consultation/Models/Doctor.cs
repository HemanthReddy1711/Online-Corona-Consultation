using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Consultation.Models
{
    public class Doctor
    {
        public int id { get; set; }
        [DisplayName("Doctor Name")]

        public string Docname { get; set; }
        public string speciality { get; set; }
        public string Email{ get; set; }
        public int fees { get; set; }
    }
    public class Patient
    {
        public int id { get; set; }
    }

    public class Feedback
    {
        public int id { get; set; }
        [ForeignKey("patient")]
        public int pid { get; set; }
        public Patient patient{ get; set; }
        public string Description { get; set; }
    }
    
}
