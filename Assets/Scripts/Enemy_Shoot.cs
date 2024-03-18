using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy_Shoot : MonoBehaviour
{

    public Transform firePoint;
    public float maxFireRate;
    public float minFireRate;
    public float timeSinceLastFire;
    public GameObject bulletPrefab;
    [HideInInspector]public GameObject player;
    public float spread;

    private void Start()
    {
        player = GameObject.Find("Player");
        timeSinceLastFire = Random.RandomRange(minFireRate, maxFireRate);
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

        GameObject go = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        go.GetComponent<Projectile>().myEnemy = this;
        timeSinceLastFire = Random.RandomRange(minFireRate, maxFireRate);
    }
}
