using System.Diagnostics;
using CMCSWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace CMCSWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (User.IsInRole("Manager"))
            {
                return RedirectToAction("ManagerDashboard");
            }
            else if (User.IsInRole("Coordinator"))
            {
                return RedirectToAction("CoordinatorDashboard");
            }
            else if (User.IsInRole("HR"))
            {
                return RedirectToAction("HRDashboard");
            }
            else if (User.IsInRole("Lecturer"))
            {
                return RedirectToAction("LecturerDashboard");
            }
            // If the user has no specific role, or if they are not logged in, return the default welcome page.
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // Action method for the Manager's dashboard
        [Authorize(Roles = "Manager")]
        public IActionResult ManagerDashboard()
        {
            var model = new ManagerDashboardViewModel
            {
                PendingClaimsCount = 3,
                ApprovedClaimsCount = 12,
                TotalClaimsCount = 15,
                ClaimsForReview = new List<ClaimForReview>
                {
                    new ClaimForReview { ClaimId = "#CMCS-101", LecturerName = "John Doe", ClaimPeriod = "July 2025", Status = "Pending" },
                    new ClaimForReview { ClaimId = "#CMCS-104", LecturerName = "Jane Smith", ClaimPeriod = "August 2025", Status = "Pending" }
                }
            };
            return View("~/Views/Dashboard/ManagerDashboard.cshtml", model);
        }

        [Authorize(Roles = "Lecturer")]
        public IActionResult LecturerDashboard()
        {
            ViewData["PendingClaims"] = 3;
            ViewData["ApprovedClaims"] = 12;
            ViewData["TotalClaims"] = 15;
            ViewData["Claims"] = new List<dynamic>
            {
                new { ClaimId = "#CMCS-101", ClaimPeriod = "July 2025", Status = "Pending" },
                new { ClaimId = "#CMCS-102", ClaimPeriod = "June 2025", Status = "Approved" },
                new { ClaimId = "#CMCS-103", ClaimPeriod = "May 2025", Status = "Approved" }
            };
            return View("~/Views/Dashboard/LecturerDashboard.cshtml");
        }

        [Authorize(Roles = "HR")]
        public IActionResult HRDashboard()
        {
            ViewData["ClaimsToBeProcessed"] = 5;
            ViewData["TotalLecturers"] = 50;
            ViewData["ClaimsProcessedThisMonth"] = 25;
            ViewData["ApprovedClaimsList"] = new List<dynamic>
            {
                new { ClaimId = "#CMCS-101", LecturerName = "John Doe", ClaimPeriod = "July 2025", PaymentDue = "R 5,000" },
                new { ClaimId = "#CMCS-102", LecturerName = "Jane Smith", ClaimPeriod = "June 2025", PaymentDue = "R 6,500" }
            };
            return View("~/Views/Dashboard/HRDashboard.cshtml");
        }

        // Action method for the Coordinator's dashboard
        [Authorize(Roles = "Coordinator")]
        public IActionResult CoordinatorDashboard()
        {
            ViewData["PendingClaims"] = 3;
            ViewData["ApprovedClaims"] = 12;
            ViewData["TotalClaims"] = 15;
            ViewData["Claims"] = new List<dynamic>
            {
                new { ClaimId = "#CMCS-101", LecturerName = "John Doe", ClaimPeriod = "July 2025", Status = "Pending" },
                new { ClaimId = "#CMCS-104", LecturerName = "Jane Smith", ClaimPeriod = "August 2025", Status = "Pending" }
            };
            return View("~/Views/Dashboard/CoordinatorDashboard.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}