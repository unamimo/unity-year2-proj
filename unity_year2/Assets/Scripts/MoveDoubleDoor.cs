using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDoubleDoor : MonoBehaviour
{
    [SerializeField] GameObject SlidingDoor1;
    [SerializeField] GameObject SlidingDoor2;

    bool isOpened = false;
    public float openingSpeed = 5f;
    public float maxDistanceUp = 5;
    private float currentSpeed = 0f;
    [HideInInspector]
    public Vector3 initialPos1;
    [HideInInspector]
    public Vector3 newPos1;
    [HideInInspector]
    public Vector3 initialPos2;
    [HideInInspector]
    public Vector3 newPos2;

    private void Start()
    {
        initialPos1 = SlidingDoor1.transform.position;
        newPos1 = new Vector3(initialPos1.x, initialPos1.y + maxDistanceUp, initialPos1.z);

        initialPos2 = SlidingDoor2.transform.position;
        newPos2 = new Vector3(initialPos2.x, initialPos2.y - maxDistanceUp, initialPos2.z);
    }


    private void OnTriggerEnter(Collider other)
    {

        isOpened = true;

        /*
        isOpened = true;

        if (SlidingDoor.transform.localPosition.y > initialPos.y + maxDistanceUp)
        {
            currentSpeed = openingSpeed;
        }
        else
        {
            currentSpeed = 0;
        }
        */
        //SlidingDoor.transform.position += new Vector3(0, 5, 0);

    }

    private void OnTriggerExit(Collider other)
    {

        isOpened = false;
        /*
        currentSpeed = -openingSpeed;
        //SlidingDoor.transform.position = new Vector3(6.37f, 0.96f, 7.22f);
        doorclosing = true;
        isOpened = false;
        */
    }

    private void Update()
    {

        if (isOpened == true)
        {
            SlidingDoor1.transform.position = Vector3.MoveTowards(SlidingDoor1.transform.position, newPos1, Time.deltaTime * openingSpeed);
            SlidingDoor2.transform.position = Vector3.MoveTowards(SlidingDoor2.transform.position, newPos2, Time.deltaTime * openingSpeed);
        }
        else
        {
            SlidingDoor1.transform.position = Vector3.MoveTowards(SlidingDoor1.transform.position, initialPos1, Time.deltaTime * openingSpeed);
            SlidingDoor2.transform.position = Vector3.MoveTowards(SlidingDoor2.transform.position, initialPos2, Time.deltaTime * openingSpeed);
        }
        // SlidingDoor.transform.Translate(0, currentSpeed * Time.deltaTime, 0);

        /*
        if ((isOpened == true) && (Vector3.Distance(initialPos, SlidingDoor.transform.position) < maxDistanceUp))
        {
            currentSpeed = openingSpeed;
        }
        else if ((isOpened == false) && (doorclosing == true) && (Vector3.Distance(initialPos, SlidingDoor.transform.position) < maxDistanceDown)) 
        {
            currentSpeed = -openingSpeed;
        }
        else
        {
            currentSpeed = 0;
        }
        */
        /*
        if (isOpened)
        {
            SlidingDoor.transform.Translate(0, openingSpeed * Time.deltaTime, 0);
        }
        
        if (Vector3.Distance(initialPos, SlidingDoor.transform.position) > maxDistanceUp)
        {

            isOpened = false;
        }
        

        if(doorclosing)
        {
            SlidingDoor.transform.Translate(0, -openingSpeed * Time.deltaTime, 0);
        }
        if (Vector3.Distance(initialPos, SlidingDoor.transform.position) < maxDistanceDown)
        {
            doorclosing = false;
        }
        */
    }
}

