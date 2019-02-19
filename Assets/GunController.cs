using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bullet;
    public Transform barrel;
    public Transform shootpt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > .2f)) {
            ShootBullet();
        }

    }

    void ShootBullet() {
        GameObject b = Instantiate(bullet, shootpt.position, Quaternion.identity);
        Rigidbody rb = b.GetComponent<Rigidbody>();
        rb.AddForce(barrel.up*100);
    }
}
