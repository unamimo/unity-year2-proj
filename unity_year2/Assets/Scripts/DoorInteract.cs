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
                    Debug.Log("Blue Key used");
                    gameObject.transform.position += new Vector3(0, 5, 0);
                }
            }
            if(gameObject.tag == "RedKey")
            {
                if (_player.GetComponent<Inventory>().RedKeyNum > 0)
                {
                    Debug.Log("Red Key used");
                    gameObject.transform.position += new Vector3(0, 5, 0);
                }
            }
        }
    }
}
