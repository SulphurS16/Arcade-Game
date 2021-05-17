using System;
using System.Collections;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    /// <summary>
    /// Hit points remaining 
    /// </summary>
    protected int Life { get; private set; }

    /// <summary>
    /// adds health to the total life amount staying within max health
    /// </summary>
    /// <param name="health"></param>
    /// <param name="maxHealth"></param>
    protected void Heal(int health, int maxHealth = int.MaxValue)
    {
        if (health + Life <= maxHealth)
        {
            Life += health;
        } else { Life = maxHealth; }
    }

    /// <summary>
    /// Subtracts from Health
    /// </summary>
    protected void Damage(int damage)
    {
        Life -= damage;
        if (Life <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// What to do when dead 
    /// </summary>
    protected abstract void Die();

    /// <summary>
    /// Set the starting health
    /// </summary>
    /// <param name="life"></param>
    protected void Sethealth(int life)
    {
        Life = life;
    }
}
