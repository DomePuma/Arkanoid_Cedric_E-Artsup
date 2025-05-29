using BrickBreaker.Ball.Base;

namespace BrickBreaker.Ball.Type
{
    public class BallBase : ABall
    {
        public override void Death()
        {
            FindFirstObjectByType<PlayerHealth>().LoseLife();

            Destroy(gameObject);
            //Ici rajouter les fonctions pour regénérer une balle
        }
    }
}