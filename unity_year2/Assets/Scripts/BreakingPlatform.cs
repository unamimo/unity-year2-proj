using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingPlatform : MonoBehaviour
{

    [SerializeField]
    private float breakTime;
    private int soundIndex = 1;

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
        soundIndex = UnityEngine.Random.Range(1, 6);
        switch (soundIndex)
        {
            case 1:
                FindObjectOfType<AudioControl>().Play("Thud1", false);
                break;
            case 2:
                FindObjectOfType<AudioControl>().Play("Thud2", false);
                break;
            case 3:
                FindObjectOfType<AudioControl>().Play("Thud3", false);
                break;
            case 4:
                FindObjectOfType<AudioControl>().Play("Thud4", false);
                break;
            case 5:
                FindObjectOfType<AudioControl>().Play("Thud5", false);
                break;
            default:
                break;
        }
        gameObject.SetActive(false);
    }
}
