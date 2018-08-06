using System;
using System.Collections.Generic;
using System.Text;

namespace AlienInvasion.Core
{
    public class Alien
    {
        private bool dead;
        private bool dodging;

        public bool IsDead()
        {
            return dead;
        }

        public void Kill()
        {
            dead = true;
        }

        public void Miss()
        {
            Console.WriteLine("Missed!");
            dodging = false;
        }

        public void Dodge()
        {
            dodging = true;
        }

        public bool IsDodging()
        {
            return dodging;
        }
    }
}
