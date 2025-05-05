using UnityEngine;

public class UnbreakableBrick : IBrick
{
    public override void Hit()
    {
        Debug.Log("This brick is unbreakable.");
    }
}