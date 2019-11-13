using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public interface IParksSQLDAO
    {
        IList<Park> GetParks();
    }
}
