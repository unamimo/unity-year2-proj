using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBox : MonoBehaviour
{
    public GameObject player;
    public GameObject respawnloc;
    private bool hasSetPos = false;
    private CharacterController playerCC;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        playerCC = player.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Vector3 respawnlocation = respawnloc.transform.position;
            playerCC.enabled = false;
            player.transform.position = respawnlocation;
            playerCC.enabled = true;
        }
    }
}
