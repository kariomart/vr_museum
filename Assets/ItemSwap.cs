using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSwap : MonoBehaviour
{

    public GameObject newItem;
    Vector3 destination;
    Vector3 dir;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        destination = GameObject.Find("OVRPlayerController").transform.position;
        dir = destination - transform.position;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(dir * Random.Range(15,30));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position = Vector3.MoveTowards(this.transform.position, destination, .1f);

    }

    public void Swap() {

        Vector3 newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        GameObject g = Instantiate(newItem, newPos, Quaternion.identity);
        //g.transform.localEulerAngles = this.transform.localEulerAngles;
        g.transform.localScale = new Vector3(0.0906301f,0.0906301f,0.0906301f);
        g.transform.localEulerAngles = new Vector3(g.transform.eulerAngles.x, this.transform.eulerAngles.y+10, this.transform.eulerAngles.z);
        Destroy(this.gameObject);

    }

    void OnCollisionEnter(Collision coll) {

        if (coll.gameObject.tag == "Bullet")
        {
            Swap();
        }

    }
}
