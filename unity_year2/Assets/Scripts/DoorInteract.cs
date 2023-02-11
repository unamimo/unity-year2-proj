using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorInteract : MonoBehaviour
{
    public Transform cam;
    public float ActivationDistance;
    bool active = false;
    private Inventory inventory;
    public GameObject _player;
    public InputAction openDoor;
    private int soundIndex = 1;

    private void OnEnable()
    {
        openDoor.Enable();
    }

    private void OnDisable()
    {
        openDoor.Disable();
    }

    private void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
    }

    public void Update()
    {
        RaycastHit hit;
        active = Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, ActivationDistance);

        if (openDoor.triggered && active == true)
        {
            if(gameObject.tag == "BlueKey")
            {
                if (_player.GetComponent<Inventory>().BlueKeyNum > 0)
                {
                    //PlayDoorSound();
                    Debug.Log("Blue Key used");
                    gameObject.transform.position += new Vector3(0, 5, 0);
                }
                else
                {
                   //FindObjectOfType<AudioControl>().Play("DoorLocked", false);
                }
            }
            if(gameObject.tag == "RedKey")
            {
                if (_player.GetComponent<Inventory>().RedKeyNum > 0)
                {
                    //PlayDoorSound();
                    Debug.Log("Red Key used");
                    gameObject.transform.position += new Vector3(0, 5, 0);
                }
                else
                {
                    //FindObjectOfType<AudioControl>().Play("DoorLocked", false);
                }
            }
        }
    }

    void PlayDoorSound()
    {
        soundIndex = Random.Range(1, 4);
        switch (soundIndex)
        {
            case 1:
                FindObjectOfType<AudioControl>().Play("DoorSwing1", false);
                break;
            case 2:
                FindObjectOfType<AudioControl>().Play("DoorSwing2", false);
                break;
            case 3:
                FindObjectOfType<AudioControl>().Play("DoorSwing3", false);
                break;
            default:
                break;
        }
       
    }
}
