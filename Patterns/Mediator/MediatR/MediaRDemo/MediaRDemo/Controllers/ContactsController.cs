using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatRDemo.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MediaRDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private IMediator mediator;

        public ContactsController(IMediator mediator) => this.mediator = mediator;



        // gets Query (Id) from Route and sends to Mediator. Mediator DELEGATES to the handler
        [HttpGet("{id}")]
        public async Task<Contact> GetContact([FromRoute]Query query) => await this.mediator.Send(query);



        

        public class Query : IRequest<Contact>
        {
            public int Id { get; set; }
        }


        public class ContactHandler : IRequestHandler<Query, Contact>
        {

            //handles the request. see IRequestHandler defn. takes a Query and returns a response.

            private ContactsContext db;

            public ContactHandler(ContactsContext db) => this.db = db;

            public Task<Contact> Handle(Query request, CancellationToken cancellationToken)
            {
                return this.db.Contacts.Where(c => c.Id == request.Id).SingleOrDefaultAsync();
            }
        }

        
    }
}