using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Calc;
using Web.Models;

namespace Web.Controllers
{
    [Authorize]
    public class CalcController : Controller
    {
        // GET: Calc
        public ActionResult Index()
        {
            return View(new OperationModel());
        }
        
        public ActionResult Execute(OperationModel model)
        {
            //HttpContext.Request["Name"]; валидация 
            if (ModelState.IsValid)
            {
                return View("Index", model);
            }
            var calc = new Calc.Calc(new IOperation[] { new SumOperation(), new RaznOperation()  });
            var result = calc.Execute(model.Name, model.GetParameters());
            ViewData.Model = $"result = {result}";
            return View();
        }
    }
}