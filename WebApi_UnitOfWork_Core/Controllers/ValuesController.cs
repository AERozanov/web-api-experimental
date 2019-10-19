using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Data.Model;
using Domain.MapperInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Linq;
using WebApi_UnitOfWork_Core.Models;
using WebApi_UnitOfWork_Core.NhibernateExtensions;

namespace WebApi_UnitOfWork_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMapperSession _session;

        public ValuesController(IMapperSession session)
        {
            _session = session;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("books")]
        public IActionResult Index()
        {
            var bk = new Book();
            bk.Title = "test";
           
            var res = _session.Save(bk);
            res.GetAwaiter().GetResult();

            var books = _session.Books.ToList();

            return Ok(books);
        }

        [HttpGet("loadasync")]
       
            public async Task<IActionResult> first()
            {
             _session.BeginTransaction();
            var bk = new Book();
         //   bk.Id = Guid.NewGuid();
            bk.Title = "test";
            await _session.Save(bk);
          
            var book = await _session.Books.FirstOrDefaultAsync();
            book.Title += " (sold out)";
            await _session.Save(book);
            await _session.Commit();
            var books = await _session.Books
                                        .Where(b => b.Title.StartsWith("How to"))
                                        .ToListAsync();
            return Ok(bk);
            }

        [HttpGet("webs")]
        public async Task GetWs()
        {
            var context = ControllerContext.HttpContext;
            var isSocketRequest = context.WebSockets.IsWebSocketRequest;

            if (isSocketRequest)
            {
                WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
                await GetMessages(context, webSocket);
            }
            else
            {
                context.Response.StatusCode = 400;
            }
        }

        private async Task GetMessages(HttpContext context, WebSocket webSocket)
        {
            var messages = new[]
            {
            "Message1",
            "Message2",
            "Message3",
            "Message4",
            "Message5"
        };

            foreach (var message in messages)
            {
                var bytes = Encoding.ASCII.GetBytes(message);
                var arraySegment = new ArraySegment<byte>(bytes);
                await webSocket.SendAsync(arraySegment, WebSocketMessageType.Text, true, CancellationToken.None);
                Thread.Sleep(2000); //sleeping so that we can see several messages are sent
            }

            await webSocket.SendAsync(new ArraySegment<byte>(null), WebSocketMessageType.Binary, false, CancellationToken.None);
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
