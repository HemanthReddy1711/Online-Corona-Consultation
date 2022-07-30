using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Online_Consultation.Models;
using System.Diagnostics;
using System.Dynamic;
using Stripe.Infrastructure;
using Razorpay.Api;

namespace Online_Consultation.Controllers
{
    public class HomeController : Controller
    {
        public const string raz_key = "rzp_test_cfElqRcKNLh6aA";
        public const string raz_secret = "3QaoZiwflNJbQftFonT55elT";
        private readonly ILogger<HomeController> _logger;
        public DoctorDbContext _doctorDbContext;
        public HomeController(ILogger<HomeController> logger, DoctorDbContext doctorDbContext)
        {
            _logger = logger;
            _doctorDbContext = doctorDbContext;
        }

        public IActionResult Index()
        {
            //var user = UserManager.FindByEmail(Email);
            return View();
        }

        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult getAppointment(int? id) 
        {
            //DoctorProfile dc = _doctorDbContext.doctorsProfiles.FirstOrDefault(c => c.id == id);
            //string us = HttpContext.User.Identity.Name.ToString();
            //PatientProfile p = _doctorDbContext.patientProfiles.FirstOrDefault(p => p.Email == us);
            //dynamic obj = new ExpandoObject();
            //obj.Patient = p;
            //obj.Doctor = dc;
            return View(_doctorDbContext.doctorsProfiles.FirstOrDefault(c => c.id == id));
        }
        public IActionResult ConfirmAppointment(int? id)
        {
            DoctorProfile dc = _doctorDbContext.doctorsProfiles.FirstOrDefault(c => c.id == id);
            string us = HttpContext.User.Identity.Name.ToString();
            PatientProfile p = _doctorDbContext.patientProfiles.FirstOrDefault(p => p.Email == us);

            //Create Card Object to create Token

            //Assign Card to Token Object and create Token  

            var oid = Createorder(dc);
            PayOptions pay = new PayOptions()
            {
                key = raz_key,
                Amountinsub = dc.fees * 100,
                currency = "INR",
                name = "Global Logic Health+",
                Description = "A Good",
                ImageUrl = "",
                Orderid = oid,
                productid = dc.id

            };
            return View(pay);
        }

        public IActionResult Success(PayOptions pay)
        {
            Appointment b = new Appointment();
            var products = _doctorDbContext.doctorsProfiles.FirstOrDefault(p => p.id == pay.productid);
            string us = HttpContext.User.Identity.Name.ToString();
            PatientProfile p = _doctorDbContext.patientProfiles.FirstOrDefault(p => p.Email == us);
            b.pid = p.id;
            b.did = products.id;
            b.Date = DateTime.UtcNow;
            return View();
        }

        public String Createorder(DoctorProfile products)
        {
            try
            {
                RazorpayClient client = new RazorpayClient(raz_key, raz_secret);
                Dictionary<string, object> input = new Dictionary<string, object>();
                input.Add("amount", products.fees * 100);
                input.Add("currency", "INR");
                input.Add("receipt", "12121");

                Order ord_Res = client.Order.Create(input);
                var oid = ord_Res.Attributes["id"].ToString();
                return oid;

            }
            catch
            {
                return null;
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}