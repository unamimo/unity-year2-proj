using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDoor : MonoBehaviour
{
    [SerializeField] GameObject SlidingDoor;

    bool isOpened = false;
    bool doorclosing;
    private float openingSpeed = 5f;
    public Vector3 initialPos;

    private void Start()
    {
        Vector3 initialPos = SlidingDoor.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!isOpened)
        {
            isOpened = true;
            //SlidingDoor.transform.position += new Vector3(0, 5, 0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //SlidingDoor.transform.position = new Vector3(6.37f, 0.96f, 7.22f);
        doorclosing = true;
        isOpened = false;
    }

    private void Update()
    {
        if (isOpened)
        {
            SlidingDoor.transform.Translate(0, openingSpeed * Time.deltaTime, 0);
        }
        if (Vector3.Distance(initialPos, SlidingDoor.transform.position) > 15)
        {

            isOpened = false;
        }

        if(doorclosing)
        {
            SlidingDoor.transform.Translate(0, -openingSpeed * Time.deltaTime, 0);
        }
        if (Vector3.Distance(initialPos, SlidingDoor.transform.position) < 10)
        {
            doorclosing = false;
        }
    }
}
