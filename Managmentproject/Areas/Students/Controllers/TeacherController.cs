using Managment.DataAccess.Repository.IRepository;
using Managment.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Managment.Controllers
{
    [Area("Students")]
    public class TeacherController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeacherController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Teacher> objTeacherList = _unitOfWork.Teacher.GetAll().ToList();
            return View(objTeacherList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Teacher obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Teacher.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Teacher Created Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? teacherId)
        {
            if (teacherId == null || teacherId == 0)
            {
                return NotFound();
            }

            Teacher teacherFromDb = _unitOfWork.Teacher.Get(t => t.TeacherId == teacherId);
            if (teacherFromDb == null)
            {
                return NotFound();
            }

            return View(teacherFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Teacher obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Teacher.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Teacher Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? teacherId)
        {
            if (teacherId == null || teacherId == 0)
            {
                return NotFound();
            }

            Teacher teacherFromDb = _unitOfWork.Teacher.Get(u => u.TeacherId == teacherId);

            if (teacherFromDb == null)
            {
                return NotFound();
            }

            return View(teacherFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? teacherId)
        {
            Teacher obj = _unitOfWork.Teacher.Get(u => u.TeacherId == teacherId);

            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Teacher.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Teacher Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}