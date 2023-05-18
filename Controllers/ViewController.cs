 using Microsoft.AspNetCore.Mvc;
using Qhluxury.Data;
using Qhluxury.Models;

namespace Qhluxury.Controllers
{
    public class ViewController : Controller
    {
        public IActionResult viewnhan()
        {
            QhluxuryContext context = new QhluxuryContext();
            IEnumerable<Hanghoa> s = from x in context.Hanghoas
                                     where x.Maloaihang == 2
                                     select x;


            return View(s);
        }
        public IActionResult viewdongho()
        {
            QhluxuryContext context = new QhluxuryContext();
            IEnumerable<Hanghoa> s = from x in context.Hanghoas
                                     where x.Maloaihang == 3
                                     select x;


            return View(s);
        }
        public IActionResult viewgiohang()
        {
           
            return View();
        }
        public IActionResult viewkm()
        {

            return View();
        }
        public IActionResult viewls()
        {

            return View();
        }

    }
}
