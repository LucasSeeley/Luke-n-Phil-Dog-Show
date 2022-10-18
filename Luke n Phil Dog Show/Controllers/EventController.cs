using Luke_n_Phil_Dog_Show.View_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Luke_n_Phil_Dog_Show.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Events()
        {
            return View();
        }

        public IActionResult Tickets(string? returnUrl = null)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem()
            {
                Value = "Event1",
                Text = "Event1"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "Event2",
                Text = "Event2"
            });

            TicketViewModel ticketViewModel = new TicketViewModel();
            ticketViewModel.EventList = listItems;
            ticketViewModel.ReturnUrl = returnUrl;
            return View(ticketViewModel);
        }
    }
}
