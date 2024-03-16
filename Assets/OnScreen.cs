using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnScreen : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<DestroyMe>(out var target))
        {
            //is an enemy
            
            
            /*target.DestroyEffect();
            Destroy(gameObject);*/
        }
    }
}
