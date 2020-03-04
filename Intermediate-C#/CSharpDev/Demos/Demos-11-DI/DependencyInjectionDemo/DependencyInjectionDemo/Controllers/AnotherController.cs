using Microsoft.AspNetCore.Mvc;
using DependencyInjectionDemo.Injectables;

namespace DependencyInjectionDemo.Controllers
{
    public class AnotherController : Controller
    {
        private IBiz biz1, biz2;

        public AnotherController(IBiz biz1, IBiz biz2)
        {
            this.biz1 = biz1;
            this.biz2 = biz2;
        }

        public IActionResult Index()
        {
            ViewData["message1"] = biz1.Message;
            ViewData["message2"] = biz2.Message;
            return View();
        }
    }
}
