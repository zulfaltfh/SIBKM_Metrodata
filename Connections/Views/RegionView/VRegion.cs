﻿using System;
using Connections.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connections.Views.RegionView
{
    public class VRegion
    {
        public void GetAll(List<Region> regions)
        {
            foreach (var  region in regions)
            {
                Console.WriteLine("=================");
                Console.WriteLine("Id: " + region.id);
                Console.WriteLine("Name: " + region.name);
            }
        }

        public void GetById(Region region)
        {
            Console.WriteLine("=================");
            Console.WriteLine("Id: " + region.id);
            Console.WriteLine("Name: " + region.name);
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
