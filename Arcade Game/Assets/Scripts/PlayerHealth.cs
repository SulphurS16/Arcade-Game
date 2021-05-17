using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    //initial health amount
    [SerializeField] private int startHealth;

    //Set health
    private void Start()
    {
        Sethealth(startHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Zombie"))
        {
            //deal damage to player
            Damage(1);
        }
    }


    protected override void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
