using UnityEngine;


public class ZombieHealth : Health
{
    //initial health amount
    private readonly int startHealth = 2;

    //Set health
    private void Start()
    {
        Sethealth(startHealth);
    }

    //when shot this gets called
    public void Hit(int damage)
    {
        Debug.Log("hit");
        Damage(damage);
    }
    //when we die this gets called
    protected override void Die()
    {
        Destroy(gameObject);
    }


}
