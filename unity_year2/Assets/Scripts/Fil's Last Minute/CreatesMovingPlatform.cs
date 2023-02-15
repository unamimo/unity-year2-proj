using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatesMovingPlatform : MonoBehaviour
{


    /// What this script should do: 
    ///  When pressure plate is pressed = instantiate a moving platform upstairs
    ///  Then --> disable this script/this objects collider --> so that only one platform is made
    ///  Also --> maybe plays a directional audio cue?


    private Collider m_Collider;
    public GameObject platform;

    void Start()
    {
        m_Collider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            platform.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
