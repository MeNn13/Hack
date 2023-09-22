using UnityEngine;

public class EnemyMind : MonoBehaviour, IDamageble, IAttack
{
    public int health;
    public int damage;

    
    public void ApplyDamage(int value)
    {
        health -= value;
        CheckHeath();
    }

    public void Attack()
    {
        
    }
    
    private void CheckHeath()
    {
        if (health <= 0)
            health = 0;
    }
}
