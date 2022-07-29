using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Consultation.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Online_Consultation.Controllers
{
    public class PatientsController : Controller
    {
        public DoctorDbContext doctorDbContext;
        public IHostingEnvironment _env;

        public PatientsController(DoctorDbContext doctorDbContext, IHostingEnvironment env)
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
        public IActionResult Create(PatientProfile patientProfile)
        {
            var nam = Path.Combine(_env.WebRootPath + "/Images", Path.GetFileName(patientProfile.pImage.FileName));
            patientProfile.pImage.CopyTo(new FileStream(nam, FileMode.Create));
            patientProfile.pImageUrl = "Images/" + patientProfile.pImage.FileName;
            doctorDbContext.Add(patientProfile);
            doctorDbContext.SaveChanges();
            return RedirectToAction(nameof(PatientProfile));
        }
        public IActionResult Edit(int? id)
        {
            var patients = doctorDbContext.patientProfiles.FirstOrDefault(e => e.id == id);
            return View(patients);
        }
        [HttpPost]
        public IActionResult Edit(PatientProfile patientProfile)
        {
            if (patientProfile.pImage != null)
            {
                var nam = Path.Combine(_env.WebRootPath + "/Images", Path.GetFileName(patientProfile.pImage.FileName));
                patientProfile.pImage.CopyTo(new FileStream(nam, FileMode.Create));
                patientProfile.pImageUrl = "Images/" + patientProfile.pImage.FileName;
            }
            doctorDbContext.Update(patientProfile);
            doctorDbContext.SaveChanges();
            return RedirectToAction(nameof(patientProfile));
        }
        public IActionResult Delete(int? id)
        {
            return View(doctorDbContext.patientProfiles.FirstOrDefault(e => e.id == id));
        }
        [HttpPost]
        public IActionResult Delete(PatientProfile patientProfile)
        {
            doctorDbContext.Remove(patientProfile);
            doctorDbContext.SaveChanges();
            return RedirectToAction(nameof(patientProfile));
        }
        public IActionResult Details(int? id)
        {
            return View(doctorDbContext.patientProfiles.FirstOrDefault(e => e.id == id));
        }
        public IActionResult PatientProfile()
        {
            return View(doctorDbContext.patientProfiles.ToList());
        }
        public IActionResult Profile()
        {
            string us = HttpContext.User.Identity.Name.ToString();
            PatientProfile v = doctorDbContext.patientProfiles.FirstOrDefault(p => p.Email == us);
            if (v == null)
            {
                v = new PatientProfile();
                v.Email = us;
                return View(v);
            }
            v.Email = us;
            return View(v);
        }
        [HttpPost]
        public IActionResult Profile(PatientProfile v)
        {
            v.pImageUrl = "Images/doc1.jpg";

            return RedirectToAction(nameof(Profile));
        }
    }
}

