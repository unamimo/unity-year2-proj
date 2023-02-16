using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator DoorAnim;
    private bool doorOpen = false;
    public float rotateAmount = 90.0f;
    private float duration = 0.75f;
    private float elapsed = 0.0f;
    private float elapsedPercent = 0.0f;
    Quaternion start;
    Quaternion end;

    public void Awake()
    {
        DoorAnim = gameObject.GetComponent<Animator>();
    }

    void Start()
    {
        Vector3 degrees = new Vector3(0, 0, rotateAmount);
        start = gameObject.transform.rotation;
        end = start * Quaternion.Euler(degrees);
    }

    void Update()
    {
        if ((doorOpen == true) && (elapsedPercent < 1))
        {
            elapsed += Time.deltaTime;
            elapsedPercent = elapsed / duration;
            elapsedPercent = Mathf.SmoothStep(0, 1, elapsedPercent);

            gameObject.transform.rotation = Quaternion.Slerp(start, end, elapsedPercent);
            
        }
        


    }

    public void changeposition()
    {
        if (!doorOpen)
        {
            doorOpen = true;

            


            if (gameObject.tag == "MultiKey")
            {
                DoorAnim.Play("DoorSlideUp", 0, 0.0f);
                DoorAnim.SetBool("doorOpening", true);
            }
            
        }
    }
}
