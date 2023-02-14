using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateMovingPlatforms : MonoBehaviour
{
    public GameObject movingplatforms;
    // Start is called before the first frame update
    void Start()
    {
        movingplatforms.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            print("OPENED!");
            movingplatforms.SetActive(true);
            Destroy(this.gameObject);

        }
    }
}
