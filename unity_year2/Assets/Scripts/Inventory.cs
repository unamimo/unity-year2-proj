using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    //only this script can set the value but other scripts can get it
    public int KeyNum;
    public int RedKeyNum; 
    public int BlueKeyNum;
    
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

    public void BlueKeysCollected()
    {
        BlueKeyNum++;
        OnKeyCollect.Invoke(this);
    }
}
