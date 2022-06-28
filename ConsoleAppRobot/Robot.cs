namespace ConsoleAppRobot
{
    internal class Robot
    {
        public int x;
        public int y;
        string direction;

        public Robot(string direction, int x, int y)
        {
            this.direction = direction;
            this.x = x;
            this.y = y;
        }

        public string Direction
        {
            get { return direction; }
            set { direction = value; }
        }
        public int X { get => x; set { x = value; } }
        public int Y { get => y; set { y = value; } }
    }
}
