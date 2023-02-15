using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator DoorAnim;
    private bool doorOpen = false;

    public void Awake()
    {
        DoorAnim = gameObject.GetComponent<Animator>();
    }

    public void changeposition()
    {
        if (!doorOpen)
        {
            /*gameObject.transform.position += new Vector3(0, 5, 0);
            doorOpen = true;*/

            //DoorAnim.Play("DoorSlideUp", 0, 0.0f);
            DoorAnim.SetBool("doorOpening", true);
        }
    }
}
