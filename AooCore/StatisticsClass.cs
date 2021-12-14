using System.Text.Json;
using System.Text;


namespace EgeBot
{
    internal class StatisticsData
    {
        public int Solved { get; set; }
        public int NotSolved { get; set; }
        public int TotalCount { get; set; }

    }

    internal class StatisticsClass
    {
        Dictionary<string, StatisticsData> _stats = new Dictionary<string, StatisticsData>();

        public StatisticsClass()
        {

        }

        ~StatisticsClass()
        {
            _stats.Clear();
        }

        public void LoadStatistics(string id)
        {
            _stats.Clear();

            var path = $"Statistics/{id}.json";
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path, Encoding.UTF8);
                _stats = JsonSerializer.Deserialize<Dictionary<string, StatisticsData>>(json);
            }
            else
            {
                _stats.Clear();
                _stats.Add("None", new StatisticsData() { TotalCount = 0, Solved = 0, NotSolved = 0 });
                WriteStatistics(id);
            }
        }

        public void WriteStatistics(string id)
        {
            var path = $"\\Statistics\\{id}.json";

            if (File.Exists(path))
            {
                var data = File.ReadAllText(path, Encoding.UTF8);
                Dictionary<string, StatisticsData> tempJson = JsonSerializer.Deserialize<Dictionary<string, StatisticsData>>(data);
                foreach (var item in _stats)
                {
                    if (tempJson.ContainsKey(item.Key))
                    {
                        tempJson[item.Key].Solved += item.Value.Solved;
                        tempJson[item.Key].NotSolved += item.Value.NotSolved;
                        tempJson[item.Key].TotalCount = tempJson[item.Key].Solved + tempJson[item.Key].NotSolved;
                    }
                    else
                    {
                        tempJson.Add(item.Key, item.Value);
                    }
                }
            }
            var json = JsonSerializer.Serialize(_stats);
            File.WriteAllText(path, json);
        }

        public void AddStatistics(string theme, StatisticsData data)
        {
            _stats.Add(theme, data);
        }
    }
}
