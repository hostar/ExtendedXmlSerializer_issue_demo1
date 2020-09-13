using System;
using System.IO;
using System.Xml;
using AnotherNamespace;
using ExtendedXmlSerializer;
using ExtendedXmlSerializer.Configuration;

namespace RunMe
{
    class Program
    {
        static void Main()
        {
            var serializer = new ConfigurationContainer()
                                                         .EnableImplicitTyping(typeof(SampleModel))
                                                         //.EnableReferences()
                                                         .Create();

            Console.WriteLine($"input1");
            DeserializeTest(serializer, "input1.xml");
            Console.WriteLine($"---------------------------------");

            Console.WriteLine($"input2");
            DeserializeTest(serializer, "input2.xml");

            Console.WriteLine("LastName should be empty instead of new line.");
            Console.WriteLine($"Press enter to exit.");
            Console.ReadLine();
        }

        private static void DeserializeTest(IExtendedXmlSerializer serializer, string fname)
        {
            string fileContent = File.ReadAllText(Directory.GetCurrentDirectory() + @$"\Data\{fname}");

            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(fileContent);
            writer.Flush();
            stream.Position = 0;

            using XmlTextReader reader = new XmlTextReader(stream) { Normalization = false };
            var result = (SampleModel)serializer.Deserialize(reader);

            Console.WriteLine($"{nameof(result.ListOfItems)} count: {result.ListOfItems.Count}");
            Console.WriteLine($"{nameof(result.LastName)}: {result.LastName}");
        }
    }
}
