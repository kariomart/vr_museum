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
        GameObject e = Instantiate(einstein, new Vector3(Random.Range(-3,3), transform.position.y, 1.5f), Quaternion.identity);
        // Vector3 rotation = new Vector3(Random.Range(0,360),Random.Range(0,360),Random.Range(0,360));
        // float x = Mathf.MoveTowards(transform.eulerAngles.x, rotation.x,1);
        // float y = Mathf.MoveTowards(transform.eulerAngles.x, rotation.x,1);
        // float z = Mathf.MoveTowards(transform.eulerAngles.x, rotation.x,1);
        e.transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,0);
        Debug.Log(e.transform.eulerAngles.z);
    }
}
