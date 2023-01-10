
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public HealthBarScript healthBar;
    public GenerateEnemies generator;

    void Start()
    {
        healthBar.SetMaxHealth(health);
    }
    public void TakeDamage(float amount){
        if (health <= 0f){
            generator.enemyDead();
            Die();
        }
        health -= amount;
        healthBar.SetHealth(health);
    }
    void Die(){
        Destroy(gameObject);
    }
}
