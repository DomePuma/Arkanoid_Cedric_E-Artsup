namespace BrickBreaker.Spawning.PowerUp.Strategy
{
    public interface IPowerUpSpawnStrategy
    {
        bool ShouldSpawnPowerUp();
        int ChoosePowerUpIndex(int count); // Peut être optionnel selon les besoins
    }
}
