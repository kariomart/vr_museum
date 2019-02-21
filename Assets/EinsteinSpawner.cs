using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EinsteinSpawner : MonoBehaviour
{
    public int spawnChance;
    public GameObject einstein;
    public GameObject gunPrefab;
    public GameObject gun;
    public GameObject player;
    public int score;
    public TextMeshPro scoreMesh;
    public bool gameover;
    public bool gamestarted;
    int c;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        c++;
        int rand = Random.Range(0,spawnChance);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        
        if (rand == 1 && gamestarted) {
            SpawnEinstein();
        }

        if (Vector3.Distance(player.transform.position, gun.transform.position) > 5)
        {
            GameObject g = Instantiate(gunPrefab, new Vector3(0, 2, 0), Quaternion.identity);
            gun = g;
        }

        if (!gameover)
        {
            scoreMesh.text = "SCORE: " + score;
        } else
        {
            gameoverScore();
            if (OVRInput.Get(OVRInput.Button.One))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
        }
        if (c % 15 == 0 && spawnChance > 30) 
        {
            spawnChance--;
        }
    }

    void SpawnEinstein() {
        GameObject e = Instantiate(einstein, new Vector3(Random.Range(-3,3), Random.Range(2,8), 3), Quaternion.identity);
        // Vector3 rotation = new Vector3(Random.Range(0,360),Random.Range(0,360),Random.Range(0,360));
        // float x = Mathf.MoveTowards(transform.eulerAngles.x, rotation.x,1);
        // float y = Mathf.MoveTowards(transform.eulerAngles.x, rotation.x,1);
        // float z = Mathf.MoveTowards(transform.eulerAngles.x, rotation.x,1);
        e.transform.eulerAngles = new Vector3(Random.Range(0,360), Random.Range(0, 360), Random.Range(0, 360));
        //Debug.Log(e.transform.eulerAngles.z);
    }

    void gameoverScore()
    {
        scoreMesh.text = "GAME OVER\nSCORE: " + score + "\nPRESS A TO RESTART";
    }
}
