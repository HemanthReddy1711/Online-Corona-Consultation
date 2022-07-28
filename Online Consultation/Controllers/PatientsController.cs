using Microsoft.AspNetCore.Mvc;
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
            var patients=doctorDbContext.patientProfiles.FirstOrDefault(e=>e.id==id);
            return View(patients);
        }
        [HttpPost]
        public IActionResult Edit(PatientProfile patientProfile)
        {
            if(patientProfile.pImage!=null)
            {
                var nam = Path.Combine(_env.WebRootPath + "/Images", Path.GetFileName(patientProfile.pImage.FileName));
                patientProfile.pImage.CopyTo(new FileStream(nam, FileMode.Create));
                patientProfile.pImageUrl = "Images/" + patientProfile.pImage.FileName;
            }
            doctorDbContext.Update(patientProfile);
            doctorDbContext.SaveChanges();
            return RedirectToAction(nameof(patientProfile));
        }
        public IActionResult PatientProfile()
        {
            return View(doctorDbContext.patientProfiles.ToList());
        }
    }
}
