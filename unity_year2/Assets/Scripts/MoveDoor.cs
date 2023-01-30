using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDoor : MonoBehaviour
{
    [SerializeField] GameObject SlidingDoor;

    bool isOpened = false;

    private void OnTriggerEnter(Collider other)
    {
        if(!isOpened)
        {
            isOpened = true;
            SlidingDoor.transform.position += new Vector3(0, 5, 0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        SlidingDoor.transform.position = new Vector3(6.37f, 0.96f, 7.22f);
        isOpened = false;
    }
}
