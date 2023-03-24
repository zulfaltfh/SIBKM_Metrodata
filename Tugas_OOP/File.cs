using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tugas_OOP
{
    public class File
    {
        public string Nama { get; set; }
        public string Tanggal { get; set; }
        public string Tipe { get; set; }
        public int Ukuran { get; set; }


        public File(string nama, string tanggal, string tipe, int ukuran)
        {
            Nama = nama;
            Tanggal = tanggal;
            Tipe = tipe;
            Ukuran = ukuran;
        }

        public virtual void Rincian()
        {
            Console.WriteLine("Rincian dari file");
            Console.WriteLine("Nama File : " + Nama + Tipe);
            Console.WriteLine("Tanggal : " + Tanggal);
        }
    }
}
