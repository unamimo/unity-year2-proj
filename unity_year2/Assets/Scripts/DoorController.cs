using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private bool doorOpen = false;

    public void changeposition()
    {
        if (!doorOpen)
        {
            gameObject.transform.position += new Vector3(0, 5, 0);
            doorOpen = true;
        }
    }
}
