using SimpleDI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDI.Services.Authenticate
{
    public interface IAuthenticate
    {
        public Response<dynamic> IsAuthenticated(Request userAuthenticationRequest);
    }
}
