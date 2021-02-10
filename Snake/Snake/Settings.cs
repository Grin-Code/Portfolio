using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public enum dir
    {
        Left,
        Right,
        Up,
        Down
    };
    class Settings
    {
        public static int width { get; set; }
        public static int height { get; set; }
        public static int speed { get; set; }
        public static int score { get; set; }
        public static int steps { get; set; }
        public static int points { get; set; }
        public static bool gameOver { get; set; }
        public static dir Direction { get; set; }

        public static int boardX { get; set; }
        public static int boardY { get; set; }

        public Settings()
        {
            width = 16;
            height = 16;
            speed = 10;
            score = 0;
            points = 10;
            gameOver = false;
            Direction = dir.Down;
            boardX = 10;
            boardY = 10;

        }

    }
}
