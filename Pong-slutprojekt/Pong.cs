using System;
using System.Collections.Generic;
using System.Text;

namespace Pong_slutprojekt
{
    class Pong
    {

        private Player _player1;

        public Player Player1
        {
            get { return _player1; }
            private set { _player1 = value; }
           
        }

        private Player _player2;

        public Player Player2
        {
            get { return _player2; }
            private set { _player2 = value; }
        }

        public Pong()
        {
            Player1 = new Player();
            Player2 = new Player();
        }

        private void updateScore()
        {

        }

        public void EndGame()
        {

        }
    }
}
