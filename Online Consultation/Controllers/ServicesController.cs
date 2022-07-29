using Microsoft.AspNetCore.Mvc;
using Online_Consultation.Models;

namespace Online_Consultation.Controllers
{
    public class ServicesController : Controller
    {
        public DoctorDbContext doctorDbContext;
      

        public ServicesController(DoctorDbContext doctorDbContext)
        {
            this.doctorDbContext = doctorDbContext;
            
        }
        public IActionResult Index()
        {
            return View(doctorDbContext.services.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Service service)
        {
           
            doctorDbContext.Add(service);
            doctorDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? id)
        {
            var doctors = doctorDbContext.services.FirstOrDefault(e => e.id == id);
            return View(doctors);
        }

        [HttpPost]
        public IActionResult Edit(Service service)
        {
            doctorDbContext.Update(service);
            doctorDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int? id)
        {
            return View(doctorDbContext.services.FirstOrDefault(e => e.id == id));
        }
        public IActionResult Delete(int? id)
        {
            return View(doctorDbContext.services.FirstOrDefault(e => e.id == id));
        }
        [HttpPost]
        public IActionResult Delete(Service service)
        {
            doctorDbContext.Remove(service);
            doctorDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
