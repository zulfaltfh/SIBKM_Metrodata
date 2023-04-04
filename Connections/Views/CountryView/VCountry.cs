using Connections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connections.Views.CountryView
{
    public class VCountry
    {
        public void GetAll(List<Country> countries)
        {
            foreach (var country in countries)
            {
                Console.WriteLine("=================");
                Console.WriteLine("Id: " + country.id);
                Console.WriteLine("Name: " + country.name);
                Console.WriteLine("Region: " + country.region_id);
            }
        }

        public void GetById(Country countries)
        {
            Console.WriteLine("=================");
            Console.WriteLine("Id: " + countries.id);
            Console.WriteLine("Name: " + countries.name);
            Console.WriteLine("Region: " + countries.region_id);
        }

        public void Success(string message)
        {
            Console.WriteLine($"Data berhasil {message}");
        }

        public void Failure(string message)
        {
            Console.WriteLine($"Data gagal {message}");
        }

        public void DataNotFound()
        {
            Console.WriteLine("Sorry.. data tidak ditemukan!");
        }
    }
}
