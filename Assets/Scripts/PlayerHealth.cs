using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float healthPoint = 100f;

    public void TakeDamage(float damage)
    {
        healthPoint -= damage;
        if (healthPoint <= 0) {
            Died();
        }
    }

    void Died()
    {
        print("dbg: Player Died");
    }
    
}
