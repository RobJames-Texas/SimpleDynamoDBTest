using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace DynamoDBFormulaTester
{
    class Program
    {
        public static Random random = new Random();

        static int correct = 0;

        static List<CapaticyUnitType> missed = new List<CapaticyUnitType>();

        static void Main(string[] args)
        {
            int numberOfQuestions = 10;
            if (args.Length > 0)
            {
                int.TryParse(args[0], out numberOfQuestions);
            }
            if (numberOfQuestions < 1)
            {
                Console.WriteLine("Please enter a valid number larger than 0.");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                Console.WriteLine("\nNO! NOT THAT ONE!");
                Console.WriteLine("WHAT HAZ YOU DOENS!");
                return;
            }
            Console.WriteLine("DynamoDB Forumla tester.");

            for (int i = 0; i < numberOfQuestions; i++)
            {
                var question = RandomQuestion();
                Console.WriteLine($"Questions Remaining: {numberOfQuestions - i}");
                Test(question);
                Console.WriteLine("\n************************\n");
            }
            decimal percent = (decimal)correct / (decimal)numberOfQuestions;
            Console.WriteLine($"You scored {percent * 100}%");
            Console.WriteLine($"With {correct} correct out of {numberOfQuestions} total questions.");
            if (correct < numberOfQuestions)
            {
                Console.WriteLine("\nItems incorrect:");
                Console.WriteLine($"\t{missed.Where(x => x.Equals(CapaticyUnitType.Write)).Count()} Write questions.");
                Console.WriteLine($"\t{missed.Where(x => x.Equals(CapaticyUnitType.StronglyConsistentRead)).Count()} Strongly Consistent Read questions.");
                Console.WriteLine($"\t{missed.Where(x => x.Equals(CapaticyUnitType.EventuallyConsistentRead)).Count()} Eventually Consistent Read questions.");
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            Console.WriteLine();
        }

        static void Test(IDynamoDbFormula question)
        {
            Console.WriteLine($"Calculate the Capacity Units required to {question.Name} {question.NumberOfObjects} objects, {question.KB}KB each.");
            var answerString = Console.ReadLine();
            decimal.TryParse(answerString, out decimal answer);
            var expected = question.Answer();
            if (answer == expected)
            {
                correct++;
                Console.WriteLine("Correct!");
            }
            else
            {
                missed.Add(question.CapaticyUnitType);
                Console.WriteLine($"Incorrect, expected: {expected}");
            }
        }

        static IDynamoDbFormula RandomQuestion()
        {
            IDynamoDbFormula question;
            int cu = random.Next(0, 3); // 3 is not included
            decimal kb = random.Next(1, 320) / 10;
            int numOjects = random.Next(1, 10);
            switch (cu)
            {
                case (1):
                    question = new StronglyConsistentRead(kb, numOjects);
                    break;
                case (2):
                    question = new EventuallyConsistentRead(kb, numOjects);
                    break;
                default:
                    question = new Write(kb, numOjects);
                    break;
            }
            return question;
        }
    }
}
