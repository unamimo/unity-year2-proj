using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI ThisKeyText;
    // Start is called before the first frame update
    void Start()
    {
        ThisKeyText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateKeyText(Inventory inventory)
    {
        if(gameObject.tag == "Key")
        {
            ThisKeyText.text = inventory.KeyNum.ToString();
        }
        if(gameObject.tag == "RedKey")
        {
            ThisKeyText.text = inventory.RedKeyNum.ToString();
        }
        if(gameObject.tag == "GreenKey")
        {
            ThisKeyText.text = inventory.GreenKeyNum.ToString();
        }
    }
}
