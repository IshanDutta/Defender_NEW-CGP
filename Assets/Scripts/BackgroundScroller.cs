using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public Transform target;
    public float offset;
    public float divider;
    private Material mat;
    public Transform leftBorder;
    public Transform rightBorder;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }


    void Update()
    {
        mat.SetTextureOffset("_MainTex", new Vector2(target.position.x/divider, 0));
        transform.position = new Vector2(target.position.x, 0);
    }
}
