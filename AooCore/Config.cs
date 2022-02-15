namespace EgeBot
{
    internal class Config
    {
        static public string Token = "";
        static public string FilePath = "Questions/";

        static public void SetConfig(string[] args)
        {
            for (int i = 0; i < args.Length; i += 2)
            {
                if (args[i] == "-fp")
                {
                    FilePath = args[i + 1];
                }
                else if (args[i] == "-t")
                {
                    Token = args[i + 1];
                }
            }

            //Console.WriteLine($"{FilePath}, {Token}");
        }
    }
}
