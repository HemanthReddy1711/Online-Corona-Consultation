using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Consultation.Models
{
    public class DoctorProfile
    {
        public int id { get; set; }
        [DisplayName("Doctor Name")]

        [NotMapped]
        public IFormFile dImage { get; set; }

        public string docImageUrl { get; set; }
        public string Docname { get; set; }
        public string speciality { get; set; }
        public string Email{ get; set; }
        public int fees { get; set; }
        [DisplayName("Available Slots")]
        public string avail { get; set; }

    }


    //public class appointment
    //{

    //}

    public class Medicine
    {
        public int id { get; set; }
        public string mname { get; set; }

        public int mprice { get; set; }

        public DateTime mfg { get; set; }

        public DateTime exp { get; set; }
    }
    public class Department
    {
        public int id { get; set; }

        public string dname { get; set; }


    }
    public class Employee
    {
        public int id { get; set; }
        public string Empname { get; set; }
        [ForeignKey("department")]

        public int DepId { get; set; }
        public Department department { get; set; }
    }
    
    public class PatientProfile
    {
        public int id { get; set; }
        public string pname { get; set; }

        [NotMapped]
        public IFormFile pImage { get; set; }

        public string pImageUrl { get; set; }

        public string address { get; set; }
        public string Mobile{ get; set; }

    }
    public class Patientreport
    {
        public int id { get; set; }


        [ForeignKey("patient")]
        public int pid { get; set; }
        public PatientProfile patient { get; set; }

        [ForeignKey("doctor")]

        public int did { get; set; }
        public DoctorProfile doctor { get; set; }

        [ForeignKey("medicine")]

        public int mid { get; set; }
        public Medicine medicine { get; set; }

    }
    
    // appointment

    public class Feedback
    {
        public int id { get; set; }
        [ForeignKey("patient")]
        public int pid { get; set; }
        public PatientProfile patient{ get; set; }
        public string Description { get; set; }

        public byte rating { get; set; }
        public DateTime feedbackTime { get; set; }
    }

    public class Service
    {
        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }
    }

    public class Billing
    {
        public int id { get; set; }

        public DateTime billingdate { get; set; }
        [ForeignKey("medicine")]
        public int mid { get; set; }

        public Medicine medicine { get; set; }

        [ForeignKey("patient")]
        public int pid { get; set; }
        public PatientProfile patient { get; set; }

        [ForeignKey("doctor")]

        public int did { get; set; }
        public DoctorProfile doctor { get; set; }

        public int totalFee { get; set; }

    }
    
}
