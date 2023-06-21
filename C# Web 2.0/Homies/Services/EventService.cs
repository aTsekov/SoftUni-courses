using System.Collections;
using Homies.Contracts;
using Homies.Data;
using Homies.Models;
using Microsoft.EntityFrameworkCore;
using Type = Homies.Data.Type;

namespace Homies.Services
{
	public class EventService:IEventService
	{
		private readonly HomiesDbContext dbContext;

		public EventService(HomiesDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
		
		public async Task<IEnumerable<ViewAllModel>> GetAllEventsAsync()
		{
			return await dbContext.Events.Select(e => new ViewAllModel
			{
				Name = e.Name,
				Start = e.Start.ToString("yyyy-MM-dd H:mm"),
				Type = e.Type.Name

			}).ToListAsync();
		}

       

        public async Task<ICollection<ViewJoinedModel>> GetMyEventsAsync(string userId)
        {
            return await dbContext.Events.Select(e => new ViewJoinedModel()
            {
                Name = e.Name,
                Start = e.Start.ToString("yyyy-MM-dd H:mm"),
                Type = e.Type.Name

            }).ToListAsync();
        }
        public async Task AddEventAsync(AddEventView model)
        {
            

            Event ev = new Event
            {
                Name = model.Name,
                Description = model.Description,
                CreatedOn = model.Start,
                End = model.End,
                TypeId = model.Type.Id

            };

            await this.dbContext.Events.AddAsync(ev);
            await this.dbContext.SaveChangesAsync();

        }
    }
}
