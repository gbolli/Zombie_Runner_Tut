using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 50f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject fleshHitEffect;
    [SerializeField] GameObject surfaceHitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float timeBetweenShots = 0.5f;
    bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true;  // to prevent getting stuck on canshoot=false when weapon is switched before coroutine is finished.
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot) StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        canShoot = false;

        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            ammoSlot.ReduceCurrentAmmo(ammoType);
            PlayMuzzleFlash();
            ProcessRaycast();
        }

        yield return new WaitForSeconds(timeBetweenShots);

        canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            if (hit.transform.name == "Enemy")
            {
                CreateHitEffect(hit, fleshHitEffect);
            }
            else
            {
                CreateHitEffect(hit, surfaceHitEffect);
            }

            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

            if (target == null) return;

            target.TakeDamage(damage);
        }
    }

    private void CreateHitEffect(RaycastHit hit, GameObject effect)
    {
        GameObject impact = Instantiate(effect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1);
    }
}
