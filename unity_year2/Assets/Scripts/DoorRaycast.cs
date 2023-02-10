using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorRaycast : MonoBehaviour
{
    [SerializeField] private int RayLength = 5;
    [SerializeField] private LayerMask LayerMaskInteract;
    [SerializeField] private string ExcludeLayerName = null;

    private DoorController raycastedObj;

    [SerializeField] private Image crosshair = null;
    private bool isCrosshairActive;
    private bool doOnce;

    private Inventory inventory;
    public GameObject _player;

    private void Start()
    {
        inventory = GameObject.Find("PlayerCapsule").GetComponent<Inventory>();
    }

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(ExcludeLayerName) | LayerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, RayLength, mask))
        {
            if(hit.collider.CompareTag("RedKey") || hit.collider.CompareTag("BlueKey") || hit.collider.CompareTag("Key") || hit.collider.CompareTag("MultiKey"))
            {
                if(!doOnce)
                {
                    raycastedObj = hit.collider.gameObject.GetComponent<DoorController>();
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;

                if(Input.GetKeyDown(KeyCode.E))
                {
                    if (hit.collider.CompareTag("RedKey"))
                    {
                        if (_player.GetComponent<Inventory>().RedKeyNum > 0)
                        {
                            Debug.Log("Red Key used");
                            raycastedObj.changeposition();
                        }
                    }
                    if (hit.collider.CompareTag("BlueKey"))
                    {
                        if (_player.GetComponent<Inventory>().BlueKeyNum > 0)
                        {
                            Debug.Log("Green Key used");
                            raycastedObj.changeposition();
                        }
                    }
                    if (hit.collider.CompareTag("Key"))
                    {
                        if (_player.GetComponent<Inventory>().KeyNum > 0)
                        {
                            Debug.Log("Green Key used");
                            raycastedObj.changeposition();
                        }
                    }
                    if (hit.collider.CompareTag("MultiKey"))
                    {
                        if (_player.GetComponent<Inventory>().KeyNum > 0 && _player.GetComponent<Inventory>().BlueKeyNum > 0 && _player.GetComponent<Inventory>().RedKeyNum > 0)
                        {
                            raycastedObj.changeposition();
                        }
                    }
                }
            }
        }
        else
        {
            if(isCrosshairActive)
            {
                CrosshairChange(false);
                doOnce = false;
            }
        }

        void CrosshairChange(bool on)
        {
            if(on && !doOnce)
            {
                crosshair.color = Color.red;
            }
            else
            {
                crosshair.color = Color.white;
                isCrosshairActive = false;
            }
        }
    }
}
