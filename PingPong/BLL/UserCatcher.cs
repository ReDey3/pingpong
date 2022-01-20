using System;
using System.Net;
using System.Net.Sockets;
using Common.IO.Abstractions;
using Common;

namespace BLL
{
    public class UserCatcher
    {
        private UserHandler _userHandler;
        private IOutput<string> _output;

        public UserCatcher(UserHandler userHandler, IOutput<string> output)
        {
            _userHandler = userHandler;
            _output = output;
        }

        public async void WaitForNewUsers(INetWorkWrapper listener)
        {
            _output.Output("Waiting for users");
            
            while (true)
            {
                Socket handler = listener.Accept();
                _userHandler.HandleUser(handler);
            }
        }
    }
}