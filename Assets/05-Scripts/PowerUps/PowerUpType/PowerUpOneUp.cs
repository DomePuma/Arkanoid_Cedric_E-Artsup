using BrickBreaker.Player.Health;
namespace BrickBreaker.PowerUp.Base
{
    public class PowerUpOneUp : APowerUp
    {
        private PlayerHealth _playerHealth;

        private void Start()
        {
            _playerHealth = FindFirstObjectByType<PlayerHealth>();
        }

        public override void Claim()
        {
            _playerHealth.AddLife();
        }
    }
}
