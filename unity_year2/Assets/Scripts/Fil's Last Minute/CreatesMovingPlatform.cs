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
    private Collider p_Collider;
    private MeshRenderer p_Renderer;

    void Start()
    {
        m_Collider = GetComponent<BoxCollider>();
        p_Renderer = platform.GetComponent<MeshRenderer>();
        p_Collider = platform.GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            p_Renderer.enabled = true;
            p_Collider.enabled = true;
            this.gameObject.GetComponent<CreatesMovingPlatform>().enabled = false;
        }
    }
}
