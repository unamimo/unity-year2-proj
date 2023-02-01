///////////////////////////////
///with reference from SpeedTutor: https://www.youtube.com/watch?v=6bFCQqabfzo
/////////////////////////////////


using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [Header("Pickup Settings")]
    [SerializeField] Transform holdArea;
    [SerializeField] Transform MainCamera;
    private GameObject heldObj;
    private Rigidbody heldObjRB;
    private BoxCollider objCollider;

    [Header("Physics Parameters")]
    [SerializeField] private float pickupRange = 5.0f;
    [SerializeField] private float pickupForce = 150.0f;
    [SerializeField] private float rotateSpeed = 100.0f;
   
    private void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.red, pickupRange);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObj == null)
            {
                //pickup object when there is no held object and E is pressed
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
                {
                    PickupObject(hit.transform.gameObject);
                }
            }
            else
            {
                //if there is a object being held when we press E, drop the object
                DropObject();
            }
        }
        if (heldObj != null)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
            {
                if (hit.collider.tag == "Environment")
                {
                    Debug.Log("it's the environment");
                    DropObject();
                }
                else if (hit.collider.tag == "Player")
                {
                    Debug.Log("it's the player");
                }
                if (Input.GetKeyDown(KeyCode.R))
                {
                    Vector3 moveDirection = (holdArea.position - heldObj.transform.position);
                    heldObjRB.AddForce(transform.forward * pickupForce * 30);
                    DropObject();
                }
                RotateObject();
            }
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
            heldObjRB.transform.rotation = Quaternion.identity;

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

    void RotateObject()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            Debug.Log("Rotated left");
            heldObjRB.constraints = RigidbodyConstraints.None;
            heldObjRB.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.X))
        {
            Debug.Log("Rotated right");
            heldObjRB.constraints = RigidbodyConstraints.None;
            heldObjRB.transform.Rotate(Vector3.down * rotateSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.C))
        {
            Debug.Log("Rotated down");
            heldObjRB.constraints = RigidbodyConstraints.None;
            heldObjRB.transform.Rotate(Vector3.left * rotateSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.V))
        {
            Debug.Log("Rotated up");
            heldObjRB.constraints = RigidbodyConstraints.None;
            heldObjRB.transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
        }
    }
}
