using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tugas_OOP
{
    public class Video : File
    {
        public int Durasi { get; set; }

        public Video(string nama, string tanggal, string tipe, int ukuran, int durasi) : base(nama, tanggal, tipe, ukuran)
        {
            Durasi = durasi;
        }

        public void Play()
        {
            Console.WriteLine($"\nVideo {Nama}{Tipe} dimainkan");
        }

        public void Pause()
        {
            Console.WriteLine($"\nVideo {Nama}{Tipe} dihentikan");
        }

        public override void Rincian()
        {
            base.Rincian();
            Console.WriteLine();
            Console.WriteLine("Informasi Detail");
            Console.WriteLine("Durasi : " + Durasi + " detik");
            Console.WriteLine("Ukuran : " + Ukuran + " MB");
        }
    }
}
