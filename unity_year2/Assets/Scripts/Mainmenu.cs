using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mainmenu : MonoBehaviour
{

    private bool isPlaying = false;
    private bool isQuitting = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void playbutton()
    {
        isPlaying = true;
    }
    private void quitting()
    {
        isQuitting = true;
    }
}
