using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;
    public bool IsOnScreen;
    public PlayerShip _PlayerShip;
    public int pointsToAward;
    
    public void DestroyEffect()
    {
       
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        _PlayerShip.UpdateScore(pointsToAward);


        if (GetComponent<Enemy_Shoot>())
        {
            transform.parent.GetComponent<EnemyWave>().ReduceEnemyCount();
        }

        Destroy(gameObject);
    }
    public void Start()
    {
        _PlayerShip = GameObject.Find("Player").GetComponent<PlayerShip>();
    }

}
