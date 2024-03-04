using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public Transform target;
    public float offset;
    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }


    void Update()
    {
        mat.SetTextureOffset("_MainTex", new Vector2(target.position.x/50, 0));
        transform.position = new Vector2(target.position.x, 1f);
    }
}
