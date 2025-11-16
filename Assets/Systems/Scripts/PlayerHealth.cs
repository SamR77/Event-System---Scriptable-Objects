using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public float debuffCooldown = 1.0f;

   

    private int currentHealth;

    private WaitForSeconds waitForDebuff;


    [Header("Events")]
    public GameEvent onPlayerHealthChanged;

    private void Awake()
    {
        currentHealth = startingHealth;
        onPlayerHealthChanged.Raise(this, currentHealth);

        waitForDebuff = new WaitForSeconds(debuffCooldown);

        StartCoroutine(TakeDamage(1));
    }

    // Apply Periodic Damage to the Player
    IEnumerator TakeDamage(int damageAmount)
    {
        while (currentHealth > 0)
        {
            if(currentHealth == 100)
            {
                yield return waitForDebuff;              
            }

            currentHealth -= damageAmount;
            
            onPlayerHealthChanged.Raise(this, currentHealth);
            Debug.Log("Player took " + damageAmount + " damage. Current Health: " + currentHealth);

            yield return waitForDebuff;
        }
    }

  
    

}
