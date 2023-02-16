using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class BlurController : MonoBehaviour
{
    private GameController _gameController; // for game state checking

    //game objects
    public GameObject blurCanvas;   // the canvas itself
    public GameObject blurMoreCanvas;
    public GameObject blurEvenMoreCanvas;
    public GameObject maxBlur;

    private void Start()
    {
        _gameController = GameObject.Find("GameManager").GetComponent<GameController>();
        //blurCanvas = GameObject.Find("Blur - TURN CANVAS BACK ON AFTER TESTING");

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_gameController.currentCheckpoint == 0)
            {
                blurCanvas.SetActive(false);
                blurMoreCanvas.SetActive(true);
                blurEvenMoreCanvas.SetActive(false);
                maxBlur.SetActive(false);
                Debug.Log("First check point "+_gameController.currentCheckpoint);
                this.gameObject.SetActive(false);
            }

            if (_gameController.currentCheckpoint == 1)
            {
                blurCanvas.SetActive(false);
                blurMoreCanvas.SetActive(false);
                blurEvenMoreCanvas.SetActive(true);
                maxBlur.SetActive(false);
                Debug.Log("Second check point " + _gameController.currentCheckpoint);
                this.gameObject.SetActive(false);
            }

            if (_gameController.currentCheckpoint == 2)
            {
                blurCanvas.SetActive(false);
                blurMoreCanvas.SetActive(false);
                blurEvenMoreCanvas.SetActive(false);
                maxBlur.SetActive(true);
                Debug.Log("Third check point " + _gameController.currentCheckpoint);
                this.gameObject.SetActive(false);
            }
        }
    }
}
