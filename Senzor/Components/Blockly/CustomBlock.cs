﻿using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Senzor.Components.Blockly
{
    public class CustomBlock : Block
    {
        public CustomBlock(string name) : base(name) { }

        public async Task Init(IJSRuntime jsRunTime, HttpClient httpClient)
        {
            String jsonString = await httpClient.GetStringAsync("/js/blockly_custom_blocks/" + Name + ".json");
            Console.WriteLine("customblock http end");
            await jsRunTime.InvokeAsync<bool>(
                "loadBlock",
                Name,
                jsonString
            );
        }

    }
  
   
}