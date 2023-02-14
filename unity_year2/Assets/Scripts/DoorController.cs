using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    //private Animator DoorAnim;
    public bool doorOpen = false;
    public bool doorAccessed = false;
    public float openingSpeed = 5f;

    [SerializeField] private GameObject door;


    public void Awake()
    {
        //DoorAnim = gameObject.GetComponent<Animator>();
    }

    public void moveDoorUp()
    {
        Debug.Log("moveDoorUp function entered");
        transform.Translate(0, openingSpeed * Time.deltaTime, 0);
        doorOpen = true;
    }

}
