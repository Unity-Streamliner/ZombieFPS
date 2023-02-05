using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 25f;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    bool canShoot = true;
    float timeBetweenShots = 0.5f;

    void OnEnable()
    {
        canShoot = true;
    }

    void Start()
    {
        ammoSlot = GetComponentInParent<Ammo>();
        //print($"Dbg find ammo {ammoSlot.GetCurrentAmmo()}");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0) 
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceAmmo(ammoType);
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    void ProcessRaycast()
    {
        RaycastHit hit;
        if(Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            print($"I hit this thing {hit.transform.name}");
            // TODO: add some hit effect for visual player
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) 
            { 
                print($"dbg: hit position {hit.transform.position}");
                CreateHitImpact(hit);
                return; 
            }
            // call a method on EnemyHealth that decrease the enemy's health
            target.TakeDamage(damage);
        }
        else 
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
    }
}
