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
     
        public MainWindow()
        {
            InitializeComponent();
            DataContext = game;

            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(10);
            dispatcherTimer.Start();
            dispatcherTimer.Tick += Timer_Tick;

        }

        private double angle = 155;
        private int padSpeed = 12;
        private int  speed = 8;

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

            if (CheckCollision())
            {
                ChangeAngle();
                game.changeBallDirection();
            }

            double radians = (Math.PI / 180) * angle;
            Vector vector = new Vector { 
                X = Math.Sin(radians), Y = -Math.Cos(radians) 
            };
            game.BallXPosition += vector.X * speed;
            game.BallYPosition += vector.Y * speed;

            if (game.BallXPosition >= MyCanvas.ActualWidth)
            {
                game.LeftResult += 1;
                GameResetBallPosition();
                
            }
            if (game.BallXPosition <= -10)
            {
                game.RightResult += 1;
                GameResetBallPosition();
             
            }

           
        }

        private void GameResetBallPosition()
        {
            game.BallXPosition = 380;
            game.BallYPosition = 210;
        }

        private void ChangeAngle()
        {
            if (game.IsBallDirectionRight)
            {
                angle = 270 - ((game.BallYPosition + 10) - (game.RightPadPosition + 40));
            }
            
            else
            {
                angle = 90 + ((game.BallYPosition + 10) - (game.LeftPadPosition + 40));
            }
                
        }

        private bool CheckCollision()
        {
            if (game.IsBallDirectionRight)
            {
                return game.BallXPosition >= 760 && (game.BallYPosition > game.RightPadPosition - 20 && game.BallYPosition < game.RightPadPosition + 80);

            }
            return game.BallXPosition <= 20 && (game.BallYPosition > game.LeftPadPosition - 20 && game.BallYPosition < game.LeftPadPosition + 80);


        }

        private void MainWindow_OnKeyDown(object sender, KeyboardEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.W)) game.LeftPadPosition = verifyBounds(game.LeftPadPosition, -padSpeed);
            if (Keyboard.IsKeyDown(Key.S)) game.LeftPadPosition = verifyBounds(game.LeftPadPosition, padSpeed);

            if (Keyboard.IsKeyDown(Key.Up)) game.RightPadPosition = verifyBounds(game.RightPadPosition, -padSpeed);
            if (Keyboard.IsKeyDown(Key.Down)) game.RightPadPosition = verifyBounds(game.RightPadPosition, padSpeed);
        }

        private int verifyBounds(int position, int change)
        {
            position += change;

            if (position < 0)
            {
                position = 0;
            }
               
            if (position > (int)MyCanvas.ActualHeight - 90)
            {
                position = (int)MyCanvas.ActualHeight - 90;
            }

            return position;
        }

      

       


    }
}
