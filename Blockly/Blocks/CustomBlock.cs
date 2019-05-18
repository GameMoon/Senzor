using Microsoft.JSInterop;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace Blockly.Blocks
{
    public abstract class CustomBlock : Block
    {
        protected List<string[]> _options = new List<string[]>();

        public CustomBlock(string type) : base(type) { }

        public async Task Init(IJSRuntime jsRunTime, HttpClient httpClient)
        {
            String path = "blazor:file:" + Type + ".json";
            String jsonString = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(path)).ReadToEnd();

            if(_options.Count > 0) {
                JObject jBlock = JObject.Parse(jsonString);
                jBlock["args0"][0]["options"] = JToken.FromObject(_options);
                jsonString = jBlock.ToString();        
            }

            await jsRunTime.InvokeAsync<bool>(
                "blocklyInterop.loadBlock",
                Type,
                jsonString
            );
        }
        public override void Accept(IBlockVisitor visitor)
        {
            visitor.Visit(this);
        }

    }
  
   
}
