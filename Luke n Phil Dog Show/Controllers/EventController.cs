using Luke_n_Phil_Dog_Show.Interfaces;
using Luke_n_Phil_Dog_Show.Models;
using Luke_n_Phil_Dog_Show.View_Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Luke_n_Phil_Dog_Show.Controllers
{
    public class EventController : Controller
    {
        /*
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        */
        private readonly IMailgunSenderEmail _mailgunSenderEmail;

        public EventController(IMailgunSenderEmail mailgunSenderEmail)
        {
            //_userManager = userManager;
            //_signInManager = signInManager;
            //_roleManager = roleManager;
            _mailgunSenderEmail = mailgunSenderEmail;
        }

        public IActionResult Events()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Tickets(string? returnUrl = null)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem()
            {
                Value = "2023 Corgi Race Championships",
                Text = "2023 Corgi Race Championships"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "2023 Big Dog Agility Competition",
                Text = "2023 Big Dog Agility Competition"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "2023 Conformation and Junior Showmanship Exhibitor Qualifying Information",
                Text = "2023 Conformation and Junior Showmanship Exhibitor Qualifying Information"
            });

            TicketViewModel ticketViewModel = new TicketViewModel();
            ticketViewModel.EventList = listItems;
            ticketViewModel.ReturnUrl = returnUrl;
            return View(ticketViewModel);
        }



        [HttpPost]
        public async Task<IActionResult> Tickets(TicketViewModel ticketViewModel)
        {
            if (ModelState.IsValid)
            {
                await _mailgunSenderEmail.SendEmailAsync(ticketViewModel.Email, "Ticket Purchase Confirmation", $"Your order has been confirmed!\n{ticketViewModel.EventSelected}\n{ticketViewModel.FirstName}");
                return RedirectToAction("TicketConfirmation");
            }
            return View(ticketViewModel);
        }

        [HttpGet]
        public IActionResult TicketConfirmation()
        {
            return View();
        }
    }
}
