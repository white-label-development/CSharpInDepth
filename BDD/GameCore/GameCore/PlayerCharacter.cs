namespace GameCore
{
    public class PlayerCharacter
    {
        public int Health { get; private set; } = 100;
        public bool IsDead { get; private set; }

        public void Hit(int damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                IsDead = true;
            }
        }
    }
}
