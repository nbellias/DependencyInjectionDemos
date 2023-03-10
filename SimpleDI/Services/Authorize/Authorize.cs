using SimpleDI.Models;
using SimpleDI.Services.WriteLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDI.Services.Authorize
{
    public class Authorize : IAuthorize
    {
        private readonly IWriteLog _log;
        private readonly List<string> allServices;

        public Authorize(IWriteLog log)
        {
            _log = log;
            allServices = new List<string>()
            {
                "SendSMS",
                "SendEmail"
            };
        }

        public Response<List<string>> IsAuthorized(dynamic userRequest)
        {
            Response<List<string>> response = new Response<List<string>>
            {
                Data = allServices,
                Success = true,
                Message = $"Succesfull authorization for authenticated user {userRequest.Data.user}"
            };

            if (userRequest.Data.group != "Admin")
            {
                response = new Response<List<string>>
                {
                    Data = null,
                    Success = false,
                    Message = $"Authorization cannot be given to user {userRequest.Data.user}"
                };
            }

            _log.WriteLogMessage(response.Message);
            return response;
        }
    }

}
