using System.Text.Json;

namespace EgeBot
{
    internal class QuestionClass
    {
        public string Theme { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string[] Cards { get; set; }
        public string FilePath { get; set; }
        public string Explanation { get; set; }
    }

    internal class QuestionGenerator
    {
        static List<QuestionClass> _questions = new List<QuestionClass>();

        Random _rand = new Random();

        public QuestionGenerator()
        {
            LoadQuestions();
        }

        ~QuestionGenerator()
        {
            _questions.Clear();
        }

        protected string ChooseDataBase()
        {
            var count = Directory.GetFiles("Questions/");

            return count[_rand.Next(count.Length)];
        }

        public void LoadQuestions()
        {
            _questions.Clear();

            var json = File.ReadAllText(ChooseDataBase(), System.Text.Encoding.UTF8);

            Dictionary<string, QuestionClass> deserialization = JsonSerializer.Deserialize<Dictionary<string, QuestionClass>>(json);

            foreach (var item in deserialization)
            {
                _questions.Add(item.Value);
            }
        }

        public int Count()
        {
            return _questions.Count;
        }

        public List<QuestionClass> GetQuestions()
        {
            return _questions;
        }

        public QuestionClass CreateQuestion()
        {
            LoadQuestions();

            return _questions[_rand.Next(_questions.Count)];
        }
    }
}
