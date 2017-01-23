using Services;
using System.Linq;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class OperationResultController : Controller
    {
        private IOperationResultRepostiory repository { get; set; }

        public OperationResultController()
        {
            repository = new NHOperationResultRepostiory();
        }

        //GET: OperationResult
        public ActionResult Index()
        {
            // нужно фильтровать операции - выводить только те, которые выполнялись дольше 1 секунды

            var operations = repository.GetAll().OrderByDescending(it=> it.Id).Take(5);

            return View(operations);
        }
    }
}