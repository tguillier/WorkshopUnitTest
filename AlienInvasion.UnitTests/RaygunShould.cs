using AlienInvasion.Core;
using System;
using Xunit;

namespace AlienInvasion.UnitTests
{
    public class RaygunShould
    {
        [Fact]
        public void KillAlien()
        {
            // Arrange
            var alien = new Alien();
            var gun = new Raygun();

            // Act
            gun.Shoot(alien);

            // Assert
            Assert.True(alien.IsDead());
        }

        [Fact]
        public void MissDodgingAlien()
        {
            // Arrange
            var alien = new Alien();
            var gun = new Raygun();

            // Act
            alien.Dodge();
            gun.Shoot(alien);

            // Assert
            Assert.False(alien.IsDead());
        }

        [Theory]
        [InlineData(1, false)]
        [InlineData(3, true)]
        public void ReloadAfterXShots(int shotsCount, bool shouldReload)
        {
            // Arrange
            var alien = new Alien();
            var gun = new Raygun();

            // Act
            for (int i = 0; i < shotsCount; i++)
            {
                gun.Shoot(alien);
            }

            // Assert
            Assert.Equal(shouldReload, !gun.HasAmmo());
        }

        [Fact]
        public void HaveAmmoAfterReload()
        {
            // Arrange
            var alien = new Alien();
            var gun = new Raygun();

            // Act
            while (gun.HasAmmo())
            {
                gun.Shoot(alien);
            }

            gun.Reload();

            // Assert
            Assert.True(gun.HasAmmo());
        }

        [Fact]
        public void ReloadAfterShotWithNoAmmo()
        {
            // Arrange
            var alien = new Alien();
            var gun = new Raygun();

            // Act
            while (gun.HasAmmo())
            {
                gun.Shoot(alien);
            }

            gun.Shoot(alien);

            // Assert
            Assert.True(gun.HasAmmo());
        }
    }
}
