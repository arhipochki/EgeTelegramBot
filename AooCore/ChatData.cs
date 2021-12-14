using System.Diagnostics;

namespace EgeBot
{
    internal class ChatData
    {
        public long chatId;
        public bool startTest;
        public bool oneQuestion;
        public int score;
        public int question;

        public List<int> explanations;

        public Stopwatch stopwatch;

        public QuestionGenerator qG;
        public List<QuestionClass> questions;
        public StatisticsClass stats;

        public ChatData(long chatId)
        {
            this.chatId = chatId;
            this.startTest = false;
            this.oneQuestion = false;
            this.score = 0;
            this.question = 1;
            this.explanations = new List<int>();
            this.stopwatch = new Stopwatch();
            this.qG = new QuestionGenerator();
            this.questions = qG.GetQuestions();
            this.stats = new StatisticsClass();
        }

        ~ChatData()
        {
            this.explanations.Clear();
            this.questions.Clear();
        }
    }
}
