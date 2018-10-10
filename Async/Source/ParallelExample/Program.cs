using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelFlip
{
    class Program
    {
        static void Main()
        {
            ParallelProcessing();
        }

        private static void ParallelProcessing()
        {
            // Quelle und mehr Details zu diesem Beispiel: http://msdn.microsoft.com/de-de/library/dd460720.aspx
            string[] files = Directory.GetFiles(@"C:\Users\Public\Pictures\Sample Pictures", "*.jpg");
            string newDir = @"C:\Users\Public\Pictures\Sample Pictures\Modified2";
            Directory.CreateDirectory(newDir);

            Parallel.ForEach(files, currentFile =>
            {
                Flip(newDir, currentFile);
            }
            );
        }

        private static void SequentialProcessing()
        {
            string[] files = Directory.GetFiles(@"C:\Users\Public\Pictures\Sample Pictures", "*.jpg");
            string newDir = @"C:\Users\Public\Pictures\Sample Pictures\Modified1";
            Directory.CreateDirectory(newDir);

            foreach (var currentFile in files)
            {
                Flip(newDir, currentFile);
            }
        }


        private static void Flip(string newDir, string currentFile)
        {
            string filename = Path.GetFileName(currentFile);
            Bitmap bitmap = new Bitmap(currentFile);
            bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
            bitmap.Save(Path.Combine(newDir, filename));
            
        }
        private static void Benchmark()
        {
            double pTime;
            double sTime;
            double speedup;
            double effizenz;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            SequentialProcessing();
            sw.Stop();
            Console.WriteLine("Sequentiell: " + sw.Elapsed);
            sTime = sw.ElapsedMilliseconds;
            sw.Restart();
            ParallelProcessing();
            sw.Stop();
            Console.WriteLine("Parallel: " + sw.Elapsed);
            pTime = sw.ElapsedMilliseconds;

            // Speedup = T_Sequentiell/T_Parallel
            speedup = sTime / pTime;

            // Effizienz = Speedup / #Kerne
            effizenz = speedup / 4;
            Console.WriteLine("Speedup: " + speedup);
            Console.WriteLine("Effizienz: " + effizenz);
            Console.Read();
        }

    }
}
