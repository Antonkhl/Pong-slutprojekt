using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Pong_slutprojekt
{
    class Pong : INotifyPropertyChanged
    {
        private int leftPadPosition = 180; //Definerar var vänster spelaren är
        private int rightPadPosition = 180; //Definerar var höger spelaren är
        private int leftResult = 0; 
        private int rightResult = 0;
        private Ball ball = new Ball { XPosition = 380, YPosition = 220, Direction = true }; //skapar en ny boll som ärver från Ball.cs klassen där jag sätter mina 3 värden till de basiska värden, fast de kommer att ändras.


        public int LeftPadPosition
        {
            get { return leftPadPosition; } //får den nuvarande värdet av leftPadPosition när det behövs
            set
            {
                leftPadPosition = value; //sätter det till den nya värdet när det behövs 
                OnPropertyChanged("LeftPadPosition"); //startar själva eventet. 
            }
        }

        public int RightPadPosition
        {
            get { return rightPadPosition; } //får den nuvarande värdet av rightPadPosition när det behövs
            set
            {
                rightPadPosition = value; //sätter det till den nya värdet när det behövs  
                OnPropertyChanged("RightPadPosition"); //startar själva eventet.
            }
        }

        public int LeftResult
        {
            get { return leftResult; } //får den nuvarande värdet av LeftResult när det behövs
            set
            {
                leftResult = value; //sätter det till den nya värdet när det behövs 
                OnPropertyChanged("LeftResult"); //startar själva eventet.
            }
        }

        public int RightResult 
        {
            get { return rightResult; } //får den nuvarande värdet av RightResult när det behövs
            set
            {
                rightResult = value; //sätter det till den nya värdet när det behövs  
                OnPropertyChanged("RightResult"); //startar själva eventet.
            }
        }

        public double BallXPosition 
        {
            get { return ball.XPosition; } //får den nuvarande värdet av BallXPosition när det behövs. Nu definerar jag dessutom att det är ball som jag vill xpositon från. 
            set
            {
                ball.XPosition = value; //sätter det till den nya värdet när det behövs
                OnPropertyChanged("BallXPosition"); //startar själva eventet.
            }
        }

        public double BallYPosition
        {
            get { return ball.YPosition; } //får den nuvarande värdet av BallYPosition när det behövs. Nu definerar jag dessutom att det är ball som jag vill ypositon från. 
            set
            {
                ball.YPosition = value; //sätter det till den nya värdet när det behövs  
                OnPropertyChanged("BallYPosition"); //startar själva eventet.
            }
        }

        public bool directions
        {
            get { return ball.Direction; } //får den nuvarande värdet av directions när det behövs
            set
            {
                ball.Direction = value; //sätter det till den nya värdet när det behövs 
                OnPropertyChanged("IsBallDirectionRight"); //startar själva eventet.
            }
        }

        public void changeBallDirection() //vad metod gör är helt enkelt gör så att bollen blir negativ, eller får negativa värden så att den kan interagera med leftpad.
        {
            directions = !directions;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) //kod som jag hittade på stackoverflow som skapar själva propertychanged funktionen som sätter igång alla mina events.
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }



}