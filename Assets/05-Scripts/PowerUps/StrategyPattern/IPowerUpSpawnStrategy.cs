namespace BrickBreaker.Spawning.PowerUp.Strategy
{
    public interface IPowerUpSpawnStrategy
    {
        bool ShouldSpawnPowerUp();
        int ChoosePowerUpIndex(int count); // Peut �tre optionnel selon les besoins
    }
}
