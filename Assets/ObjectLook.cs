using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLook : MonoBehaviour
{

    Camera cam;
    float defScale;
    ItemSwap itemSwap;
    Rigidbody rb;
    //attatched to any gameobject which the camera can interact with

    // Start is called before the first frame update
    void Start()
    {
        defScale = transform.localScale.x;
        cam = Camera.main;
        itemSwap = GetComponent<ItemSwap>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 fromCameraToMe = transform.position - cam.transform.position;
        float angle = Vector3.Angle(Camera.main.transform.forward, fromCameraToMe.normalized);

        if (angle < 10f) {
            if(Input.GetMouseButtonDown(0)) {
                //itemSwap.Swap();
                rb.isKinematic = false;
                Debug.Log("?");
            }
            //transform.Rotate(0, 90 * Time.deltaTime, 0f);

        } else {
            float s = Mathf.MoveTowards(transform.localScale.x, defScale, .1f);
            transform.localScale = new Vector3(s, s, s);
        }
        
    }
}
