using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Text;
// using Newtonsoft.Json;


class JsonData
{
        private List<Task> _tasks = new List<Task>();

        string jsonTask = "task.json";
        // JsonSerializerSettings jsonSettings = new JsonSerializerSettings { DateFormatString = "dd.MM.yyyy", Formatting = Formatting.Indented};
        JsonSerializerOptions options1 = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true,
                Converters = { new DateTimeConverter("dd.MM.yyyy") }
            };


        public List<Task> GetProducts()
        {
            if(File.Exists(jsonTask))
            {
                string json = File.ReadAllText(jsonTask, Encoding.UTF8);
                if(json != "")
                    _tasks = JsonSerializer.Deserialize<List<Task>>(json, options1);
                return _tasks;

                // string json = File.ReadAllText(jsonTask, Encoding.UTF8);
                // if(json != "")
                //     _tasks = JsonConvert.DeserializeObject<List<Task>>(json, jsonSettings);
                // return _tasks;
            }
            else
            {
                File.Create(jsonTask).Close();
                return _tasks;
            }
        }

        public void SerializeTasks(List<Task> tasks)
        {
            var  json = JsonSerializer.Serialize(tasks, options1);
            File.WriteAllText(jsonTask, json);
            // string json = JsonConvert.SerializeObject(tasks, jsonSettings);
            // File.WriteAllText(jsonTask, json, Encoding.UTF8);
        }
}