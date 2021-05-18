using System;
using System.Collections.Generic;
using System.Text;

namespace Pong_slutprojekt
{
    class Ball : IMovable
    {
        private double xPosition;
        private double yPosition;
        private bool isDirectionRight;

        public double XPosition { get => xPosition; set => xPosition = value; }
        public double YPosition { get => yPosition; set => yPosition = value; }
        public bool IsDirectionRight { get => isDirectionRight; set => isDirectionRight = value; }

    }
}
