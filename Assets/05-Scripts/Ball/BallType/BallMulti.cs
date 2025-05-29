using BrickBreaker.Ball.Base;

namespace BrickBreaker.Ball.Type
{
    public class BallMulti : ABall
    {
        public override void Death()
        {
            //Jsp si y a déjà un collider pour détruire la balle quand elle tombe qui a déjà était fait, du coup je laisse la fonction ici
            Destroy(gameObject);
            //Ne pas rajouter de quoi rerégéner une ball, si c'est une multi ball normale qu'elle finisse par se faire détruire sans conséquences
        }
    }
}