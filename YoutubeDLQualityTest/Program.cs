using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace YoutubeDLQualityTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Process p = new Process();
            p.StartInfo.FileName = "youtube-dl.exe";
            p.StartInfo.Arguments = "-F https://www.youtube.com/watch?v=4sRDppM6cj4";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();

            int x = 0;

            List<string> output = new List<string>();

            while (!p.StandardOutput.EndOfStream)
            {
                output.Add(p.StandardOutput.ReadLine());
            }

            output.RemoveRange(0, 3);

            foreach (string text in output)
            {
                Console.WriteLine($"Length is {x}: " + text); 
                
                x += 1;
            }

            Console.ReadLine();
        }
    }
}
