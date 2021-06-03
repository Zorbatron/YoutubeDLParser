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

            List<string> output = new List<string>();
            List<string> qualNum = new List<string>();
            List<string> qualType = new List<string>();
            List<string> qualResolution = new List<string>();

            while (!p.StandardOutput.EndOfStream)
            {
                output.Add(p.StandardOutput.ReadLine());
            }

            output.RemoveRange(0, 3);

            foreach (string text in output)
            {
                qualNum.Add(text.Remove(3));
            } 

            for (int x = 0; x < output.Count; x++)
            {
                string temp = output[x];
                temp = temp.Remove(0, 13);
                qualType.Add(temp.Remove(3));
            }

            for (int x = 0; x < output.Count; x++)
            {
                string temp = output[x];
                temp = temp.Remove(0, 24);
                qualResolution.Add(temp.Remove(8));
            }

            for (int x = 0; x < output.Count; x++)
            {
                Console.Write(qualNum[x]);
                Console.Write(" " + qualType[x]);
                Console.WriteLine(" " + qualResolution[x]);
            }

            Console.ReadLine();
        }
    }
}
