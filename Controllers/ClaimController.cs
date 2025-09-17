using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CMCSWebApp.Models;
using System.IO;
using System.Threading.Tasks;

namespace CMCSWebApp.Controllers
{
    [Authorize(Roles = "Lecturer")]
    public class ClaimController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ClaimController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Claims/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Claims/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Claim claim, List<IFormFile> supportingDocuments)
        {
            if (ModelState.IsValid)
            {
                // Assign properties before saving
                claim.Status = "Pending";
                claim.SubmissionDate = DateTime.Now;
                // Get the current user's name or ID and assign to claim.LecturerName
                claim.LecturerName = User.Identity.Name;

                // 1. Save the claim to the database (replace with your DbContext logic)
                // _context.Claims.Add(claim);
                // await _context.SaveChangesAsync();

                // 2. Handle file uploads
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "claims_documents");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                foreach (var file in supportingDocuments)
                {
                    if (file.Length > 0)
                    {
                        var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        // 3. Save file path to the database, linked to the new claim
                        // For example:
                        // var document = new Document { ClaimId = claim.Id, FilePath = filePath };
                        // _context.Documents.Add(document);
                    }
                }
                // await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Dashboard");
            }

            return View(claim);
        }
    }
}