using System;
using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;

    private ParticleSystem ps;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        spriteRenderer.sprite = null;
        Destroy(GetComponent<Collider2D>());
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
