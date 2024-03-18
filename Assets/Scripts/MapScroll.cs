using System.Collections;
using System.Collections.Generic;
//using TreeEditor;
using UnityEngine;

public class MapScroll : MonoBehaviour
{
    public Camera cam;
    private float startingPos;
    [SerializeField] private float pEffect;
    private float spriteLength;


    // Start is called before the first frame update


    void Start()
    {
        startingPos = transform.position.x;
        spriteLength = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float tempoarydistance = (cam.transform.position.x * (1 - pEffect));
        float distance = (cam.transform.position.x * pEffect);

        transform.position = new Vector3(startingPos + distance, transform.position.y, transform.position.z);
        if (tempoarydistance > startingPos + spriteLength) startingPos += spriteLength;

        else if (tempoarydistance < startingPos - spriteLength) startingPos -= spriteLength;

    }
}
