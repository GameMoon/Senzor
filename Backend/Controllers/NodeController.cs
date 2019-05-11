using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        public ActionResult Get()
        {
            return Ok(JsonConvert.SerializeObject(_nodeManager.GetAll()));
        }

       
        // GET api/node/write/nodeid/pin/state
        [HttpGet("write/{nodeid}/{pin}/{state}")]
        public ActionResult Get(string nodeid,int pin,int state)
        {
            _nodeManager.SendMessage(WriteMessage.SetPin(nodeid, pin, state));
            return Ok("message sent");
        }


    }
}
