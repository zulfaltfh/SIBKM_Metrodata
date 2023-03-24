using System;

namespace Tugas_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Video vid01 = new Video("RecordingClass001","20-03-2022",".mp4",2,120);
            vid01.Ukuran = 1;

            vid01.Rincian();
            vid01.Play();
            vid01.Pause();

            Image img01 = new Image("IMG_20220711", "11-07-2022", ".jpg", 4, "1080p");
            img01.Rincian();
        }
    }
}

