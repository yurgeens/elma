using System.Web.Mvc;
using Web.Services;

namespace Web.Controllers
{
    public class OperationResultController : Controller
    {
        private IOperationResultRepostiory repository { get; set; }

        public OperationResultController()
        {
            repository = new OperationResultRepostiory();
        }

        //GET: OperationResult
        public ActionResult Index()
        {
            // нужно фильтровать операции - выводить только те, которые выполнялись дольше 1 секунды

            var operations = repository.GetAll();

            return View(operations);
        }
    }
}