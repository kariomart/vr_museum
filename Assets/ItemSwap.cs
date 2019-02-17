using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSwap : MonoBehaviour
{

    public GameObject newItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Swap() {

        Vector3 newPos = new Vector3(transform.position.x, transform.position.y-1, transform.position.z);
        GameObject g = Instantiate(newItem, newPos, Quaternion.identity);
        //g.transform.localEulerAngles = this.transform.localEulerAngles;
        g.transform.localEulerAngles = new Vector3(g.transform.eulerAngles.x, this.transform.eulerAngles.y+10, this.transform.eulerAngles.z);
        Destroy(this.gameObject);

    }

    void OnCollisionEnter(Collision coll) {

        if (coll.gameObject.tag == "Fracture")
        {
            Swap();
        }

    }
}
