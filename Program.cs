// Напишите приложение, конвертирующее произвольный JSON в XML. Используйте JsonDocument.
using System.Xml;
using Newtonsoft.Json;

Console.Clear();
string targetData = FileCopyToString();
//Console.WriteLine(targetData);
JsonToXml(targetData);



static string FileCopyToString()
{
    string currPath = Directory.GetCurrentDirectory();
    string fileContent = "";
    string[] files = Directory.GetFiles(currPath, "*.json");//try to find all .json files in the current folder
    if (files.Length == 0)
    {
        Console.WriteLine("There are no any .json files in the current folder. Add at least one .json file and try again.");
    }
    else
    {
        using (StreamReader sr = new StreamReader(files[0]))
        {
            fileContent = sr.ReadToEnd();
        }
    }
    return fileContent;
}

static void JsonToXml(string data)
{
    XmlDocument docXml = (XmlDocument)JsonConvert.DeserializeXmlNode(data);
    docXml.Save(Console.Out);
}