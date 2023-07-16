using Employee.Data;
using Employee.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Data;

namespace Employee.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly UsersContext _db;

        public EmployeeController(UsersContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Users> objUsersList = _db.Employees;

            return View(objUsersList);
           
        }
        // get
        public IActionResult Create()
        {

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Users obj)
        {
            if(obj!=null){
                _db.Employees.Add(obj);
                _db.SaveChanges();
                TempData["success"] = " created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("details", "Fill the Form");
            }
            return View(obj);
        }
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
               return NotFound();
            }
			var usersFromDb = _db.Employees.Find(id);
			return View(usersFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Users obj)
        {
            if (obj != null)
            {
                _db.Employees.Update(obj);
                _db.SaveChanges();
				TempData["success"] = " created successfully";
				return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete (int? id)
        {
            if(id != null)
            {
				var obj = _db.Employees.Find(id);
                return View(obj);
			}
            else
            {
                return NotFound();
            }
            return View();
        }

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeletePost(int id)
		{
			var obj = _db.Employees.Find(id);
			if (obj != null)
			{
				_db.Employees.Remove(obj);
				_db.SaveChanges();
				TempData["success"] = "Deleted successfully";
				return RedirectToAction("Index");
			}
			return NotFound();

		}
         
         

	}

	

}
