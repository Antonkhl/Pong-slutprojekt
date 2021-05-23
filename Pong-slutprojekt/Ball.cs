using System;
using System.Collections.Generic;
using System.Text;

namespace Pong_slutprojekt
{
    class Ball 
    {
        private double xPosition;
        private double yPosition;
        private bool Directions;

        public double XPosition { get => xPosition; set => xPosition = value; }
        public double YPosition { get => yPosition; set => yPosition = value; }
        public bool Direction { get => Directions; set => Directions = value; }

    }
}