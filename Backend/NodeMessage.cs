using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public abstract class NodeMessage
    {
        public string NodeID { get; set; }
        public string Command { get; set; }
        public byte[] Payload { get; set; }

        public NodeMessage(string nodeID, string command, byte[] payload)
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
                int payloadSize = message.Length - command.Length - nodeid.Length - 6;
                byte[] payload = new byte[message.Length - command.Length - nodeid.Length - 6];

                int offset = 1;
                Array.Copy(message, offset, command, 0, 4);
                offset += command.Length + 1;
                Array.Copy(message, offset, nodeid, 0, nodeid.Length);
                offset += nodeid.Length + 1;
                Array.Copy(message, offset, payload, 0, payload.Length);


                string nodeidStr = Encoding.ASCII.GetString(nodeid);
                string commandStr = Encoding.ASCII.GetString(command);

                if (commandStr == "READ")
                    nodeMessage = new ReadMessage(nodeidStr, payload);
                else if (commandStr == "LIST")
                    nodeMessage = new ListMessage(nodeidStr, payload);
                else if (commandStr == "PING")
                    nodeMessage = new PingMessage(nodeidStr, payload);
                else if (commandStr == "WRTE")
                    nodeMessage = new WriteMessage(nodeidStr, payload);
                else
                    throw new Exception("Command not found");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Cant parse");
            }
            return nodeMessage;
        }

        private string calculateCheckSum(string message)
        {
            int chksum = 0;
            foreach (char ch in message) {
                if (ch == '$') continue;
                else if (ch == '*') break;
                else chksum ^= ch;
            }
            return chksum.ToString("X2");
        }
        public string CreateString()
        {
            string outputStr = "$" + Command + "," + NodeID + ",";
            if (Payload != null && Payload.Length > 0)
            {
                foreach (char ch in Payload) outputStr += ch;
            }
            outputStr += "*";
            outputStr += calculateCheckSum(outputStr);

            return outputStr;
        }
        public abstract void Process(INodeManager nodeManager);
    }
}
