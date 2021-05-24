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
        private Pong game = new Pong(); //Skaper en ny Pong som heter game, Pong innehåller i princip bara olika events i INotifyPropertyChanged, Vilket är ett interface som notiferar klientent konstant när ett "value" har förändrats.
        //InotifyPropertyChanged är väldigt bra för vad jag gör, tack vare de konstanta värde ändringar som jag gör.
        DispatcherTimer dispatcherTimer = new DispatcherTimer(); //skapar en ny timer, 
        private double angle = 155; // definerar vilken angle som bollen startar vid
        private int playerSpeed = 12; //definerar spelarnas hastighet
        private int ballspeed = 8; //definerar bollens hastighet
        

        public MainWindow()
        {
            InitializeComponent();
            DataContext = game; //DataContext är ett property som helt enkelt speciferar en bas för min bindningar. Utan den fungerar inte min kod.  

            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(10); //tiden för timern att uföra allt sina uppgifter
            dispatcherTimer.Start(); //startar timern
            dispatcherTimer.Tick += Timer_Tick; //definerar metoden som timern kommer att utföra under tickens
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

            //Gör så att bolen kan inte gå utanför spelet vid högern, och om det ska spelet resetas och vänster spelarn ska få +1 poäng
            if (game.BallXPosition >= MyCanvas.ActualWidth)
            {
                game.LeftResult += 1;
                GameReset();

            }

            //Gör så att bolen kan inte gå utanför spelet vid vänstern, och om det ska spelet resetas och höger spelarn ska få +1 poäng
            if (game.BallXPosition <= -10)
            {
                game.RightResult += 1;
                GameReset();

            }

            //Om det utgörs en interaction mellan spelar(na) och bollen ska methoden ChangeAngle och en method från Pong som heter changeBallDirection anropas.
            if (Interaction())
            {
                ChangeAngle();
                game.changeBallDirection();
            }


            double radians = (Math.PI / 180) * angle; //här konverterar jag min angle till radianer, för att det blir lättare att arbeta med än grader. Dessutom arbetar Vector arbetar med radianer. 
            Vector vector = new Vector //här använder jag en vector för att behålla X och Y koordinaterna och sedan använda de för ballxposition och ballyposition
            //Vector är liksom arrays, fast den är mycket bättre och lättre att arbeta med när man arbetar med (x,y) koordinater som konstant ändras.
            {
                X = Math.Sin(radians), //sätter X-värdets vinkel till sin(radianer), vilket ursprungligen blir 0.4, vilket fungerar bra för X-värdet.
                Y = -Math.Cos(radians) //sätter Y-värdets vinkel till cos(radiner),  vilket ursprungligen blir 0.9, vilket fungerar bra för Y-värdet. Kunde inte ta cos för att det då blev ett negativ värde, som skulle ej fungera här. Så jag satte det till -cos för att omvandla det till ett positivt värde.
            };
            game.BallXPosition += vector.X * ballspeed; //multiplerar X med ballspeed vilket skulle bli x-position efter varje tick 
            game.BallYPosition += vector.Y * ballspeed; //multiplerar Y med ballspeed vilket skulle bli y-position efter varje tick 


        }

        private void Move(object sender, KeyboardEventArgs e) 
        {
            if (Keyboard.IsKeyDown(Key.W)) //om W är nere, ska leftPadPosition bli vad verify returnar som position.
            {
                game.LeftPadPosition = verify(game.LeftPadPosition, -playerSpeed);
            }
            if (Keyboard.IsKeyDown(Key.S)) //om S är nere, ska leftPadPosition bli vad verify returnar som position.
            {
                game.LeftPadPosition = verify(game.LeftPadPosition, playerSpeed);
            }

            if (Keyboard.IsKeyDown(Key.Up)) //om UP-knapp är nere, ska RightPadPosition bli vad verify returnar som position.
            {
                game.RightPadPosition = verify(game.RightPadPosition, -playerSpeed);
            }

            if (Keyboard.IsKeyDown(Key.Down)) //om Ner-knapp är nere, ska RightPadPosition bli vad verify returnar som position.
            {
                game.RightPadPosition = verify(game.RightPadPosition, playerSpeed);
            }

            if(Keyboard.IsKeyDown(Key.Escape)) //När man klickar på esc knappen avslutas spelet.
            {
                this.Close();
            }

        }

        private int verify(int position, int change) //här adderas bara position med change och det returnas. 
        {
            position += change;
            return position;
        }

        private void ChangeAngle() //metodens enda mål är kunna göra så att efter en kollison har hänt mellan en av spelarna och bollen ska bolen studsa lite åt sne. Så det inte uppkommer eviga spel där bollen går bara höger sedan vänster
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
                return game.BallXPosition >= 760 && (game.BallYPosition > game.RightPadPosition - 10 && game.BallYPosition < game.RightPadPosition + 80);
                //om bollen startar med att gå åt höger ska det returnas till if-satsen if(interaction) olika vilkor som behöver gälla om ifsatsen if(interaction) ska gälla.
            }
            else
            {
                return game.BallXPosition <= 20 && (game.BallYPosition > game.LeftPadPosition - 20 && game.BallYPosition < game.LeftPadPosition + 80);
                //samma som ovanför, men åt vänster.
            }
        }

        private void GameReset() //efter ett mål resetas bollen till sitt ursprunliga ställe. 
        {
            game.BallXPosition = 380;
            game.BallYPosition = 210;
        }
    }
}