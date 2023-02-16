using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDoor : MonoBehaviour
{
    [SerializeField] GameObject SlidingDoor;

    bool isOpened = false;
    public float openingSpeed = 5f;
    public float maxDistanceUp = 5;
    private float currentSpeed = 0f;
    [HideInInspector]
    public Vector3 initialPos;
    [HideInInspector]
    public Vector3 newPos;
    private int soundIndex = 1;

    private void Start()
    {
        initialPos = SlidingDoor.transform.position;
        newPos = new Vector3(initialPos.x, initialPos.y + maxDistanceUp, initialPos.z);
    }


    private void OnTriggerEnter(Collider other)
    {
        
        isOpened = true;
        PlayDoorSound();
        
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
        PlayDoorSound();
        
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
            SlidingDoor.transform.position = Vector3.MoveTowards(SlidingDoor.transform.position, newPos, Time.deltaTime * openingSpeed);
        }
        else
        {
            SlidingDoor.transform.position = Vector3.MoveTowards(SlidingDoor.transform.position, initialPos, Time.deltaTime * openingSpeed);
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

    void PlayDoorSound()
    {
        soundIndex = Random.Range(1, 6);
        switch (soundIndex)
        {
            case 1:
                FindObjectOfType<AudioControl>().Play("DoorSlide1", false);
                break;
            case 2:
                FindObjectOfType<AudioControl>().Play("DoorSlide2", false);
                break;
            case 3:
                FindObjectOfType<AudioControl>().Play("DoorSlide3", false);
                break;
            case 4:
                FindObjectOfType<AudioControl>().Play("DoorSlide4", false);
                break;
            case 5:
                FindObjectOfType<AudioControl>().Play("DoorSlide5", false);
                break;
            default:
                break;
        }
    }
}
