using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Pong_slutprojekt
{
    class Pong : INotifyPropertyChanged
    {
        private Ball ball = new Ball { XPosition = 340, YPosition = 220};
        public event PropertyChangedEventHandler PropertyChanged;

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

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }


  
}
