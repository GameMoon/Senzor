using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodeController : ControllerBase
    {
        readonly INodeManager _nodeManager;
        readonly IUDPSocket _udpSocket;

        public NodeController(INodeManager nodeManager, IUDPSocket udpSocket)
        {
            _nodeManager = nodeManager;
            _udpSocket = udpSocket;
        }

        // GET api/node
        [HttpGet]
        public ActionResult<int> Get()
        {
            //return new string[] { "value1", "value2" };
            _udpSocket.Send("test");
            return _nodeManager.GetAll().Count;
        }

       
        // GET api/node/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/node
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/node/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/node/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
