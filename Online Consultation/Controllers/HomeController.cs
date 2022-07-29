using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Online_Consultation.Models;
using System.Diagnostics;
using System.Dynamic;

namespace Online_Consultation.Controllers
{
    public class HomeController : Controller
    {
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
            return View(_doctorDbContext.doctorsProfiles.FirstOrDefault(c => c.id == id));
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