using System;
using System.IO;

namespace ConsoleApp1.Utilities
{
    public class Files
    {
        private string PathFile = Path.Combine(Directory.GetCurrentDirectory(), "answer.json");

        public void Save(string json)
        {
            File.WriteAllText(PathFile, json);
        }

        public string Get()
        {
            var json = File.ReadAllText(PathFile);
            return json;
        }

        public byte[] ConvertFileInBytes()
        {
            return File.ReadAllBytes(PathFile);
        }
    }
}
