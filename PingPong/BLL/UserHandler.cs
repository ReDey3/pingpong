using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;


namespace BLL
{
    public class UserHandler
    {
        public async void HandleUser(Socket handler) 
        {
            string data = null;
            byte[] bytes = null;
            try
            {
                await Task.Run(() =>
                {
                    while (true)
                    {
                        bytes = new byte[1024];
                        int bytesRec = handler.Receive(bytes);
                        data += Encoding.ASCII.GetString(bytes, 0, bytesRec);

                        Console.WriteLine("Text received : {0}", data);
                        byte[] msg = Encoding.ASCII.GetBytes(data);
                        handler.Send(msg);
                        data = "";
                    }
                });
            }
            catch (SocketException e)
            {
                Console.WriteLine("User logged out.");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
