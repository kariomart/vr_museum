using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EinsteinSpawner : MonoBehaviour
{
    public int spawnChance;
    public GameObject einstein;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        int rand = Random.Range(0,spawnChance);
        
        if (rand == 1) {
            SpawnEinstein();
        }
    }

    void SpawnEinstein() {
        GameObject e = Instantiate(einstein, new Vector3(Random.Range(-5,5), transform.position.y, Random.Range(-5,5)), Quaternion.identity);
        e.transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,0);
        Debug.Log(e.transform.eulerAngles.z);
    }
}
