using Newtonsoft.Json;
using Senzor.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Timers;

namespace Senzor
{
    public class NodeManager : INodeManager
    {
        Timer pollingTimer;
        List<Node> _nodes = new List<Node>();
        HttpClient _httpClient;
        Action updated;

        public NodeManager(HttpClient httpClient)
        {
            pollingTimer = new Timer(1000);
            pollingTimer.Elapsed += UpdateAsync;
            pollingTimer.AutoReset = true;
            pollingTimer.Enabled = true;
            _httpClient = httpClient;
            Console.WriteLine("Node manager");
            
        }

        public List<Node> GetAll()
        {
            return _nodes;
        }

        public async void UpdateAsync(Object source, ElapsedEventArgs e)
        {
            try { 
                string content = await _httpClient.GetStringAsync("http://localhost:5000/api/node");
                _nodes = JsonConvert.DeserializeObject<List<Node>>(content);
                updated.Invoke();
            }
            catch (Exception)
            {
                Console.WriteLine("Cant connect to backend");
            }
        }
        public void AddUpdateFunction(Action action)
        {
            updated += action;
        }
    }
}
