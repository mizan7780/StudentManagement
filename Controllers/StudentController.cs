using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models.Entities;
using StudentManagement.Models.ViewModels;
using StudentManagement.Services.Implementation;
using StudentManagement.Services.Interface;
using StudentManagement.Services.Model;

namespace StudentManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;

        public StudentController(IMapper mapper, IStudentService studentService)
        {
            _mapper = mapper;
            _studentService = studentService;
        }
        public async Task<IActionResult> Index([FromQuery] FilterStudentModel filter)
        {
            var students = await _studentService.GetFilteredStudentListAsync(filter);

            var filteredOrderedStudents = students
                .Where(s => DateTime.Now.Year - s.DOB.Year > 18)
                .OrderBy(s => s.FirstName)
                .ThenBy(s => s.LastName)
                .ToList();

            var studentList = _mapper.Map<List<StudentListViewModel>>(filteredOrderedStudents);

            return View(studentList);


        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(StudentCreateViewModel student)
        {
            if (!ModelState.IsValid)
                return View(student);

            var studentEntity = _mapper.Map<Student>(student);

            await _studentService.AddAsync(studentEntity);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Details(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null)
                return NotFound();

            var viewModel = _mapper.Map<StudentListViewModel>(student);
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null)
                return NotFound();

            var viewModel = _mapper.Map<StudentEditViewModel>(student);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, StudentEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var student = await _studentService.GetByIdAsync(id);
            if (student == null)
                return NotFound();

            _mapper.Map(model, student);
            await _studentService.UpdateAsync(student);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null)
                return NotFound();

            var viewModel = _mapper.Map<StudentListViewModel>(student);
            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _studentService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsEmailAvailable(string email)
        {
            var allStudents = await _studentService.GetAllAsync();
            bool emailExists = allStudents.Any(s => s.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            if (emailExists)
            {
                return Json($"Email '{email}' is already in use.");
            }
            return Json(true);
        }
    }
}
