using System;
using TMPro;
using UnityEngine;

public class PlayerHealthText : MonoBehaviour
{
    public TextMeshProUGUI healthText;

    private void Awake()
    {
        
    }

    public void SetHealth(int health)
    {
        healthText.text = health.ToString();
    }

    public void UpdateHealthText(Component sender, object data)
    {
        

        if (data is int)
        { 
            int amount = (int)data;

            SetHealth(amount);

        }        
    }


}
