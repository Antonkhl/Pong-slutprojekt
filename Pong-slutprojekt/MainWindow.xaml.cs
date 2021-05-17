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
        private Pong vm = new Pong();
        int speed = 8;
        bool goUp;
        bool goDown;
        bool wUp;
        bool sDown;
        private double angle = 155;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;

            RotateTransform rotateTransform = new RotateTransform(90);
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += Timer_Tick;
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(10);
            dispatcherTimer.Start();
         
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
           
            if (goUp && Canvas.GetTop(player2) > 0 + (player2.Height * 1.1))
            {
                Canvas.SetTop(player2, Canvas.GetTop(player2) - speed);

            }
            if (goDown && Canvas.GetTop(player2) + (player2.Height * 1.5) < Application.Current.MainWindow.Height)
            {
                Canvas.SetTop(player2, Canvas.GetTop(player2) + speed);

            }

            if (wUp && Canvas.GetTop(player1) > 0 + (player1.Height * 1.1))
            {
                Canvas.SetTop(player1, Canvas.GetTop(player1) - speed);

            }

            if (sDown && Canvas.GetTop(player1) + (player1.Height * 1.5) < Application.Current.MainWindow.Height)
            {
                Canvas.SetTop(player1, Canvas.GetTop(player1) + speed);

            }

            if (vm.BallYPosition <= 0)
                angle = angle + (180 - 2 * angle);

            if (vm.BallYPosition >= MyCanvas.ActualHeight - 20)
                angle = angle + (180 - 2 * angle);

            double radians = (Math.PI / 180) * angle;
            Vector vector = new Vector { X = Math.Sin(radians), Y = -Math.Cos(radians) };
            vm.BallXPosition += vector.X * speed;
            vm.BallYPosition += vector.Y * speed;


        }

        private void Move(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                goDown = true;
            }
            if (e.Key == Key.Up)
            {
                goUp = true;
            }

            if (e.Key == Key.W)
            {
                wUp = true;
            }

            if (e.Key == Key.S)
            {
                sDown = true;
            }

            if (e.Key == Key.Escape)
            {
                this.Close();
            }

        }

        private void dontMove(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                goDown = false;
            }
            if (e.Key == Key.Up)
            {
                goUp = false;
            }

            if (e.Key == Key.W)
            {
                wUp = false;
            }

            if (e.Key == Key.S)
            {
                sDown = false;
            }


        }
    }
}
