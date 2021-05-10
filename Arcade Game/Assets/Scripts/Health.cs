using System;
using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;

    private ParticleSystem ps;
    private Zombie zombie;

    private void Start()
    {
        zombie = GetComponent<Zombie>();
        ps = GetComponent<ParticleSystem>();
    }

    public void Damage(int damage)
    {
        ps.Emit(30);
        health -= damage;
        if(health <= 0)
        {
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {
        zombie.dead = true;
        Destroy(GetComponent<Collider2D>());
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
