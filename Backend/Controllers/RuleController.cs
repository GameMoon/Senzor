using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blockly;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Backend.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class RuleController : ControllerBase
    {
        readonly INodeManager _nodeManager;
        public RuleController(INodeManager nodeManager)
        {
            _nodeManager = nodeManager;
        }  

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(JsonConvert.SerializeObject(_nodeManager.GetAllRules()));
        }

        [HttpPost]
        public ActionResult Post([FromBody]Rule newRule)
        {
            _nodeManager.AddRule(newRule);
            return Ok("rule added");
        }
        [HttpGet("delete/{index}")]
        public ActionResult Get(int index)
        {
            _nodeManager.DeleteRule(index);
            return Ok("rule deleted");
        }
    }
}