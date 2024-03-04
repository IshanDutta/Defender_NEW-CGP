using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shoot : MonoBehaviour
{

    public Transform firePoint;
    public float fireRate;
    float timeSinceLastFire;
    public GameObject bulletPrefab;
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }


    private void Update()
    {
        timeSinceLastFire -= Time.deltaTime;

        if(timeSinceLastFire < 0)
        {
            Shoot();
        }
    }
    public void Shoot()
    {

        timeSinceLastFire = fireRate;
        float spread = Random.RandomRange(-30, 30);
        Quaternion newRot = firePoint.rotation;

        Vector3 dir = player.transform.position - firePoint.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


        // Then add "addedOffset" to whatever rotation axis the player must rotate on
        newRot = Quaternion.Euler(firePoint.transform.localEulerAngles.x,
            firePoint.transform.localEulerAngles.y,
            firePoint.transform.localEulerAngles.z + spread);

            Instantiate(bulletPrefab, firePoint.position, newRot);


    }
}
