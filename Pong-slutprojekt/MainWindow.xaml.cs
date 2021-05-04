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
        public MainWindow()
        {
            RotateTransform rotateTransform = new RotateTransform(90);
            pongCanvas.Focus();
        }

    class Pong{ 
        private void updateScore()
        {

        }

        public void EndGame()
        {

        }
    }

    class Player : Pong
    {
        bool goUp;
        int playerSpeed = 8;
        private void move(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                goUp = true;
            }

        }

        private void dontMove(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                goUp = false;
            }
        }

        private void gameEvent(object sender, KeyEventArgs e)
        {
            if (goUp == true && Canvas.GetTop(player1) > 5)
            {
                Canvas.SetTop(player1, Canvas.GetTop(player1) - playerSpeed);
            }
        }

        public void interact()
        {

        }

        public void speed()
        {
            
        }
    }

    class Player1 : Player
    {

    }

    class Player2 : Player
    {

    }

    class ball : Pong
    {
      public void movement()
        {

        }

        public void ballSpeed()
        {

        }

        public void ballInteract()
        {

        }

        public void Goal()
        {

        }

        private void direction()
        {

        }


    }

}
}
