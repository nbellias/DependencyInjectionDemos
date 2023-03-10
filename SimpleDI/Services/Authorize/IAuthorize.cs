using SimpleDI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDI.Services.Authorize
{
    public interface IAuthorize
    {
        public Response<List<string>> IsAuthorized(dynamic userRequest);
    }
}
