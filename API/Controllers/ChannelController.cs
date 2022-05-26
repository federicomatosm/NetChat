using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Channels;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers

{
  
    public class ChannelController : BaseController
    {
       

        public ChannelController(IMediator mediator)
        {
           
        }

        [HttpGet]
        public async Task<ActionResult<List<Channel>>> List()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        
        public async Task<ActionResult<Channel>> Details(Guid id)
        {
            return await Mediator.Send(new Details.Query { Id = id });
        }

        [HttpPost]
        public async Task<Unit> Create(Create.Command command)
        {
            return await Mediator.Send(command);
        }
    }
}
