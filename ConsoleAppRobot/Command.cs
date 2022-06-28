using System.Text.RegularExpressions;

namespace ConsoleAppRobot
{
    internal class Command
    {
        internal static string Execute(string input)
        {
            RobotPlace robotPlace = new();

            if (Regex.IsMatch(input, "^PLACE"))
            {
                robotPlace.Place(input);
                return string.Empty;
            }

            switch (input.ToUpper())
            {
                case "REPORT":
                    return robotPlace.Report();
                case "MOVE":
                    robotPlace.Move();
                    break;
                case "LEFT":
                case "RIGHT":
                    robotPlace.Turn(input);
                    break;
                default:
                    return "INVALID";
            }

            return string.Empty;
        }
    }
}
