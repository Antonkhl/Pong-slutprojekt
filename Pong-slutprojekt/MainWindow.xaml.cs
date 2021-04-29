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

namespace Pong_slutprojekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            RotateTransform rotateTransform = new RotateTransform(90);
        }
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
        public void move()
        {

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
      
    }

}
