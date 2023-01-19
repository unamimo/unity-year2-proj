using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [Header("Pickup Settings")]
    [SerializeField] Transform holdArea;
    private GameObject heldObj;
    private Rigidbody heldObjRB;

    [Header("Physics Parameters")]
    [SerializeField] private float pickupRange = 5.0f;
    [SerializeField] private float pickupForce = 150.0f;
   
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(heldObj == null)
            {
                //pickup object on condition of there currently being no held object
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
                {
                    PickupObject(hit.transform.gameObject);
                }
            }
            else
            {
                //if there is a object being held, drop the object
                DropObject();
            }
            
            if (heldObj != null)
            {
               MoveObject();
            }
        }
    }

    void MoveObject()
    {
        if (Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 moveDirection = (holdArea.position - heldObj.transform.position);
            heldObjRB.AddForce(moveDirection * pickupForce);
        }
    }

    void PickupObject(GameObject pickupobj)
    {
        if (pickupobj.GetComponent<Rigidbody>())
        {
            heldObjRB = pickupobj.GetComponent<Rigidbody>();
            heldObjRB.useGravity = false;
            heldObjRB.drag = 10;
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;

            //moves the object position to the direction the player is facing using the camera (holdArea)
            heldObjRB.transform.parent = holdArea;
            heldObj = pickupobj;
        }
    }

    //basically just reversing the effects of PickupObject() func. 
    void DropObject()
    {
        heldObjRB.useGravity = true; //the object falls when it is not being held anymore
        heldObjRB.drag = 1;
        heldObjRB.constraints = RigidbodyConstraints.None; //resets the constraints 

        //moves the object position to the direction the player is facing using the camera (holdArea)
        heldObj.transform.parent = null;
        heldObj = null;
    }
}
