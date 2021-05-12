﻿using System;
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
        int speed = 8;
        bool goUp;
        bool goDown;

        public MainWindow()
        {
            InitializeComponent();
            RotateTransform rotateTransform = new RotateTransform(90);

            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += Timer_Tick;
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(20);
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
            
        }

        private void Move(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                goDown = true;
            }
            else if (e.Key == Key.Up)
            {
                goUp = true;
            }
           
        }

        private void dontMove(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                goDown = false;
            }
            else if (e.Key == Key.Up)
            {
                goUp = false;
            }
        }
    }
}
