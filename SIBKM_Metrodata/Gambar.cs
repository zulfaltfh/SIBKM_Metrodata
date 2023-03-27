using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tugas_OOP
{
    public class Image : File
    {
        public string Resolusi { get; set; }
        public Image(string nama, string tanggal, string tipe, int ukuran, string resolusi) : base(nama, tanggal, tipe, ukuran)
        {
            Console.WriteLine("\nIni File Gambar");
            Resolusi = resolusi;
        }

        public override void Rincian()
        {
            base.Rincian();
            Console.WriteLine();
            Console.WriteLine("Informasi Detail");
            Console.WriteLine("Resolusi : " + Resolusi);
            Console.WriteLine("Ukuran : " + Ukuran + " MB");
        }
    }
}
