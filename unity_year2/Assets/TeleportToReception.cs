using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToReception : MonoBehaviour
{
    public Vector3 receptionTP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.Translate(receptionTP);
        print("TP");
    }
}
