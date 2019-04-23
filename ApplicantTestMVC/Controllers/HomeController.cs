using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplicantTestMVC.Models;
using ApplicantTestMVC.ViewModels;

namespace ApplicantTestMVC.Controllers
{
    public class HomeController : Controller
    {
        private ApplicantTestMVCContext _db = new ApplicantTestMVCContext();
        // GET: Home
        public ActionResult Orders(string error = null)
        {
            string errorMsg = null;
            if (error != null)
            {
                errorMsg = error;
            }
            ViewBag.ErrorMsg = errorMsg;
            List<order> orders = _db.order.ToList();
            return View(orders);
        }

        public ActionResult OrderDetails(int? id)
        {
            if (id == null)
            {
                string errorMsg = "A valid order must be selected.  Please select a valid order from below:";
                return RedirectToAction("Index", "Home", new { error = errorMsg });
            }

            order selectedOrder = _db.order.Find(id);
            user userObj = _db.user.Where(x => x.user_id == selectedOrder.user_id).FirstOrDefault();
            List<line_item> allLineItems = _db.line_item.Include("unit").Include("stock").ToList();
            List<line_item> lineItems = allLineItems.Where(x => x.order_id == id).ToList();

            OrderVM model = new OrderVM
            {
                order = selectedOrder,
                user = userObj,
                line_items = lineItems
            };

            int totalQty = 0;

            foreach (var lineItem in lineItems) totalQty = totalQty + lineItem.qty;
            ViewBag.TotalQty = totalQty;
            decimal totalCost = 0;
            foreach (var lineItem in lineItems)
            {
                decimal unitCost = _db.unit.Where(u => u.unit_id == lineItem.unit_id).Select(u => u.cost).FirstOrDefault();
                totalCost = totalCost + (unitCost * lineItem.qty);
            };

            ViewBag.TotalCost = totalCost;
            return View(model);
        }

        public ActionResult Users(string error = null)
        {
            string errorMsg = error;
            ViewBag.ErrorMsg = errorMsg;
            List<user> users = _db.user.ToList();
            return View(users);
        }

        public ActionResult AddUser(UserVM model)
        {
            if (ModelState.IsValid)
            {
                user newUser = new user
                {
                    userName = model.userName,
                    address = model.address,
                };
       
                _db.user.Add(newUser);
                _db.SaveChanges();
                return RedirectToAction("Users", "Home");
            }
            string errorMsg = "An error occured while adding the user.  Please try again, and contact your system administrator if you continue to have this problem.";
            return RedirectToAction("Users", "Home", new { error = errorMsg });
        }

    }
}