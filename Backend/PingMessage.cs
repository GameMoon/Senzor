﻿using Senzor.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend
{
    public class PingMessage : NodeMessage
    {
        public PingMessage(string nodeID = "FF:FF:FF:FF:FF:FF", byte[] payload = null) : base(nodeID, "PING", payload)
        {
        }

        public override void Process(INodeManager nodeManager)
        {
            Node newNode = nodeManager.GetNode(NodeID);//new Node(NodeID);
            if (newNode == null)
            {
                newNode = new Node(NodeID);
                nodeManager.AddNode(newNode);
            }

            for (int index = 0; index < Payload.Length; index++)
            {
                newNode.SetInput(index, Payload[index]);
            }
            
        }
    }
}
