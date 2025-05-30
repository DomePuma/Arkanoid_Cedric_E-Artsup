using BrickBreaker.Player.Health;
namespace BrickBreaker.PowerUp.Base
{
    public class PowerUpOneUp : APowerUp
    {
        private PlayerHealth _playerHealth;

        private void Start()
        {
            _playerHealth = GetComponent<PlayerHealth>();
        }

        public override void Claim()
        {
            PlayerHealth.Instance?.AddLife();
        }
    }
}
