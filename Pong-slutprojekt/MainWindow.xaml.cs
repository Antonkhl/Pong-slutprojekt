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
        private Pong game = new Pong(); //Skaper en ny Pong som heter Spel, Pong innehåller i princip bara INotifyPropertyChanged, Vilket är ett interface som notiferar klientent konstant när ett "value" har förändrats.
   //InotifyPropertyChanged är väldigt bra för vad jag gör, tack vare de konstanta värde ändringar som jag gör.
        DispatcherTimer dispatcherTimer = new DispatcherTimer(); //skapar en ny timer, 
        private double angle = 155; // definerar vilken angle som bollen startar vid
        private int playerSpeed = 12; //definerar spelarnas hastighet
        private int speed = 8; //definerar bollens hastighet

        public MainWindow()
        {
            InitializeComponent();
            DataContext = game; //DataContext är ett property so helt enkelt speciferar en bas för min bindningar. 

            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(10); //tiden för timern att uföra allt sina uppgifter
            dispatcherTimer.Start(); //startar timern
            dispatcherTimer.Tick += Timer_Tick; //definerar metoden som timern kommer att utföra efter intervalen at ticken är över
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //Gör så att bolen kan inte gå utanför spelet vid toppen, och om det gör den nuddar taket ska den studsa
            if (game.BallYPosition <= 0)
            {
                angle = angle + (180 - 2 * angle);
            }

            //Samma som if-satsen överför bara att det angående golvet av spelet
            if (game.BallYPosition >= MyCanvas.ActualHeight - 20)
            {
                angle = angle + (180 - 2 * angle);
            }

            //Om det utgörs en interaction mellan spelar(na) ska methoden ChangeAngle och en method from Pong som heter 
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