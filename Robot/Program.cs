using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    class Program
    {
        /// <summary>
        /// Entry point
        /// </summary>
        static void Main(string[] args)
        {
            var myRobot = new Robot(new Tabletop(5,5));

            // Loops until EXIT command or null
            while (true)
            {
                //Console.WriteLine("Command:");
                string input = Console.ReadLine()??"EXIT";
                string cmd = String.Concat(input.Where(c => !Char.IsWhiteSpace(c))).ToUpper();
                if (cmd.ToUpper() == AppCommand.EXIT.ToString())
                {
                    break;
                }
                if (cmd.ToUpper() == AppCommand.MOVE.ToString())
                {
                    myRobot.Move();
                    continue;
                }
                if (cmd.ToUpper() == AppCommand.LEFT.ToString())
                {
                    myRobot.Turn(TurnDirection.LEFT);
                    continue;
                }
                if (cmd.ToUpper() == AppCommand.RIGHT.ToString())
                {
                    myRobot.Turn(TurnDirection.RIGHT);
                    continue;
                }
                if (cmd.ToUpper() == AppCommand.REPORT.ToString())
                {
                    Report(myRobot);
                    continue;
                }
                if (cmd.Length>5 && cmd.Substring(0, 5) == AppCommand.PLACE.ToString())
                {
                    string sParameters = cmd.Substring(5, cmd.Length - 5);
                    var parameters = sParameters.Split(',');
                    int x = 0;
                    int y = 0;
                    Direction direction;
                    try
                    {
                        int.TryParse(parameters[0], out x);
                        int.TryParse(parameters[1], out y);
                        Enum.TryParse(parameters[2], out direction);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    myRobot.Place(new Point(x, y), direction);
                }
            }
        }

        /// <summary>
        /// Outputs robot status to console
        /// </summary>
        /// <param name="myRobot"></param>
        static void Report(Robot myRobot) {
            if (myRobot.IsPlaced)
                Console.WriteLine(myRobot.Report);
        }

    }
}
