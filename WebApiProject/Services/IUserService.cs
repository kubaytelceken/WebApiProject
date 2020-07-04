using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProject.Services
{
    public interface IUserService
    {
        string GetName(string name);
    }
}
