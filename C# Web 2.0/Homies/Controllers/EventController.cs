using Homies.Contracts;
using Homies.Models;
using Homies.Services;
using Microsoft.AspNetCore.Mvc;

namespace Homies.Controllers
{
	public class EventController : BaseController
	{
		private readonly IEventService eventService;

		public EventController(IEventService eventService)
		{
			this.eventService = eventService;
		}
		public async Task<IActionResult> All()
		{
			var model = await eventService.GetAllEventsAsync();

			return View(model);
		}

		
        public async Task<IActionResult> Add()
        {
            var model = new AddEventView();

            return  View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEventView model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await eventService.AddEventAsync(model);
            return RedirectToAction("Joined", "Event");
        }

        public async Task<IActionResult> Joined(AddEventView model)
        {
            throw new NotImplementedException();
        }

    }
}
