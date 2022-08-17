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
        public void Index(int? id,int? id2)
        {
            Feedback feedback = doctorDbContext.feedbacks.Where(e => e.pid == id2).FirstOrDefault(e => e.did == id);
            if(feedback == null)
            {
                RedirectToAction(nameof(Create));
            }
        }
        public IActionResult Create(int? id,int? id2)
        {
            Feedback feedback = doctorDbContext.feedbacks.Where(e => e.pid == id2).FirstOrDefault(e => e.did == id);
            if (feedback == null)
            {
                Feedback f = new Feedback();
                f.pid = Convert.ToInt32(id2);
                f.did = Convert.ToInt32(id);
                return View(f);
            }
            else
            {
                return View(feedback);
            }
        }
        [HttpPost]
        public void Create(Feedback f)
        {
            Feedback fed = new Feedback();
            fed.pid=f.pid;
            fed.did = f.did;
            fed.description = f.description;
            fed.rating = f.rating;
            fed.feedbackTime = DateTime.Now;
            doctorDbContext.feedbacks.Add(fed);
            doctorDbContext.SaveChanges();

        }
    }
}
