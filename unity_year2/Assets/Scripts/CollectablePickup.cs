using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Inventory inventory = other.GetComponent<Inventory>();

        if (inventory != null && gameObject.tag == "Collectable")
        {
            inventory.KeysCollected();
            gameObject.SetActive(false);
        }
    }

}
