using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{

    public int enemyCount;
    public GameObject enemyWave;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ReduceEnemyCount()
    {
        enemyCount--;

        if(enemyCount <= 0)
        {
            NewWave();
        }
    }

    void NewWave()
    {
        GameObject go = Instantiate(enemyWave);
        go.transform.position = new Vector3(GameObject.Find("Player").transform.position.x + 9.4f, transform.position.y, transform.position.z);
        go.transform.rotation = transform.rotation;
        Destroy(gameObject);
    }
}
