/*
Leander Norberg
leno2003@student.miun.se
Programmering i C#.NET (DT071G)
Moment 4

Notes: Insufficient training data. Typically leans positive.
*/

namespace Moment_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool makeEvaluation = true;

            while (makeEvaluation)
            {
                Console.Clear();
                
                string input = getUserInput("Make a statement to be evaluated by sentiment:");

                string sentiment = evaluateSentiment(input);
                Console.WriteLine($"Sentiment: {sentiment}");

                makeEvaluation = askToContinue();
            }
        }

        private static string getUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        private static string evaluateSentiment(string input)
        {
            var sampleData = new SentimentModel.ModelInput() { Col0 = input };

            var result = SentimentModel.Predict(sampleData);

            return result.PredictedLabel == 1 ? "Positive" : "Negative";
        }

        private static bool askToContinue()
        {
            while (true)
            {
                string response = getUserInput("Make another statement? (y/n)");

                if (response?.ToLower() == "y")
                {
                    return true;
                }
                else if (response?.ToLower() == "n")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                }
            }
        }
    }
}
