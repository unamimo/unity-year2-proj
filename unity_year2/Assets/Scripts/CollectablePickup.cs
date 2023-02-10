using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Inventory inventory = other.GetComponent<Inventory>();

        if (inventory != null && gameObject.tag == "Key")
        {
            inventory.KeysCollected();
            gameObject.SetActive(false);
        }
        if (inventory != null && gameObject.tag == "RedKey")
        {
            inventory.RedKeysCollected();
            gameObject.SetActive(false);
        }
        if (inventory != null && gameObject.tag == "BlueKey")
        {
            inventory.BlueKeysCollected();
            gameObject.SetActive(false);
        }

    }

}
