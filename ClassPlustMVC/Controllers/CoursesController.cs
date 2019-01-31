using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClassPlustMVC.Data;
using ClassPlustMVC.Models;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace ClassPlustMVC.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CoursesController> _logger;

        public IList<Course> Customers { get; private set; }

        public IList<Enrollment> Enrollments { get; private set; }

        public CoursesController(ApplicationDbContext context, ILogger<CoursesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Courses
        [Authorize(Roles="teacher")]
        public async Task<IActionResult> Index()
        {
            string userEmail = User.Identity.Name;

           
          
            var teacherCourses = _context.Courses.Where(x => x.TeacherId.Equals(userEmail));
            return View(await teacherCourses.ToListAsync());
        }

        public async Task<IActionResult> StudentIndex()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

         
            var studentEnrollments = _context.Enrollments
                .Where(e => e.StudentId==userId && e.Active==1)
                .Select(e => e.CourseId);

            var studentCourses = _context.Courses
                .Where(c => c.Enrolments.Any(l => studentEnrollments.Contains(l.CourseId)));
            return View(await studentCourses.ToListAsync());
            //return View(await _context.Courses.ToListAsync());
        }

        public async Task<IActionResult> StudentCourses()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
           
            var studentEnrollments = _context.Enrollments
                .Where(e => e.StudentId == userId && e.Active == 1)
                .Select(e => e.CourseId);
            var allCourses = _context.Courses
                .Where(c => !c.Enrolments.Any(l => studentEnrollments.Contains(l.CourseId)));

            return View(await allCourses.ToListAsync());
        }


        // GET: Courses/Details/5
        [Authorize(Roles = "teacher")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        [Authorize(Roles = "teacher")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "teacher")]
        public async Task<IActionResult> Create([Bind("CourseId,TeacherId,CourseName,CourseDescription,SchoolName,Active")] Course course)
        {
            if (ModelState.IsValid)
            {
                course.TeacherId = User.Identity.Name;
                course.Active = 1;
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Edit/5
        [Authorize(Roles = "teacher")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "student")]
        public async Task<IActionResult> StudentIndex(int? id)
        {
            var Course = await _context.Courses.FindAsync(id);

            if (Course != null)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                Enrollment enrollment = new Enrollment(Course.CourseId, userId, 1);
                _context.Enrollments.Add(enrollment);
                await _context.SaveChangesAsync();

            }

            return RedirectToAction("StudentIndex");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "student")]
        public async Task<IActionResult> StudentCourses(int? id)
        {
            var Course = await _context.Courses.FindAsync(id);

            if (Course != null)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                Enrollment enrollment = new Enrollment(Course.CourseId, userId, 1);
                _context.Enrollments.Add(enrollment);
                await _context.SaveChangesAsync();

            }

            return RedirectToAction("StudentIndex");
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "teacher")]
        public async Task<IActionResult> Edit(int id, [Bind("CourseId,TeacherId,CourseName,CourseDescription,SchoolName,Active")] Course course)
        {
            if (id != course.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.CourseId))
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
            return View(course);
        }

        // GET: Courses/Delete/5
        [Authorize(Roles = "teacher")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "teacher")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.CourseId == id);
        }
    }
}
