using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float healthPoint = 100f;

    public void TakeDamage(float damage)
    {
        GetComponent<DisplayDamage>()?.ShowDamageCanvas();
        healthPoint -= damage;
        if (healthPoint <= 0) {
            Died();
        }
    }

    void Died()
    {
        print("DBG: DIED " + GetComponent<DeathHandler>());
        GetComponent<DeathHandler>()?.ShowMenu();
    }
    
}
