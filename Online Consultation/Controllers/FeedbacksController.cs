using Microsoft.AspNetCore.Mvc;
using Online_Consultation.Models;

namespace Online_Consultation.Controllers
{
    public class FeedbacksController : Controller
    {

        public DoctorDbContext doctorDbContext;

        public FeedbacksController(DoctorDbContext doctorDbContext)
        {
            this.doctorDbContext = doctorDbContext;
        }
        public IActionResult Index()
        {
            return View(doctorDbContext.feedbacks.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Feedback fb)
        {

            doctorDbContext.Add(fb);
            doctorDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
