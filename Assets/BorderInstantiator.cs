using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderInstantiator : MonoBehaviour
{
    public GameObject backgroundPrefab;
    public Transform myBackground;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform == Camera.main.transform)
        {
            GameObject go = Instantiate(backgroundPrefab, transform);
            go.transform.localPosition = new Vector2(-4.933f, 0);
            go.transform.parent = null;
            go.transform.localScale = new Vector3(3.979922f, 1, 1);
            myBackground = go.transform;
        }
    }
}
