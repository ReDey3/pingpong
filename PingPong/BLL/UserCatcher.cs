using System;
using System.Net;
using System.Net.Sockets;

namespace BLL
{
    public class UserCatcher
    {
        private UserHandler _userHandler;

        public UserCatcher(UserHandler userHandler)
        {
            _userHandler = userHandler;
        }

        public async void WaitForNewUsers(Socket listener)
        {
            Console.WriteLine("Waiting for users");
            while (true)
            {
                Socket handler = listener.Accept();
                _userHandler.HandleUser(handler);
            }
        }
    }
}