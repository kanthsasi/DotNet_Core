using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentPortal.Web.Models.DTO;
using StudentPortal.Web.Models.Entities;
using StudentPortal.Web.Repositiories;

namespace StudentPortal.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IMapper mapper;
        private readonly IStudentRepository studentRepository;
        private readonly IUnitOfWork unitOfWork;

        public StudentController(IMapper mapper,IStudentRepository studentRepository,IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.studentRepository = studentRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> List()
        {
            //var student = await studentRepository.GetAllAsync();
            var student = await unitOfWork.Students.GetAllAsync();
            var studentDto = mapper.Map<List<StudentDTO>>(student);
            return View(studentDto);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddStudentDTO addStudentDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(addStudentDTO);
            }
            var student = mapper.Map<Student>(addStudentDTO);
            //await studentRepository.CreateAsync(student);
            await unitOfWork.Students.CreateAsync(student);
            await unitOfWork.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            //var student = await studentRepository.GetByIdAsync(id);
            var student = await unitOfWork.Students.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            var studentDto = mapper.Map<StudentDTO>(student);
            return View(studentDto);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, UpdateStudentDTO updateStudentDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(updateStudentDTO);
            }
            var student = mapper.Map<Student>(updateStudentDTO);
            //var updatestudent = await studentRepository.UpdateAsync(id,student);
            var updatestudent = await unitOfWork.Students.UpdateAsync(id, student);
            if (updatestudent == null)
            {
                return NotFound();
            }
            await unitOfWork.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }
       /* public async Task<IActionResult> Delete(Guid id)
        {
            var student = await studentRepository.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(mapper.Map<StudentDTO>(student));
        }
       */
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            //var student = await studentRepository.DeleteAsync(id);
            var student = await unitOfWork.Students.DeleteAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            await unitOfWork.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }
    }
}
