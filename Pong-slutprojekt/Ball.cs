using System;
using System.Collections.Generic;
using System.Text;

namespace Pong_slutprojekt
{
    class Ball 
    {
        private double xPosition; //bollens xposition.
        private double yPosition; //bollens yposition.
        private bool Directions; //vilken riktning bollen startar vid i början av spelet

        public double XPosition { get => xPosition; set => xPosition = value; } //gör en public version av Xposition som är ett get set property accessor så att xPosition kan ändra sitt position flera gånger 
        public double YPosition { get => yPosition; set => yPosition = value; } //gör en public version av Yposition som är ett get set property accessor så att xPosition kan ändra sitt position flera gånger 
        public bool Direction { get => Directions; set => Directions = value; } //gör en public version av directions som jag kan ändra, vilket tillåter mig att ändra riktningen av bolen när olika vilkor uppfylls. 

    }
}