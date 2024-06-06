using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    WeaponModel weapon;
    Transform firePoint;
    GameObject bulletImpact;

    MeshRenderer meshRenderer;
    MeshFilter meshFilter;

    int magazine;
    int currentAmmo, bulletsForShoot;
    float timeToShoot, fireRate;

    void Start()
    {
        meshRenderer = gameObject.GetComponentInChildren<MeshRenderer>();
        meshFilter = gameObject.GetComponentInChildren<MeshFilter>();

        magazine = weapon.MagazineCap;

        timeToShoot = weapon.TimeBetweenShoot;
        fireRate = weapon.FireRat;
        bulletsForShoot = weapon.BulletsForShoot;

        meshFilter.mesh = weapon.Model;
        meshRenderer.material = weapon.Material ;
    }

    private IEnumerator FireCoroutine()
    {
        magazine--;

        if (Time.time > timeToShoot)
        {
            timeToShoot = Time.time + 1 / fireRate;

            for (int i = 0; i < bulletsForShoot; i++)
            {
                Shoot();
                yield return new WaitForSeconds(timeToShoot);
            }
        }
    }

    private void Shoot()
    {

    }

    void Update()
    {
        
    }
}
