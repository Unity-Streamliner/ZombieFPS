using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float damage;

    void Start()
    {
        
    }

    public void AttackHitEvent()
    {
        if (target == null) return;
        print("bang bang");
    }
}
