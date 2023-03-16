using NLog.Fluent;
using SimpleDI.Models;
using SimpleDI.Services.Authorize;
using SimpleDI.Services.WriteLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleDI.Services.Authenticate
{
    public class Authenticate : IAuthenticate
    {
        private readonly IWriteLog _log;
        private readonly List<dynamic> userDatabase;

        public Authenticate(IWriteLog log)
        {
            _log = log;
            userDatabase = new List<dynamic>()
            {
                new
                {
                    UserName = "nbellias",
                    PassWord = "Password1",
                    Group = "Admin"
                },
                new
                {
                    UserName = "jdoe",
                    PassWord = "Password2",
                    Group = "Users"
                }
            };
        }

        public Response<dynamic> IsAuthenticated(Request userAuthenticationRequest)
        {
            var response = new Response<dynamic>();
            response.Data = null;
            response.Success = false;

            if (userAuthenticationRequest.Data != null)
            {
                response.Message = $"User {userAuthenticationRequest.Data.username} could not be authenticated";

                foreach (dynamic item in userDatabase)
                {
                    if (item.UserName == userAuthenticationRequest.Data.username &&
                        item.PassWord == userAuthenticationRequest.Data.password)
                    {
                        response.Data = new
                        {
                            user = item.UserName,
                            group = item.Group
                        };
                        response.Success = true;
                        response.Message = $"User {userAuthenticationRequest.Data.username} authenticated";

                        break;
                    }
                }
                _log.WriteLogMessage(response.Message);
            }

            return response;
        }

    }

}
