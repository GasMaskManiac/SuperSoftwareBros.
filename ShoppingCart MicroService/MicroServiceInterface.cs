using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart_MicroService
{
    public interface IMicroService
    {
        
        void RecieveMessage(string sender, string senmessage, List<object> args);
        //Recieve Message
        //Recieves Message from Rabbit MQ
        //Handles the request Appropriately
        //assigns arguments
        
        void SendMessage(string receiver, string recmessage, List<object> args);
        //Send Message
        //Sends Message to Rabbit MQ

        
        
    }
}
