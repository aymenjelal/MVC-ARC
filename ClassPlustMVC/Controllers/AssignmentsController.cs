using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClassPlustMVC.Data;
using ClassPlustMVC.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.IO.Compression;
using System.Security.Claims;

namespace ClassPlustMVC.Controllers
{
    public class AssignmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AssignmentsController> _logger;

        public AssignmentsController(ApplicationDbContext context, ILogger<AssignmentsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Assignments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Assignments.Include(a => a.Course);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> CourseAssignment(int? id)
        {
            var applicationDbContext = _context.Assignments.Include(a => a.Course).Where(a=>a.CourseId==id);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> PendingAssignment(int? id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var studentResponse = _context.Responses
                .Where(r => r.StudentId == userId)
                .Select(r=>r.AssignmentId);
            var pendingAssignments = _context.Assignments.Include(c => c.Course)
                .Where(c => c.CourseId == id && c.Deadline > DateTime.Now && !c.Responses.Any(l => studentResponse.Contains(l.AssignmentId)));
            return View(await pendingAssignments.ToListAsync());
            //var applicationDbContext = _context.Assignments.Include(a => a.Course).Where(a => a.CourseId == id && a.Deadline>DateTime.Now);
            //return View(await applicationDbContext.ToListAsync());
        }

        // GET: Assignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments
                .Include(a => a.Course)
                .FirstOrDefaultAsync(m => m.AssignmentId == id);
            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        // GET: Assignments/Create
        public IActionResult Create(int? id)
        {
            ViewData["CourseId"] = id;
            //ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId");
            return View();
        }

        // POST: Assignments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssignmentId,Deadline,Topic")] Assignment assignment, IFormFile files,int? id)
        {
            if (ModelState.IsValid)
            {
                assignment.CourseId = id.GetValueOrDefault();
                assignment.PostDate = DateTime.Now;

                var filePath = Path.GetTempFileName();

                using (var stream = new MemoryStream())
                {
                    await files.CopyToAsync(stream);
                    assignment.Question = stream.ToArray();
                }
                string filename= files.FileName;
                string[] filenmeList = filename.Split('.');
                assignment.postType = filenmeList[1];
                _logger.LogCritical(filename);



               
                _context.Add(assignment);
                await _context.SaveChangesAsync();
                return LocalRedirect("~/assignments/CourseAssignment/" + id);
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", assignment.CourseId);
            return View(assignment);
        }

        // GET: Assignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", assignment.CourseId);
            return View(assignment);
        }

        // POST: Assignments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssignmentId,CourseId,PostDate,Deadline,Topic,Question")] Assignment assignment)
        {
            if (id != assignment.AssignmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssignmentExists(assignment.AssignmentId))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", assignment.CourseId);
            return View(assignment);
        }

        public FileResult DownloadFile(int? id)
        {
            _logger.LogCritical(id.ToString());

            var assignment = _context.Assignments.Include(a=>a.Course).FirstOrDefault(a=>a.AssignmentId==id);

            
                if (assignment.postType.Equals("zip"))
                {
                    MemoryStream stream = new MemoryStream(assignment.Question);
                string fileName = assignment.Course.CourseName + " Asignment " + assignment.AssignmentId+".zip";
                    var zippedFile = GetZippedFiles(stream, "file");
                    return File(zippedFile, // We could use just Stream, but the compiler gets a warning: "ObjectDisposedException: Cannot access a closed Stream" then.
                                "application/zip",
                                fileName);
                }

                else
                {

                string fileName= assignment.Course.CourseName + " Asignment " + id + "."+assignment.postType;
                string downloadType = "application/" + assignment.postType;
                return File(assignment.Question, downloadType, fileName);
                }
            
           
            
        }

        // GET: Assignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments
                .Include(a => a.Course)
                .FirstOrDefaultAsync(m => m.AssignmentId == id);
            if (assignment == null)
            {
                return NotFound();
            }
           

            return View(assignment);
        }

        // POST: Assignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assignment = await _context.Assignments.FindAsync(id);
            _context.Assignments.Remove(assignment);
            await _context.SaveChangesAsync();
            return LocalRedirect("~/assignments/CourseAssignment/" + assignment.CourseId);
        }

        private bool AssignmentExists(int id)
        {
            return _context.Assignments.Any(e => e.AssignmentId == id);
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
