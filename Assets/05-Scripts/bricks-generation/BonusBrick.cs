public class BonusBrick : IBrick
{
    public override void Hit()
    {
        Destroy(gameObject);
        // (impl�mentation vfx)
    }
}