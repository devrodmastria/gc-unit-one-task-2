//author: Rod Mastria	
//date: Jan 2024
//topic: Lab 1, Task 2
//framework: dotNet 8

public class Program
{
    private static string playerName = "";
    private static int correctAnswers = 0;
    private static bool playerAgreement = false;
    private static List<string> playerResponses = new List<string>();

    const int HEADS = 1;
    const int TAILS = 0;

    public static void Main()

    {

        Console.WriteLine("--------------COIN FLIP CHALLENGE--------------");
        Console.WriteLine("-----------------------------------------------");

        DisplayPrompts();

        if (playerAgreement) StartGame();

        if (playerAgreement) DisplayResults();

    }

    private static void DisplayPrompts()
    {

        // Welcome
        Console.WriteLine("Welcome to the game! To begin, please tell me your name");

        playerName = Console.ReadLine();

        // assume player name is valid
        Console.WriteLine($"Hello {playerName}. Do you want to do the COIN FLIP CHALLENGE? Yes/No");
        string CR = Console.ReadLine(); // CR stands for Challenge Response
        
        if (CR != null && CR.ToLower().Contains("y"))
        {
            playerAgreement = true;
        } else
        {
            Console.WriteLine("What a shame! You're missing out.");
            Console.ReadLine(); // prevent console from closing too fast
        }

    }

    private static void StartGame() {

        Random rand = new Random(); // declare just once to reduce memory footprint.

        for (int i = 0; i < 5; i++)
        {
            int newFlip = rand.NextDouble() > 0.5 ? 1 : 0;
            Console.WriteLine("Heads or Tails?");
            string PR = Console.ReadLine(); // PR stands for Player Response

            if (PR != null)
            {
                playerResponses.Add(PR.ToString());

                if (PR.ToLower().Contains("h"))
                {
                    
                    if (newFlip == HEADS)
                    {
                        correctAnswers++;
                        Console.WriteLine("Correct!");
                    } else
                    {
                        Console.WriteLine("Nope");
                    }
                    Console.WriteLine(); // white space for better UX
                } else if (PR.ToLower().Contains("t"))
                {
                    if (newFlip == TAILS)
                    {
                        correctAnswers++;
                        Console.WriteLine("Correct!");
                    } else
                    {
                        Console.WriteLine("Nope");
                    }
                    Console.WriteLine();
                }

            } else
            {
                playerResponses.Add("No response");
            }

        }


    }

    private static void DisplayResults()
    {
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine($"Thank you {playerName}! You got a score of {correctAnswers * 100 /playerResponses.Count}%");

        Console.WriteLine();
        Console.WriteLine("-----------------------------------------------");

        Console.WriteLine();
        Console.WriteLine("Hit enter to close the game");
        Console.ReadLine();

    }

}