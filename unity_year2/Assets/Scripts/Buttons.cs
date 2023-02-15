using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    private GameController _gameController;

    // Start is called before the first frame update
    void Start()
    {
        
        _gameController = GameObject.Find("GameManager").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changeStatePlay()
    {
        _gameController.RestartGame();
        Cursor.visible = false;
        _gameController.ChangeState(GameController.EGameState.Playing);
    }

    public void quitButton()
    {
        Application.Quit();
    }
}
