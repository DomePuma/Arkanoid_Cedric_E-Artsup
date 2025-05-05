public class StandardBrick : IBrick
{
    private int _hitPoints = 1;

    public override void Hit()
    {
        _hitPoints--;

        if (_hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}