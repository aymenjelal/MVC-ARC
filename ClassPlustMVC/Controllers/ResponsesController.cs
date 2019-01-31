using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClassPlustMVC.Data;
using ClassPlustMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Security.Claims;
using System.IO.Compression;

namespace ClassPlustMVC.Controllers
{
    public class ResponsesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResponsesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Responses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Responses.Include(r => r.Assignment);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> AssignmentResponse(int? id)
        {
            var applicationDbContext = _context.Responses.Include(r => r.Assignment ).Include(r => r.Student).Where(r=>r.AssignmentId==id);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Responses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _context.Responses
                .Include(r => r.Assignment)
                .FirstOrDefaultAsync(m => m.ResponseId == id);
            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        // GET: Responses/Create
        [Authorize(Roles = "student")]
        public IActionResult Create()
        {
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "AssignmentId", "AssignmentId");
            return View();
        }

        // POST: Responses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "student")]
        public async Task<IActionResult> Create([Bind("ResponseId")] Response response, IFormFile files, int? id)
        {
            if (ModelState.IsValid)
            {
                response.AssignmentId = id.GetValueOrDefault();
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

                var pendingAssignments = _context.Assignments.FirstOrDefault(a => a.AssignmentId == id);
                

                response.StudentId = userId;
                response.PostDate = DateTime.Now;

                var filePath = Path.GetTempFileName();

                using (var stream = new MemoryStream())
                {
                    await files.CopyToAsync(stream);
                    response.Submission = stream.ToArray();
                }
                string filename = files.FileName;
                string[] filenmeList = filename.Split('.');
                response.postType = filenmeList[1];
                
                _context.Add(response);
                await _context.SaveChangesAsync();
                return LocalRedirect("~/assignments/PendingAssignment/"+pendingAssignments.CourseId);
            }
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "AssignmentId", "AssignmentId", response.AssignmentId);
            return View(response);
        }

        // GET: Responses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _context.Responses.FindAsync(id);
            if (response == null)
            {
                return NotFound();
            }
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "AssignmentId", "AssignmentId", response.AssignmentId);
            return View(response);
        }

        // POST: Responses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResponseId,StudentId,AssignmentId,PostDate,Submission,postType")] Response response)
        {
            if (id != response.ResponseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(response);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResponseExists(response.ResponseId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "AssignmentId", "AssignmentId", response.AssignmentId);
            return View(response);
        }

        // GET: Responses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _context.Responses
                .Include(r => r.Assignment)
                .FirstOrDefaultAsync(m => m.ResponseId == id);
            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        // POST: Responses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _context.Responses.FindAsync(id);
            _context.Responses.Remove(response);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResponseExists(int id)
        {
            return _context.Responses.Any(e => e.ResponseId == id);
        }

        public FileResult DownloadFile(int? id)
        {
            

            var response = _context.Responses.Include(a => a.Assignment).Include(a=>a.Student).FirstOrDefault(a => a.ResponseId == id);


            if (response.postType.Equals("zip"))
            {
                MemoryStream stream = new MemoryStream(response.Submission);
                string fileName = response.Student.FirstName +" "+response.Student.LastName+" Asignment " + response.Assignment.AssignmentId + ".zip";
                var zippedFile = GetZippedFiles(stream, "file");
                return File(zippedFile, // We could use just Stream, but the compiler gets a warning: "ObjectDisposedException: Cannot access a closed Stream" then.
                            "application/zip",
                            fileName);
            }

            else
            {

                string fileName = response.Student.FirstName + " " + response.Student.LastName + " Asignment " + response.Assignment.AssignmentId + "." + response.postType;
                string downloadType = "application/" + response.postType;
                return File(response.Submission, downloadType, fileName);
            }



        }

        private byte[] GetZippedFiles(MemoryStream originalFileStream, string fileName)
        {
            using (MemoryStream zipStream = new MemoryStream())
            {
                using (ZipArchive zip = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
                {
                    var zipEntry = zip.CreateEntry(fileName);
                    using (var writer = new StreamWriter(zipEntry.Open()))
                    {
                        originalFileStream.WriteTo(writer.BaseStream);

                    }


                }
                return zipStream.ToArray();
            }
        }
    }
}
