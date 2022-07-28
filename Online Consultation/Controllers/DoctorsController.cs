using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Consultation.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Online_Consultation.Controllers
{
    public class DoctorsController : Controller
    {

        public DoctorDbContext doctorDbContext;
        public IHostingEnvironment _env;

        public DoctorsController(DoctorDbContext doctorDbContext, IHostingEnvironment env)
        {
            this.doctorDbContext = doctorDbContext;
            this._env = env;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DoctorProfile doctorProfile)
        {
            var nam = Path.Combine(_env.WebRootPath + "/Images", Path.GetFileName(doctorProfile.dImage.FileName));
            doctorProfile.dImage.CopyTo(new FileStream(nam, FileMode.Create));
            doctorProfile.docImageUrl = "Images/" + doctorProfile.dImage.FileName;
            doctorDbContext.Add(doctorProfile);
            doctorDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DoctorProfile()
        {
            return View(doctorDbContext.doctorsProfiles.ToList());
        }
    }
}
