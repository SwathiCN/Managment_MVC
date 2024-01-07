using Managment.DataAccess.Data;
using Managment.DataAccess.Repository.IRepository;
using Managment.Models;
using Microsoft.AspNetCore.Mvc;

namespace Managmentproject.Areas.Students.Controllers
{
    [Area("Students")]
    public class MarksDetailController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public MarksDetailController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<MarksDetail> objMarksDetailList = _unitOfWork.MarksDetails.GetAll().ToList();
            return View(objMarksDetailList);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(MarksDetail obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.MarksDetails.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Student List Created Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }



        public IActionResult Edit(int? marksid)
        {
            if (marksid == null || marksid == 0)
            {
                return NotFound();
            }
            MarksDetail? marksFromDb = _unitOfWork.MarksDetails.Get(u => u.MarksId == marksid);
            //Student? studentFromDb1 = _db.Students.FirstOrDefault(u=>u.StudentId==studentid);
            //Student? studentFromDb2 = _db.Students.Where(u=>u.StudentId==studentid).FirstOrDefault();

            if (marksFromDb == null)
            {
                return NotFound();
            }
            return View(marksFromDb);
        }


        [HttpPost]
        public IActionResult Edit(MarksDetail obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.MarksDetails.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Student List Updated Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? marksid)
        {
            if (marksid == null || marksid == 0)
            {
                return NotFound();
            }
            MarksDetail? marksFromDb = _unitOfWork.MarksDetails.Get(u => u.MarksId == marksid); ;

            if (marksFromDb == null)
            {
                return NotFound();
            }
            return View(marksFromDb);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? marksid)
        {
            MarksDetail? obj = _unitOfWork.MarksDetails.Get(u => u.MarksId == marksid);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.MarksDetails.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Student List Deleted Successfully";
            return RedirectToAction("Index");
        }

    }
}


