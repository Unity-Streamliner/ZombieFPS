using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        print($"{transform.name} hitPoints left {hitPoints}");
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
