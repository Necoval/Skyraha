using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    class Spieler
    {
        private string Name;
        private int Punkte;
        private int Leben;

        public Spieler(string name)
        {
            this.Name = name;
        }

        public Spieler(string name, int startingLives)
        {
            this.Name = name;
            Leben = startingLives;
        }

        public string GetName()
        {
            return Name;
        }

        public int GetScore()
        {
            return Punkte;
        }

        public void AddPoints(int GesamtPunkte)
        {
            Punkte += GesamtPunkte;
        }

        public void Kill()
        {
            if (Leben > 0)
            {
                Leben--;
            }
        }

        public int GetLivesLeft()
        {
            return Leben;
        }
    }
}
    
