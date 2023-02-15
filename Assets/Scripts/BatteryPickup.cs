using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float restoreAngle = 70f;
    [SerializeField] float intensity = 4f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player collide");
            other.gameObject.GetComponentInChildren<FlashLight>()?.RestoreLightAngle(restoreAngle);
            other.gameObject.GetComponentInChildren<FlashLight>()?.AddLightIntensity(intensity);
            Destroy(gameObject);
        }
    }
}
