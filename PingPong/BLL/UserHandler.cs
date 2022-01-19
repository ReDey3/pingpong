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
        private UserInputCatcher<string> _inputCatcher;

        public UserHandler(UserInputCatcher<string> inputCatcher)
        {
            _inputCatcher = inputCatcher;
        }

        public async void HandleUser(Socket handler) 
        {
            Console.WriteLine("New user logged.");
            string data = null;
            byte[] bytes = null;

            try
            {
                await Task.Run(() =>
                {
                    while (true)
                    {
                        _inputCatcher.GetUserInput(handler);
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
