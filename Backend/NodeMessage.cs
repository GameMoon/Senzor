using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class NodeMessage
    {
        public string NodeID { get; set; }
        public string Command { get; set; }
        public byte[] Payload { get; set; }

        public NodeMessage(string nodeID,string command, byte[] payload)
        {
            NodeID = nodeID;
            Command = command;
            Payload = payload;
        }
        public static NodeMessage Parse(byte[] message)
        {
            NodeMessage nodeMessage = null;
            if (message[0] == '$' && message[message.Length - 3] == '*')
            {
                byte[] nodeid = new byte[17];
                byte[] command = new byte[4];
                byte[] payload = new byte[message.Length - command.Length - nodeid.Length - 6];

                int offset = 1;
                Array.Copy(message, offset, command, 0, 4);
                offset += command.Length + 1;
                Array.Copy(message, offset, nodeid, 0, nodeid.Length);
                offset += nodeid.Length + 1;
                Array.Copy(message, offset, payload, 0, payload.Length);

                nodeMessage = new NodeMessage(Encoding.ASCII.GetString(nodeid), Encoding.ASCII.GetString(command), payload);
            }
            return nodeMessage;
        }
    }
}
