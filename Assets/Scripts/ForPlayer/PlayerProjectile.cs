using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbod;
    [SerializeField] float speed = 50f;
    [SerializeField] float duration = 0.25f;

    float destroyTime;
    bool OutofFuel => Time.time >= destroyTime;
     void OnEnable()
    {
        destroyTime = Time.time + duration;
        rigidbod.velocity = (Vector2)(transform.right * speed);
    }
     void Update()
    {
        if(OutofFuel)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //make sure all enemies have DestroyMe script 
        if(other.TryGetComponent<DestroyMe>(out var target))
        {
            target.DestroyEffect();
        }
    }
}
