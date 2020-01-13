using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalFiles.Model
{
    public class ModelFuncFiles
    {
        private string path = @"C:\";
        Random random = new Random();

        Queue<string> texts = new Queue<string>();

        public string Path { get => path; set => path = value; }

        public void ClearPath()
        {
            Parallel.ForEach(Directory.EnumerateDirectories(Path),  x => Directory.Delete(x));
            Parallel.ForEach(Directory.EnumerateFiles(Path), x => File.Delete(x));
        }

        public void FillPath()
        {
            Parallel.For(0, 1000, i => { try{ File.WriteAllText($@"{Path}\{i}.txt", $"{random.Next(1, 3)} {random.NextDouble() * random.Next(1, 10)} {random.NextDouble() * random.Next(1, 10)}"); } catch { } });            
        }
         
        public async void CalcPath()
        {
            var a = Directory.EnumerateFiles(Path);
            File.Create($@"{Path}\result.dat");
            await Task.Run(() =>
            {
                Parallel.ForEach(a, x =>
                {

                    var elements = new double[0];
                    try
                    {
                        elements = File.ReadAllText(x).Split(' ').Select(y => double.Parse(y)).ToArray();
                    }
                    catch { }
                    if (elements != null && elements.Length >= 3)
                        if (elements[0] < 1.5) texts.Enqueue($"{x} {(elements[1] * elements[2]).ToString()} {Environment.NewLine}");
                        else texts.Enqueue($"{x} {(elements[1] / elements[2]).ToString()} {Environment.NewLine}");
                });
            });

            await Task.Run(() => 
            {
                while(texts.Count != 0)
                {
                    File.AppendAllText($@"{Path}\result.dat", texts.Dequeue());
                }
            });
        }
    }
}
