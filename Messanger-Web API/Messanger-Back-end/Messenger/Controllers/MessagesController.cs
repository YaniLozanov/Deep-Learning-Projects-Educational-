using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messanger.Data;
using Messanger.Domain;
using Messenger.Models;
using Microsoft.AspNetCore.Mvc;

namespace Messenger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly MessangerDbContext context;

        public MessagesController(MessangerDbContext context)
        {
            this.context = context;
        }

        [HttpGet(Name ="All")]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<Message>>> AllOrderedByCreatedAscending ()
        {
            return this.context.Messages
                .OrderBy(message => message.CreatedOn)
                .ToList();
        }

        [HttpPost(Name = "Create")]
        [Route("create")]
        public async Task<ActionResult> Create(MessageCreateBindingModel messageCreateBindingModel)
        {
            var message = new Message()
            {
                Content = messageCreateBindingModel.Content,
                User = messageCreateBindingModel.User,
                CreatedOn = DateTime.UtcNow
            };

            await this.context.Messages.AddAsync(message);
            await this.context.SaveChangesAsync();

            return this.Ok(); 
        }
    }
}
