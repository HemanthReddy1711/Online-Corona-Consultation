using Microsoft.AspNetCore.Mvc;
using Online_Consultation.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;


namespace Online_Consultation.Controllers
{
    public class MedicinesController : Controller
    {
        public DoctorDbContext doctorDbContext;
        public IHostingEnvironment _env;

        public MedicinesController(DoctorDbContext doctorDbContext, IHostingEnvironment env)
        {
            this.doctorDbContext = doctorDbContext;
            this._env = env;
        }


        public IActionResult Index()
        {
            return View(doctorDbContext.medicines.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Medicine med)
        {

            doctorDbContext.Add(med);
            doctorDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            var med = doctorDbContext.medicines.FirstOrDefault(e => e.id == id);
            return View(med);
        }

        [HttpPost]
        public IActionResult Edit(Medicine med)
        {
           
            doctorDbContext.Update(med);
            doctorDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int? id)
        {
            return View(doctorDbContext.medicines.FirstOrDefault(e => e.id == id));
        }


        public IActionResult Delete(int? id)
        {
            return View(doctorDbContext.medicines.FirstOrDefault(e => e.id == id));
        }
        [HttpPost]
        public IActionResult Delete(Medicine med)
        {
            doctorDbContext.Remove(med);
            doctorDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}








