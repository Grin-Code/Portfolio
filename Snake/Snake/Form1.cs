using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        
        
        List<Snake> snake = new List<Snake>();
        private Snake apple = new Snake();
        static int width;
        static int height;
        int maxTileW;
        int maxTileH;

        public Form1()
        {
            InitializeComponent();
            new Settings();
            Timer.Interval = 1000/Settings.speed;
            Timer.Tick += new EventHandler(Update);
            Timer.Start();
            StartGame();
        }

       

        private void StartGame() 
        {
            new Settings();
            width = Settings.boardX * Settings.width;
            height = Settings.boardY * Settings.height;
            maxTileW = width / Settings.width;
            maxTileH = height / Settings.height;
            snake.Clear();
            Snake head = new Snake { x = 5, y = 2 };
            Snake body1 = new Snake { x = 5, y = 1 };
            Snake body2 = new Snake { x = 5, y = 0 };
            snake.Add(head);
            snake.Add(body1);
            snake.Add(body2);
            GenerateFood();
        }

        private void Update(object sender, EventArgs e)
        {
            if (Settings.gameOver)
            {
                if (input.KeyPress(Keys.Enter))
                {
                    StartGame();
                }
            }
            else
            {
                if(input.KeyPress(Keys.Right) && Settings.Direction != dir.Left)
                {
                    Settings.Direction = dir.Right;
                }
                if (input.KeyPress(Keys.Left) && Settings.Direction != dir.Right)
                {
                    Settings.Direction = dir.Left;
                }
                if (input.KeyPress(Keys.Up) && Settings.Direction != dir.Down)
                {
                    Settings.Direction = dir.Up;
                }
                if (input.KeyPress(Keys.Down) && Settings.Direction != dir.Up)
                {
                    Settings.Direction = dir.Down;
                }
                UpdateSnake();
            }
            PB.Invalidate();
        }

        private void UpdateSnake()
        {
            Settings.steps++;
            Steps.Text = "Steps: " + Settings.steps.ToString();
            for(int i= snake.Count - 1; i >= 0; i--)
            {
                if(i == 0)//head
                {
                    switch (Settings.Direction)
                    {
                        case dir.Right:
                            snake[i].x++;
                            break;
                        case dir.Left:
                            snake[i].x--;
                            break;
                        case dir.Down:
                            snake[i].y++;
                            break;
                        case dir.Up:
                            snake[i].y--;
                            break;
                        default:
                            break;
                    }

                    if (snake[i].x < 0 || snake[i].y < 0 || snake[i].x > maxTileW || snake[i].y > maxTileH)
                        Die();

                    for(int j =1; j<snake.Count; j++)
                    {
                        if(snake[i].x == snake[j].x && snake[i].y == snake[j].y)
                        {
                            Die();
                            break;
                        }
                    }
                    
                    if(snake[0].x == apple.x && snake[0].y == apple.y)
                    {
                        Eat();
                    }
                }
                else
                {
                    snake[i].x = snake[i - 1].x;
                    snake[i].y = snake[i - 1].y;
                }
            }
        }

        private void PB_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            Brush snakeColour;
            for (int i=0; i < snake.Count; i++)
            {
                if (i == 0)
                {
                    snakeColour = Brushes.White;
                }
                else
                {
                    snakeColour = Brushes.Green;
                }
                canvas.FillRectangle(snakeColour, new Rectangle(snake[i].x * Settings.width, snake[i].y * Settings.height, Settings.width, Settings.height));
            }
            canvas.FillRectangle(Brushes.Red, new Rectangle(apple.x * Settings.width, apple.y * Settings.height, Settings.width, Settings.height));
        }

        public void GenerateFood()
        {
            Random r = new Random();

            apple = new Snake();
            apple.x = r.Next(0, maxTileW);
            apple.y = r.Next(0, maxTileH);
        }

        private void F1_KeyDown(object sender, KeyEventArgs e)
        {
            input.ChangeState(e.KeyCode, true);
        }
        private void F1_KeyUp(object sender, KeyEventArgs e)
        {
            input.ChangeState(e.KeyCode, false);
        }

        public void Die()
        {
            Settings.gameOver = true;
        }
        public void Eat()
        {
            Snake body = new Snake
            {
                x = snake[snake.Count - 1].x,
                y = snake[snake.Count - 1].y
            };
            snake.Add(body);
            Settings.score += Settings.points;
            Score.Text = "Score: " + Settings.score.ToString();
            GenerateFood();
        }

    }
}
