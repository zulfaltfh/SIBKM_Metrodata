using Connections.Models;
using Connections.Dbconnect;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connections.Repositories.Interfaces
{
    public interface ICountryRepository
    {
        List<Country> GetAll();
        Country GetById(string id);
        int Insert(Country countries);
        int Update(Country countries);
        int Delete(string id);
    }
}
