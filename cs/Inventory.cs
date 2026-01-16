using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace AssetManager {
    public class Inventory
    {
        // public void Run()
        // {
        //    string path = Path.Combine(AppContext.BaseDirectory, "data.csv");
        //     Console.WriteLine($"Loading CSV from: {path}");


        //     if (!File.Exists(path))
        //     {
        //         Console.WriteLine("CSV file not found.");
        //         Thread.Sleep(2000);
        //         return;
        //     }

        //     try
        //     {
        //         var assets = File.ReadLines(path)
        //             .Select(line => line.Split(','))
        //             .ToDictionary(
        //                 data => data[0],
        //                 data => new Asset
        //                 {
        //                     Tag = data[0],
        //                     Model = data[1],
        //                     Serial = data[2],
        //                     Room = data[3],
        //                     Owner = data[4],
        //                     Status = data[5]
        //                 }
        //             );

        //         foreach (var asset in assets.Values)
        //         {
        //             Console.WriteLine($"{asset.Tag} | {asset.Owner} | {asset.Model} | {asset.Room} | {asset.Status}");
        //         }
        //         Thread.Sleep(2000);
        //     }
        //     catch (Exception e)
        //     {
        //         Console.WriteLine($"Error reading inventory: {e.Message}");
        //     }
        // }

        private static readonly string[] ExpectedHeader =
        {
            "tag", "model", "serial", "room", "name", "status"
        };

        private void CreateEmptyCsv(string path)
        {
            string headerLine = string.Join(",", ExpectedHeader);
            File.WriteAllText(path, headerLine + Environment.NewLine);
        }

        private bool HeaderIsValid(string headerLine)
        {
            var actualHeader = headerLine
                .Split(',')
                .Select(h => h.Trim().ToLower())
                .ToArray();

            return actualHeader.SequenceEqual(ExpectedHeader);
        }

        public void Run()
        {
            string dataDir = Path.Combine(AppContext.BaseDirectory, "data");
            Directory.CreateDirectory(dataDir);

            string path = Path.Combine(dataDir, "data.csv");

            if (!File.Exists(path))
            {
                Console.WriteLine("CSV not found. Creating new file...");
                CreateEmptyCsv(path);
                Thread.Sleep(1500);
            }
            Console.WriteLine($"Loading CSV from: {path}");

            try
            {

                var lines = File.ReadAllLines(path);

                // If file exists but is empty or malformed, recreate it
                if (lines.Length == 0 || !HeaderIsValid(lines[0]))
                {
                    Console.WriteLine("CSV format invalid. Recreating file...");
                    CreateEmptyCsv(path);
                    Thread.Sleep(1500);
                    lines = File.ReadAllLines(path);
                }

                // If there's only a header, inventory is empty
                if (lines.Length == 1)
                {
                    Console.WriteLine("Inventory is empty.");
                    Thread.Sleep(1500);
                    return;
                }

                var assets = lines
                    .Skip(1)
                    .Select((line, index) => new { line, index })
                    .Select(x => x.line.Split(','))
                    .Where(data => data.Length == ExpectedHeader.Length)
                    .ToDictionary(
                        data => data[0],
                        data => new Asset
                        {
                            Tag = data[0],
                            Model = data[1],
                            Serial = data[2],
                            Room = data[3],
                            Owner = data[4],
                            Status = data[5]
                        }
                    );

                foreach (var asset in assets.Values)
                {
                    Console.WriteLine(
                        $"{asset.Tag} | {asset.Owner} | {asset.Model} | {asset.Room} | {asset.Status}"
                    );
                }

                Thread.Sleep(2000);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error reading inventory: {e.Message}");
                Thread.Sleep(2000);
            }
        }

    }
}