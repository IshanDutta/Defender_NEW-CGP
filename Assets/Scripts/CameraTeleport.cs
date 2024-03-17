using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTeleport : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 90)
        {
            transform.position = new Vector2(target.position.x + 5, transform.position.y);
        }
    }

}
