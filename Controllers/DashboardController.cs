using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMCSWebApp.Controllers
{
    [Authorize] 
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            if (User.IsInRole("Lecturer"))
            {
                return View("LecturerDashboard");
            }
            if (User.IsInRole("Coordinator"))
            {
                return View("CoordinatorDashboard");
            }
            if (User.IsInRole("Manager"))
            {
                return View("ManagerDashboard");
            }
            if (User.IsInRole("HR"))
            {
                return View("HRDashboard");
            }

            // If a user doesn't have a specific role, redirect to a default unauthorized page
            return Unauthorized();
        }
    }
}
