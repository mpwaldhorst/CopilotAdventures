public class Forest
{
    public string State { get; set; } = "Normal";
}

public enum DanceMove
{
    Twirl,
    Leap,
    Spin
}

public class Creature
{
    public DanceMove DanceMove { get; set; }
}

public class Program
{
    public static void Main(string[] args)
    {
        var forest = new Forest();
        var lox = new Creature();
        var drako = new Creature();

        var random = new Random();

        while (true)
        {
            // Drako performs a random dance move
            drako.DanceMove = (DanceMove)random.Next(0, 3);
            Console.WriteLine($"Drako is doing a {drako.DanceMove}");

            Console.WriteLine("Enter the dance move for Lox (Twirl, Leap, Spin):");
            var input = Console.ReadLine();

            if (Enum.TryParse(input.Trim(), out DanceMove parsedMove))
            {
                lox.DanceMove = parsedMove;
            }
            else
            {
                Console.WriteLine("Invalid move. Please enter Twirl, Leap, or Spin.");
                continue;
            }

            var moves = (lox.DanceMove, drako.DanceMove);

            if (moves == (DanceMove.Twirl, DanceMove.Twirl))
            {
                forest.State = "Fireflies light up the forest";
            }
            else if (moves == (DanceMove.Leap, DanceMove.Spin))
            {
                forest.State = "Gentle rain starts falling";
            }
            else if (moves == (DanceMove.Spin, DanceMove.Leap))
            {
                forest.State = "A rainbow appears in the sky";
            }

            Console.WriteLine($"The current state of the forest is: {forest.State}");

            Console.WriteLine("Do you want to play another round? (yes/no)");
            var playAgain = Console.ReadLine().Trim().ToLower();

            if (playAgain != "yes")
            {
                Console.WriteLine($"The final state of the forest is: {forest.State}");
                break;
            }
        }
    }
}