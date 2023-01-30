using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DoorInteract : MonoBehaviour
{
    public Transform cam;
    public float ActivationDistance;
    bool active = false;
    Inventory inventory;

    public void Update()
    {
        RaycastHit hit;
        active = Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, ActivationDistance);

        if (Input.GetKeyDown(KeyCode.E) && active == true)
        {
            if (inventory.GreenKeyNum > 0)
            {
                gameObject.transform.position += new Vector3(0, 5, 0);
            }
        }
    }
}
