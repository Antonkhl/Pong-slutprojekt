using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Pong_slutprojekt
{
    class Pong : INotifyPropertyChanged
    {
        private int leftPadPosition = 180;
        private int rightPadPosition = 180;
        private int leftResult = 0;
        private int rightResult = 0;
        private Ball ball = new Ball { XPosition = 380, YPosition = 220, Direction = true };


        public int LeftPadPosition
        {
            get { return leftPadPosition; }
            set
            {
                leftPadPosition = value; 
                OnPropertyChanged("LeftPadPosition");
            }
        }

        public int RightPadPosition
        {
            get { return rightPadPosition; }
            set
            {
                rightPadPosition = value;
                OnPropertyChanged("RightPadPosition");
            }
        }

        public int LeftResult
        {
            get { return leftResult; }
            set
            {
                leftResult = value;
                OnPropertyChanged("LeftResult");
            }
        }

        public int RightResult
        {
            get { return rightResult; }
            set
            {
                rightResult = value;
                OnPropertyChanged("RightResult");
            }
        }

        public double BallXPosition
        {
            get { return ball.XPosition; }
            set
            {
                ball.XPosition = value;
                OnPropertyChanged("BallXPosition");
            }
        }

        public double BallYPosition
        {
            get { return ball.YPosition; }
            set
            {
                ball.YPosition = value;
                OnPropertyChanged("BallYPosition");
            }
        }

        public bool directions
        {
            get { return ball.Direction; }
            set
            {
                ball.Direction = value;
                OnPropertyChanged("IsBallDirectionRight");
            }
        }

        public void changeBallDirection()
        {
            directions = !directions;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }



}