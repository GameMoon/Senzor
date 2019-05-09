using Microsoft.JSInterop;
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
        public CustomBlock(string type) : base(type) { }

        public async Task Init(IJSRuntime jsRunTime, HttpClient httpClient)
        {
            String path = "blazor:file:" + Type + ".json";
            String jsonString = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(path)).ReadToEnd();
           
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
