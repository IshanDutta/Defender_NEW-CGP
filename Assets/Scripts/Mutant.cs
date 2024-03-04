using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant : MonoBehaviour
{
    Transform player;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = player.position - transform.position;
        transform.Translate(dir.normalized * Time.deltaTime * speed);
    }
}
