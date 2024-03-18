using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public Enemy_Shoot myEnemy;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
         direction = myEnemy.player.transform.position - transform.position;

        float spread = Random.RandomRange(-myEnemy.spread, myEnemy.spread);


        direction = new Vector3(direction.x, direction.y + spread, 0);
    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate(direction.normalized * speed * Time.deltaTime); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerDies>(out var target))
        {
            target.KillPlayer();
        }

        if(collision.GetComponent<Enemy_Shoot>() && collision.transform != myEnemy.transform || collision.GetComponent<Projectile>())
        {
            Destroy(gameObject);
        }
     
    }

}
