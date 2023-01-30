using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] PlayerHealth target;
    [SerializeField] float damage;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void OnDamageTaken()
    {
        print($"dbg: {name} Also need to know that we took damage");
    }

    public void AttackHitEvent()
    {
        if (target == null) return;
        target.TakeDamage(damage);
    }
}
