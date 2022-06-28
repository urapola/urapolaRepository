namespace ConsoleAppRobot
{
    internal class RobotPlace
    {
        readonly Robot robot = new(string.Empty, 0, 0);
        readonly string path = @"C:\log.txt";
        public void Place(string input)
        {
            var list = new List<Robot>() { };
            string[] xyDirection = input.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (xyDirection.Length.Equals(3))
            {
                var lines = ReadLines();
                if (lines != null)
                {
                    robot.Direction = lines[2];
                }
                else
                {
                    return;
                }

                _ = int.TryParse(xyDirection[1], out int findXdirection);
                _ = int.TryParse(xyDirection[2], out int findYdirection);
                Validation(findXdirection);
                Validation(findYdirection);
                robot.X = findXdirection;
                robot.Y = findYdirection;
                list.Add(robot);
                _ = WriteToFile(list);
                return;
            }

            if (xyDirection.Length.Equals(4))
            {
                _ = int.TryParse(xyDirection[1], out int findXdirection);
                _ = int.TryParse(xyDirection[2], out int findYdirection);
                Validation(findXdirection);
                Validation(findYdirection);
                Validation(xyDirection[3]);
                robot.X = findXdirection;
                robot.Y = findYdirection;
                robot.Direction = xyDirection[3];
                list.Add(robot);
                _ = WriteToFile(list);
                return;
            }
            if (xyDirection.Any())
            {
                Console.WriteLine("INVALID PLACE");
                return;
            }
        }

        public string Report()
        {
            string result;
            var lines = ReadLines();
            if (lines != null)
            {
                result = "Output: " + lines[0] + "," + lines[1] + "," + lines[2];
            }
            else
            {
                return string.Empty;
            }

            return result;
        }
        public void Move()
        {
            var lines = ReadLines();
            if (lines != null)
            {
                _ = int.TryParse(lines[0], out int findXdirection);
                _ = int.TryParse(lines[1], out int findYdirection);
                robot.X = findXdirection;
                robot.Y = findYdirection;
                robot.Direction = lines[2];
            }
            else
            {
                return;
            }

            if (robot.Direction.Equals("WEST") || robot.Direction.Equals("EAST"))
            {
                robot.X++;
                Validation(robot.X);
            }
            else
            {
                robot.Y++;
                Validation(robot.Y);
            }

            var list = new List<Robot>() { };
            list.Add(robot);
            _ = WriteToFile(list);
        }

        public void Turn(string input)
        {
            var lines = ReadLines();
            if (lines != null)
            {
                _ = int.TryParse(lines[0], out int findXdirection);
                _ = int.TryParse(lines[1], out int findYdirection);
                robot.X = findXdirection;
                robot.Y = findYdirection;
                robot.Direction = lines[2];
            }
            else
            {
                return;
            }

            if (input.Equals("RIGHT"))
            {
                TurnRight(robot.Direction);
            }
            else
            {
                TurnLeft(robot.Direction);
            }

            var list = new List<Robot>() { };
            list.Add(robot);
            _ = WriteToFile(list);
        }

        private void TurnRight(string direction)
        {
            robot.Direction = direction switch
            {
                "NORTH" => "EAST",
                "EAST" => "SOUTH",
                "SOUTH" => "WEST",
                "WEST" => "NORTH",
                _ => direction,
            };
        }

        private void TurnLeft(string direction)
        {
            robot.Direction = direction switch
            {
                "NORTH" => "WEST",
                "EAST" => "NORTH",
                "SOUTH" => "EAST",
                "WEST" => "SOUTH",
                _ => direction,
            };
        }

        private string[]? ReadLines()
        {
            try
            {
                using StreamReader streamReader = File.OpenText(path);
                var lines = streamReader.ReadToEnd().Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                return lines;
            }
            catch (Exception ex)
            {
                Console.WriteLine("File has a error " + ex.Message);
                return null;
            }
        }

        private StreamWriter WriteToFile(List<Robot> list)
        {
            StreamWriter writer = File.CreateText(path);
            foreach (Robot robot in list)
            {
                writer.WriteLine(robot.X);
                writer.WriteLine(robot.Y);
                writer.WriteLine(robot.Direction);
            }
            writer.Close();
            return writer;
        }
        private void Validation(string direction)
        {
            string[] directionArray = { "NORTH", "EAST", "SOUTH", "WEST" };
            if (!directionArray.Contains(direction.ToUpper()))
            {
                Console.WriteLine("INVALID PLACE");
                Environment.Exit(0);
            }
        }

        private static void Validation(int xyDirection)
        {
            if (xyDirection >= 0 && xyDirection <= 5)
            {
                return;
            }
            else
            {
                Console.WriteLine("INVALID MOVE");
                Environment.Exit(0);
            }
        }
    }
}
