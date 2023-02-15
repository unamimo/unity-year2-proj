using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class BlurAmount : MonoBehaviour
{
    private GameController _gameController;
    public GameObject blurCanvas;
    public Material blurriness;

    [SerializeField] public GameObject changeBlur;
    //[SerializeField] public GameObject blurCanvas;

    private void Start()
    {
        _gameController = GameObject.Find("GameManager").GetComponent<GameController>();
        blurCanvas = GameObject.Find("Blur - TURN CANVAS BACK ON AFTER TESTING");

        blurriness = blurCanvas.GetComponent<Material>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

        }
    }
}
