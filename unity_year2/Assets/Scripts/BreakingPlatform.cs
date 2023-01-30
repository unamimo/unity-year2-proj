using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingPlatform : MonoBehaviour
{

    [SerializeField]
    private float breakTime;

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
        if (other.CompareTag("Player"))
        {
            StartCoroutine(BreakDown());
        }
    }

    IEnumerator BreakDown()
    {
        Debug.Log("Waiting...");
        yield return new WaitForSeconds(breakTime);
        Debug.Log("Drop");
        FindObjectOfType<AudioControl>().Play("Fall");
        gameObject.SetActive(false);
    }
}
