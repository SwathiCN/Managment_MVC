using Managment.DataAccess.Data;
using Managment.DataAccess.Repository.IRepository;
using Managment.Models;
using Microsoft.AspNetCore.Mvc;

namespace Managmentproject.Areas.Students.Controllers
{
    [Area("Students")]
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Student> objStudentList = _unitOfWork.Student.GetAll().ToList();
            return View(objStudentList);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Student obj)
        {
            if (obj.Section == obj.StudentName.ToString())
            {
                ModelState.AddModelError("Section", "The Section cannot exactly match the Name.");
                return View(obj);
            }


            if (ModelState.IsValid)
            {
                _unitOfWork.Student.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Student List Created Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }



        public IActionResult Edit(int? studentid)
        {
            if (studentid == null || studentid == 0)
            {
                return NotFound();
            }
            Student? studentFromDb = _unitOfWork.Student.Get(u => u.StudentId == studentid);
            //Student? studentFromDb1 = _db.Students.FirstOrDefault(u=>u.StudentId==studentid);
            //Student? studentFromDb2 = _db.Students.Where(u=>u.StudentId==studentid).FirstOrDefault();

            if (studentFromDb == null)
            {
                return NotFound();
            }
            return View(studentFromDb);
        }


        [HttpPost]
        public IActionResult Edit(Student obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Student.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Student List Updated Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? studentid)
        {
            if (studentid == null || studentid == 0)
            {
                return NotFound();
            }
            Student? studentFromDb = _unitOfWork.Student.Get(u => u.StudentId == studentid); ;

            if (studentFromDb == null)
            {
                return NotFound();
            }
            return View(studentFromDb);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? studentid)
        {
            Student? obj = _unitOfWork.Student.Get(u => u.StudentId == studentid);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Student.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Student List Deleted Successfully";
            return RedirectToAction("Index");
        }

    }
}


