using UnityEngine;
using System.Collections;

public class PlayeDamageFeedback : MonoBehaviour
{
    public ParticleSystem damageVFX;
    public Renderer playerRenderer;

    public void DamageFeedback(Component sender, object data)
    {

        Debug.Log("DamageFeedback received data: " + data);

        if (data is int)
        {
            int amount = (int)data;

            if (amount < 100)
            {
                damageVFX.Play();
                StartCoroutine(DamageFlash(3));
            }
        }
    }


    IEnumerator DamageFlash(int repetitions)
    {
        for (int i = 0; i < repetitions; i++)
        {
            Color originalColor = playerRenderer.material.color;

            playerRenderer.material.color = Color.red;
            yield return new WaitForSeconds(0.04f);

            playerRenderer.material.color = originalColor;
            yield return new WaitForSeconds(0.06f);
        }



    }
}
