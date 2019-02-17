using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR;

public class Grabber : MonoBehaviour
{

    public GameObject collidedWithObject;   //keeping track of the object we've collided with


    bool hasPressedTrigger = false;     //keeping track of whether we've pressed any trigger

    Vector3 positionWhenPressed;    //keeping track of position of hand when trigger is pressed
    Vector3 positionWhenReleased;       //keeping track of position of hand when trigger is released


        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(OVRInput.Get(OVRInput.Axis1D.Any) > 0.2f)    //if we're applying any pressure to the trigger
        {

            if(!hasPressedTrigger)  //we're pressing trigger for first time
            {
                hasPressedTrigger = true;
                positionWhenPressed = this.transform.position;
            }
               
            
        }

        else
        {
            // we're not pressing the trigger
        
            if(hasPressedTrigger)   // if we've previously pressed it, that means we've just let go of the trigger.
            {
                if (collidedWithObject != null)  //if we're holding something
                {
                    positionWhenReleased = this.transform.position;

                    Vector3 throwDirection = positionWhenReleased - positionWhenPressed;



                    collidedWithObject.transform.SetParent(null);

                    collidedWithObject.GetComponent<Rigidbody>().AddForce(throwDirection.normalized, ForceMode.Impulse);

                    collidedWithObject = null;
                }
            }
        }


        //if we want to throw the object, then we need to store the position that the hand was in when we presssed the trigger
        // and the position when we let go of the trigger
        
    }


    private void OnTriggerEnter(Collider other)
    {


        collidedWithObject = other.gameObject;

        other.gameObject.transform.SetParent(this.transform);   //if we've collided with an object, then set the transform's parent to this grabber hand

    }
    

}