using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDoor : MonoBehaviour
{
    [SerializeField] GameObject SlidingDoor;

    bool isOpened = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "openObject" || other.gameObject.tag == "Player")
        {
            if (!isOpened)
            {
                isOpened = true;
                SlidingDoor.transform.position += new Vector3(0, 5, 0);
            }
            print("OPen");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (isOpened)
        {
            if (other.gameObject.tag == "openObject" || other.gameObject.tag == "Player")
            {
                SlidingDoor.transform.position -= new Vector3(0, 5, 0);
                isOpened = false;
                print("Closed");
            }
        }


    }
}
