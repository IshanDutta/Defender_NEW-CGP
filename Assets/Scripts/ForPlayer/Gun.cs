using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] AudioClip fireSound;
    [SerializeField] float fireDelay = 0.25f;
    //so player cant spam
    float coolDown;

    bool CanFire => Time.time >= coolDown;
    Transform thisTransform;

     void Awake()
    {
        thisTransform = transform;
    }
    void OnEnable()
    {
        coolDown = Time.time;
        //be ablke to fire immeditaely 
    }
    public void FireGun()
    {
        if (!CanFire) return;
        //play audio clip
        var projectile = Instantiate(projectilePrefab, thisTransform.position, thisTransform.rotation);
        projectile.gameObject.SetActive(true);
        coolDown = Time.time + fireDelay;
    }
}
