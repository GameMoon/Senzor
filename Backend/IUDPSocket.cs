using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend
{
    public interface IUDPSocket
    {
        public void Send(String message);
        public List<byte[]> GetMessages();
    }
}
