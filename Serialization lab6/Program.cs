using System.Reflection.PortableExecutable;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;


namespace Serialization_lab6
{
    internal class Program
    {
        static void Main(string[] args)
        {
#pragma warning disable SYSLIB0011

            //Object for event 1
            Event event1 = new Event(1, "Calgary");

            //Creating file path for new files
            string baseDir =Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string pathTXT = baseDir + "/event.txt";
            string pathJSON = baseDir + "/event,json";
            string pathBIN = baseDir + "/event.bin";

            //Calling for binary serializaiton and deserialization
            SerializeEvent(event1, pathBIN);
            deserializationEvent(pathBIN);

            //List of objects for Event
            List<Event> event2 = new List<Event>
            {
            new Event(10,"Canada"),
            new Event(8, "Manitoba"),
            new Event(2, "Toronto"),
            new Event(4, "Vancouver"),
            };
            //Calls JSON serialization and deserialization with its respective argument
            serializeJSON(event2, pathJSON);
            deserializationJSON(pathJSON);

            //Calls ReadFromFile method
            ReadFromFile(pathTXT);

        }
        //Serialization of binary
        private static void SerializeEvent(Event events, string pathBIN)
        {
            BinaryFormatter binary = new BinaryFormatter();
            using (FileStream sr = new FileStream(pathBIN, FileMode.Create))
            {
                binary.Serialize(sr, events);
            }
        }
        //Desiarilization of a binary Fille
        private static void deserializationEvent(string pathBIN)
        {
            BinaryFormatter binary = new BinaryFormatter();
            using (FileStream fs = new FileStream(pathBIN, FileMode.Open))
            {
                Event e1 = (Event)binary.Deserialize(fs);
                Console.WriteLine(e1.eventNumeber);
                Console.WriteLine(e1.location);
            }
        }

        //Creating a serialization for JSON list of objects
        private static void serializeJSON(List<Event> events, string pathJSON)
        {
            string Json = JsonSerializer.Serialize(events);
            File.WriteAllText(pathJSON, Json);
        }
        //Desiarilization for JSON
        private static void deserializationJSON(string pathJSON)
        {
            List<Event> e = JsonSerializer.Deserialize<List<Event>>(File.ReadAllText(pathJSON));
            foreach (var item in e)
            {
                Console.WriteLine($"Numeber of event: {item.eventNumeber} Location: {item.location}");
            }

        }

        //Method that writes and read the First,Middle, and Last letter of the word in the text file
        private static void ReadFromFile(string eventTXT)
        {
            //Writes "Hackathon into the text file
            using (StreamWriter writer = new StreamWriter(eventTXT))
            {
                writer.Write("Hackathon");

            }
            //Reads through the text file to display the word that is inside the Text file
            using(StreamReader readText = new StreamReader(eventTXT))
            {
                Console.WriteLine("Tech Competition");

                Console.WriteLine($"In word: {readText.ReadToEnd()}");
            }

            //Identifies the first, Middle, and Last letter of the word using Seek method
            using (FileStream reader = new FileStream(eventTXT,FileMode.Open))
            {

                reader.Seek(0, SeekOrigin.Begin);
                char firstLetter = (char)reader.ReadByte();
                Console.WriteLine($"First Character: '{ firstLetter}'");


                reader.Seek((reader.Length / 2), SeekOrigin.Begin);
                char middleLetter = (char)reader.ReadByte();
                Console.WriteLine($"Middle Character: '{middleLetter}'");


                reader.Seek(-1, SeekOrigin.End);
                char lastLetter = (char)reader.ReadByte();
                Console.WriteLine($"Last Character: '{lastLetter}'");


            }
        }

    }

}
