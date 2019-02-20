using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bullet;
    public Transform barrel;
    public Transform shootpt;
    public int cd;
    public bool held;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cd++;
    }
    void FixedUpdate()
    {

        if (transform.parent == null)
        {
            held = false;
        } else
        {
            held = true;
        }


        if (Input.GetKeyDown(KeyCode.Space) || (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch) > .2f) && (cd > 30) && held) {
            ShootBullet();
        }

        //Debug.Log(OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch));
        float lTriggerVal = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch);
        Time.timeScale = Mathf.Clamp(Time.timeScale =  1 - lTriggerVal, .2f, 1);
        Time.fixedDeltaTime = Time.timeScale * 1 / 60f;
        Debug.Log(Time.timeScale);


    }

    void ShootBullet() {
        cd = 0;
        GameObject b = Instantiate(bullet, shootpt.position, Quaternion.identity);
        Rigidbody rb = b.GetComponent<Rigidbody>();
        float multiplier = 1 / Time.timeScale;
        rb.AddForce(barrel.up*500);
    }
}
