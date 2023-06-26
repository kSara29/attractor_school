using Exam_4;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Exam_4
{
    public class JsonData
    {
        private List<Cat> _cats = new List<Cat>();

        string jsonPath = Path.Combine("..", "..", "cats.json");
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            WriteIndented = true,
            Converters = { new DateConverter() }
        };


        public List<Cat> GetProducts()
        {
            if (File.Exists(jsonPath))
            {
                string json = File.ReadAllText(jsonPath, Encoding.UTF8);
                if (json != "")
                    _cats = JsonSerializer.Deserialize<List<Cat>>(json, options);
                return _cats;
            }
            else
            {
                File.Create(jsonPath).Close();
                return _cats;
            }
        }

        public void SerializeTasks(List<Cat> tasks)
        {
            var json = JsonSerializer.Serialize(tasks, options);
            File.WriteAllText(jsonPath, json);
        }
    }
}
