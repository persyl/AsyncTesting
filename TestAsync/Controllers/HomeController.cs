using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TestAsync.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var x = await Foo();
            return View();
        }

        private async Task<string> Foo()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("http://jsonplaceholder.typicode.com/posts/1");
                return (await response.Content.ReadAsStringAsync());
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}