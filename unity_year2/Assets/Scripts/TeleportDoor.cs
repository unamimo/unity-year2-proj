using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportDoor : MonoBehaviour
{
    public GameObject player;
    public GameObject otherDoor;
    private CharacterController playerCC;
    private bool canEnter = true;
    Vector3 doorRotation;
    // Start is called before the first frame update
    void Start()
    {
        playerCC = player.GetComponent<CharacterController>();
        doorRotation = otherDoor.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Player") && (canEnter == true))
        {
            Vector3 tpLocation = otherDoor.transform.position;
            playerCC.enabled = false;
            player.transform.position = tpLocation;
            player.transform.eulerAngles = doorRotation;
            player.transform.position += player.transform.forward * 2;
            //player.transform.position += new Vector3(2, 0, 0);
            playerCC.enabled = true;
            canEnter = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canEnter = true;
    }
}
