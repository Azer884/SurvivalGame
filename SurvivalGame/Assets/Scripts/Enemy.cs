using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 50;

    public float currentHealth;

    public GameObject HealthBar;


    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (HealthBar.activeSelf)
        {

        }
    }
    public void TakeDamage(float damage)
    {
        HealthBar.SetActive(true);
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Add death logic here, like playing death animation, giving player rewards, etc.
        Destroy(gameObject); // Remove the enemy object from the scene
    }
}