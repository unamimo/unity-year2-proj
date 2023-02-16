using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class BlurController : MonoBehaviour
{
    private GameController _gameController; // for game state checking

    //game objects
    public GameObject blurCanvas;   // the canvas itself
    public GameObject blurLessCanvas;
    public GameObject blurEvenLessCanvas;
    public GameObject noBlur;

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
                blurLessCanvas.SetActive(true);
            }

            if (_gameController.currentCheckpoint == 1)
            {
                blurCanvas.SetActive(false);
                blurLessCanvas.SetActive(false);
                blurEvenLessCanvas.SetActive(true);
            }

            if (_gameController.currentCheckpoint == 2)
            {
                blurCanvas.SetActive(false);
                blurEvenLessCanvas.SetActive(false);
                noBlur.SetActive(true);
            }
        }
    }
}
