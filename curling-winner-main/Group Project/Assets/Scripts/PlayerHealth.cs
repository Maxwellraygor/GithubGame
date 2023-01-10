using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    
    public HealthBarScript healthBar;
    public int maxHealth = 100;
    public int currentHealth;
    public int healthRegen = 5;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        StartCoroutine(addHealth());
    }

    void Update()
    {
        if (currentHealth == 0)
        {
            SceneManager.LoadScene(sceneBuildIndex: 8);
            Destroy(this);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    IEnumerator addHealth()
    {
        while (true)
        {
            if(currentHealth < maxHealth)
            {
                currentHealth += healthRegen;
                healthBar.SetHealth(currentHealth);
                yield return new WaitForSeconds(1);
            }
            else
            {
                yield return null;
            }
        }
    }


}

