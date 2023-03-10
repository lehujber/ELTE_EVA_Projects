using Hunt_basic.Model;

namespace Hunt_basic
{
    internal class Program
    {
        static Game g = new Game(3);
        static void Main(string[] args)
        {
            while (g.winner == null)
            {
                drawMap();
                try
                {
                    userInput(g.currentStep.ToString());

                } 
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    
                }
            }
        }

        static void drawMap()
        {
            //Console.Clear();
            Console.WriteLine($"Remaining rounds: {g.remRounds}");

            for (int i = 0; i < g.size; i++)
            {
                string line = "";
                for (int j = 0; j < g.size; j++)
                {
                    if (g.hunterPosions.Any(x => x == (j, i)))
                    {
                        line += "H ";
                    }
                    else if (g.preyPosition == (j, i))
                    {
                        line += "P ";
                    }
                    else
                    {
                        line += "X ";

                    }
                }
                Console.WriteLine(line);
            }
        }
        static void userInput(string player)
        {
            Console.Write($"Turn of {player}\n\t");

            string[] legalInputs = {"P->DOWN" };

            string input = Console.ReadLine();
            if (!legalInputs.Contains(input))
            {
                userInput(player);
            }
            else
            {

                switch (input)
                {
                    case "P->DOWN":
                        g.movePrey(directions.DOWN);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}