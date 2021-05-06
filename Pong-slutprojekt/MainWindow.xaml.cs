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
        const int SPEED = 8;

        public MainWindow()
        {
            RotateTransform rotateTransform = new RotateTransform(90);
            Pong pong = new Pong();
            KeyDown += dontMove;
            
        }

        private void move(object sender, KeyEventArgs e)
        {
           
        }

        private void dontMove(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up && Canvas.GetTop(player1) > 5)
            {
                Canvas.SetTop(player1, Canvas.GetTop(player1) - SPEED);
            }
        }
    }
}
