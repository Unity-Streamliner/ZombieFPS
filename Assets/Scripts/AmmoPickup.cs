using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int amount;
    [SerializeField] AmmoType type;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player collide");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player collide");
            other.gameObject.GetComponent<Ammo>()?.IncreaseAmmo(type, amount);
            Destroy(gameObject);
        }
    }
}
