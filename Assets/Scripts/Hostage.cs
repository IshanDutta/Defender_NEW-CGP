using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hostage : MonoBehaviour
{

    public GameObject myChaser;
    float originalYPos;

    // Start is called before the first frame update
    void Start()
    {
        originalYPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.parent == null)
        {
            if((transform.position.y - originalYPos) > 1)
            {
                transform.Translate(Vector2.down * Time.deltaTime * 2);
            }
        }
    }
}
