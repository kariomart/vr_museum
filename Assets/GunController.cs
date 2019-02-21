using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    AudioSource source;
    public AudioClip slowdownSFX;
    public AudioClip bulletSFX;
    public GameObject bullet;
    public Transform barrel;
    public Transform shootpt;
    public int cd;
    public int timeslowCD;
    public bool held;
    public EinsteinSpawner spawner;
    bool timeslow;
    float prevTime;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("EinsteinSpawner").GetComponent<EinsteinSpawner>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        cd++;
    }
    void FixedUpdate()
    {
        float prevTime = Time.timeScale;
        if (transform.parent == null)
        {
            held = false;

        } else
        {
            held = true;
            spawner.gamestarted = true;
            //transform.localEulerAngles = new Vector3(68, -47, -70);
        }


        if (Input.GetKeyDown(KeyCode.Space) || (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch) > .2f) && (cd > 30) && held) {
            ShootBullet();
        }

        if(OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch) > 0 && prevTime == 1) {
            source.PlayOneShot(slowdownSFX);
            timeslow = true;
        }

        //Debug.Log(OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch));
        float lTriggerVal = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch);
        Time.timeScale = Mathf.Clamp(Time.timeScale =  1 - lTriggerVal, .2f, 1);
        Time.fixedDeltaTime = Time.timeScale * 1 / 60f;


        //Debug.Log(Time.timeScale);


    }

    private void LateUpdate()
    {
        if (held) { 
            transform.localEulerAngles = new Vector3(68, -47, -70);
        }
    }

    void ShootBullet() {
        source.PlayOneShot(bulletSFX);
        cd = 0;
        GameObject b = Instantiate(bullet, shootpt.position, Quaternion.identity);
        Rigidbody rb = b.GetComponent<Rigidbody>();
        float multiplier = 1 / Time.timeScale;
        //rb.AddForce(barrel.up*500);
        rb.velocity = barrel.up*5*multiplier;
    }
}
