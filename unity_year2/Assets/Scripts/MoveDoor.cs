using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDoor : MonoBehaviour
{
    [SerializeField] GameObject SlidingDoor;

    bool isOpened = false;
    private int soundIndex = 1;

    private void OnTriggerEnter(Collider other)
    {
        if(!isOpened)
        {
            PlayDoorSound();
            isOpened = true;
            SlidingDoor.transform.position += new Vector3(0, 5, 0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayDoorSound();
        SlidingDoor.transform.position = new Vector3(6.37f, 0.96f, 7.22f);
        isOpened = false;
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
