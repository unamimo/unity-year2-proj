using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameController _gameController;

    [SerializeField]
    private int checkpointNo;


    // Start is called before the first frame update
    void Start()
    {
        _gameController = GameObject.Find("GameManager").GetComponent<GameController>();
        _gameController.checkpoints[checkpointNo - 1] = this.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_gameController.currentCheckpoint < checkpointNo)
            {
                _gameController.currentCheckpoint = checkpointNo;
            }

        }

    }
}
