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
    
    public class Patient
    {
        public int id { get; set; }
        public string Pname { get; set; }
        public string address { get; set; }
        public string Mobile{ get; set; }

    }
    public class Patientreport
    {
        public int id { get; set; }


        [ForeignKey("patient")]
        public int pid { get; set; }
        public Patient patient { get; set; }

        [ForeignKey("doctor")]

        public int did { get; set; }
        public Doctor doctor { get; set; }

        [ForeignKey("medicine")]

        public int mid { get; set; }
        public Medicine medicine { get; set; }

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
