using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Pong_slutprojekt 
{
    public partial class MainWindow : Window
    {
        private Pong game = new Pong();
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        private double angle = 155;
        private int playerSpeed = 12;
        private int speed = 8;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = game;

            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(10);
            dispatcherTimer.Start();
            dispatcherTimer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (game.BallYPosition <= 0)
            {
                angle = angle + (180 - 2 * angle);
            }

            if (game.BallYPosition >= MyCanvas.ActualHeight - 20)
            {
                angle = angle + (180 - 2 * angle);
            }

            if (Interaction())
            {
                ChangeAngle();
                game.changeBallDirection();
            }

            double radians = (Math.PI / 180) * angle;
            Vector vector = new Vector
            {
                X = Math.Sin(radians),
                Y = -Math.Cos(radians)
            };

            game.BallXPosition += vector.X * speed;
            game.BallYPosition += vector.Y * speed;

            if (game.BallXPosition >= MyCanvas.ActualWidth)
            {
                game.LeftResult += 1;
                GameReset();

            }
            if (game.BallXPosition <= -10)
            {
                game.RightResult += 1;
                GameReset();

            }
        }

        private void Move(object sender, KeyboardEventArgs e) 
        {
            if (Keyboard.IsKeyDown(Key.W))
            {
                game.LeftPadPosition = verify(game.LeftPadPosition, -playerSpeed);
            }
            if (Keyboard.IsKeyDown(Key.S))
            {
                game.LeftPadPosition = verify(game.LeftPadPosition, playerSpeed);
            }

            if (Keyboard.IsKeyDown(Key.Up))
            {
                game.RightPadPosition = verify(game.RightPadPosition, -playerSpeed);
            }

            if (Keyboard.IsKeyDown(Key.Down))
            {
                game.RightPadPosition = verify(game.RightPadPosition, playerSpeed);
            }
        }

        private int verify(int position, int change)
        {
            position += change;
            return position;
        }

        private void ChangeAngle()
        {
            if (game.directions)
            {
                angle = 270 - ((game.BallYPosition + 10) - (game.RightPadPosition + 40));
            }

            else
            {
                angle = 90 + ((game.BallYPosition + 10) - (game.LeftPadPosition + 40));
            }

        }

        private bool Interaction()
        {
            if (game.directions)
            {
                return game.BallXPosition >= 760 && (game.BallYPosition > game.RightPadPosition - 20 && game.BallYPosition < game.RightPadPosition + 80);

            }
            return game.BallXPosition <= 20 && (game.BallYPosition > game.LeftPadPosition - 20 && game.BallYPosition < game.LeftPadPosition + 80);


        }

        private void GameReset()
        {
            game.BallXPosition = 380;
            game.BallYPosition = 210;
        }








    }
}