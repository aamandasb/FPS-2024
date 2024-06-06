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
    float timeToShoot, fireRate, range;

    void Start()
    {
        meshRenderer = gameObject.GetComponentInChildren<MeshRenderer>();
        meshFilter = gameObject.GetComponentInChildren<MeshFilter>();

        magazine = weapon.MagazineCap;

        timeToShoot = weapon.TimeBetweenShoot;
        fireRate = weapon.FireRat;
        bulletsForShoot = weapon.BulletsForShoot;
        range = weapon.Range;

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
        RaycastHit hit;

        Vector3 direction = 

        if (Physics.Raycast(firePoint.position, direction, out hit, range))
        {
            Collider obj = hit.transform.GetComponent<Collider>();
            if (obj != null)
            {
                Debug.Log(obj.gameObject.name);
                Instantiate(bulletImpact, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }

        Debug.DrawLine(firePoint.position, firePoint.position + direction * range);
    }

    void Update()
    {
        
    }
}
