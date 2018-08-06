using System;
using System.Collections.Generic;
using System.Text;

namespace AlienInvasion.Core
{
    public class Raygun
    {
        private int ammo = 3;

        public void Shoot(Alien alien)
        {
            if (!HasAmmo())
            {
                Reload();
                return;
            }

            if (alien.IsDodging())
            {
                alien.Miss();
            }
            else
            {
                alien.Kill();
            }
            ammo--;
        }

        private void Reload()
        {
            ammo = 3;
        }

        public bool HasAmmo()
        {
            return ammo > 0;
        }
    }
}
