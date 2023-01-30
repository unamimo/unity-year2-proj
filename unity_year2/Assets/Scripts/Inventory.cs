using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    //only this script can set the value but other scripts can get it
    public int KeyNum { get; private set; }
    public int RedKeyNum { get; private set; }
    public int GreenKeyNum { get; private set; }
    
    public UnityEvent<Inventory> OnKeyCollect;

    public void KeysCollected()
    {
        KeyNum++;
        OnKeyCollect.Invoke(this);
    }

    public void RedKeysCollected()
    {
        RedKeyNum++;
        OnKeyCollect.Invoke(this);
    }

    public void GreenKeysCollected()
    {
        GreenKeyNum++;
        OnKeyCollect.Invoke(this);
    }
}
