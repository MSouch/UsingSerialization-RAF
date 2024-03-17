using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace UsingSerialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Get the parent directory of the parent directory of the current directory
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            // Create a single event object
            Event singleEvent = new Event()
            {
                EventNum = 1,
                Location = "Calgary"
            };

            // Define file paths for text and JSON serialization
            string pathtxt = Path.Combine(path, "Event.txt");
            string pathJSON = Path.Combine(path, "Event.json");

            // Serialize singleEvent object to text file
            SerializeEvent(pathtxt, singleEvent);
            // Deserialize from the text file
            DeSerializingEvent(pathtxt);

            // Create a list of Event objects
            List<Event> events = new List<Event>
            {
                new Event { EventNum = 1, Location = "Calgary" },
                new Event { EventNum = 2, Location = "Vancouver" },
                new Event { EventNum = 3, Location = "Toronto" },
                new Event { EventNum = 4, Location = "Edmonton" }
            };

            // Serialize list of Event objects to JSON file
            SerializeToJsonFile(pathJSON, events);
            // Deserialize from the JSON file
            DeserializeFromJsonFile(pathJSON);

            // Call ReadFromFile method
            ReadFromFile();
        }

        // Serializing Event object to a text file
        public static void SerializeEvent(string path, Event e)
        {
            string txtstring = JsonSerializer.Serialize(e);
            File.WriteAllText(path, txtstring);
        }

        // Deserializing Event object from a text file
        private static void DeSerializingEvent(string path)
        {
            // Read the text file and deserialize it into an Event object
            Event e1 = JsonSerializer.Deserialize<Event>(File.ReadAllText(path));
            // Display Event properties
            Console.WriteLine($"{e1.EventNum}\n{e1.Location}");
            // Display additional information
            Console.WriteLine("Tech Competition");
        }

        // Serialize list of Event objects to a JSON file
        static void SerializeToJsonFile(string filePath, List<Event> events)
        {
            // Convert the list of events to JSON format and write it to a file
            string jsonString = JsonSerializer.Serialize(events);
            File.WriteAllText(filePath, jsonString);
        }

        // Deserialize list of Event objects from a JSON file
        static void DeserializeFromJsonFile(string filePath)
        {
            // Read JSON content from file and deserialize it into a list of Event objects
            List<Event> deserializedEvents = JsonSerializer.Deserialize<List<Event>>(File.ReadAllText(filePath));
            // Display properties of each Event object
            foreach (var evt in deserializedEvents)
            {
                Console.WriteLine($"{evt.EventNum} {evt.Location}");
            }
        }

        // Method to read from file, manipulate, and display specific characters
        static void ReadFromFile()
        {
            // Define the file path
            string filePath = "hackathon.txt";

            // Write "Hackathon" to the file
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write("Hackathon");
            }

            // Read file content into a string
            string fileContent;
            using (StreamReader fileReader = new StreamReader(filePath))
            {
                fileContent = fileReader.ReadToEnd();
            }

            // Extract first, middle, and last characters
            char firstChar = fileContent[0];
            char middleChar = fileContent[fileContent.Length / 2];
            char lastChar = fileContent[fileContent.Length - 1];

            // Display the characters
            Console.WriteLine($"In Word: {fileContent}");
            Console.WriteLine($"The First Character is: \"{firstChar}\"");
            Console.WriteLine($"The Middle Character is: \"{middleChar}\"");
            Console.WriteLine($"The Last Character is: \"{lastChar}\"");
        }
    }
}
