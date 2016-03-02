using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace ShoppingCart_MicroService.Cart
{
    class Cart : IMicroService
    {
        // Get message here

        // Grab string from message

        // Use case switch statements to perform CartActions

        // Hope for the best

        public void RecieveMessage(string sender, string senmessage, System.Collections.Generic.List<object> args)
        {
            switch (senmessage)
            {
                case "AddToCart":
                   try
                   {
                        // Find product by Id
                        // Add product to cartcollection
                        // Add quantity                   
                   }
                catch (Exception e)
                 {
                        Debug.WriteLine("This is the error: " + e + " and this is the inner exception: " + e.InnerException);
                        //if process fails return a fail message
                        SendMessage(sender, "fail", null);
                 }  
     
                    break;

                case "RemoveItem":
                    try
                    {

                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine("This is the error: " + e + " and this is the inner exception: " + e.InnerException);
                        //if process fails return a fail message
                        SendMessage(sender, "fail", null);
                    }

                    break;
            }
            throw new System.NotImplementedException();
        }
        public void SendMessage(string receiver, string recmessage, System.Collections.Generic.List<object> args)
        {
            throw new System.NotImplementedException();
        }

        
    }
}
