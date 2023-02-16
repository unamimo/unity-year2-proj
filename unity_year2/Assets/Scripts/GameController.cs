using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{

    private static GameController _gameController = null;
    public int score = 0;
    public int currentCheckpoint = 0;
    static int totalCheckpoints = 2;
    private Camera _Camera;
    public InputAction startAction;
    public InputAction pauseAction;
    public InputAction clickButton;
    public GameObject[] checkpoints = new GameObject[totalCheckpoints];

    public GameObject credits;
    public GameObject mainmenu;

    private void OnEnable()
    {
        startAction.Enable();
        pauseAction.Enable();
    }

    private void OnDisable()
    {
        startAction.Disable();
        pauseAction.Disable();
    }

    public enum EGameState
    {
        MainMenu ,
        Playing ,
        Paused ,
        Gameover,
        Win
    }
    private EGameState _eGameState = EGameState.MainMenu; //game will begin at the main menu

    void Awake()
    {
        //Assert to verify only one game controller exists
        Debug.Assert(_gameController == null, this.gameObject);

        //Assign our static reference to this one we just created
        _gameController = this;
        SceneManager.LoadScene("LevelBlockout", LoadSceneMode.Additive);
    }
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioControl>().Play("MenuTheme", true);
        Cursor.visible = true;
        _Camera = Camera.main; //_Camera cached as the primary one
        GameObject.Find("HUD").GetComponent<Canvas>().enabled = false; //hide the UI whilst in the main menu
        GameObject.Find("MainMenu").GetComponent<Canvas>().enabled = true;
        GameObject.Find("PauseMenu").GetComponent<Canvas>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentCheckpoint);
        switch (_eGameState)
        { //checks made every frame depending on the current game state
            case EGameState.MainMenu:
                _Camera.transform.position = new Vector3(50, 0, -10); 
                //move camera to main menu screen
                //UnityEngine.Debug.Log("CHECKING");
                // if (Input.GetKeyDown(KeyCode.P))
                Cursor.visible = true;
                if (startAction.triggered)
                {
                    
                    RestartGame(); //refresh game scene
                    ChangeState(EGameState.Playing);

                }
                break;

            case EGameState.Playing:
                // if (Input.GetKeyDown(KeyCode.Escape))
                Cursor.visible = false;
                if (pauseAction.triggered)
                    ChangeState(EGameState.MainMenu); //pause the game when escape is pressed
                /*
                if (something)
                {
                    ChangeState(EGameState.Win); //win when there are no more enemies remaining
                }
                */
                break;

            case EGameState.Paused:
                if (pauseAction.triggered)
                    ChangeState(EGameState.Playing); //resume back to playing if escape is pressed again
                break;

            case EGameState.Gameover:
                _Camera.transform.position = new Vector3(70, 0, -10); //move camera to game over screen
                if (startAction.triggered)
                {
                    ChangeState(EGameState.MainMenu);
                }
                break;

            case EGameState.Win:
                _Camera.transform.position = new Vector3(90, 0, -10); //move camera to win screen
                if (startAction.triggered)
                {
                    ChangeState(EGameState.Playing);
                }
                break;


            default:
                throw new System.ArgumentOutOfRangeException(); //raise exception if game is somehow in a state different to the aforementioned
        }


    }

    public void startGame()
    {
        RestartGame();
        ChangeState(EGameState.Playing);
    }
    public void exitgame()
    {
        Application.Quit();
    }
    public void creditButton()
    {
        mainmenu.SetActive(false);
        credits.SetActive(true);
    }
    public void backtoMainMenu()
    {
        mainmenu.SetActive(true);
        credits.SetActive(false);
    }

    public void ChangeState(EGameState eGameState)
    {
        Debug.Log("#Change State - " + eGameState);
        switch (eGameState) //statements to be run once depending on the game state
        {
            ////////////////////////////////////////////////////////////////
            case EGameState.MainMenu:
                FindObjectOfType<AudioControl>().Play("MenuTheme", true);
                Cursor.visible = true;
                GameObject.Find("HUD").GetComponent<Canvas>().enabled = false; //hide the UI whilst in the main menu
                GameObject.Find("MainMenu").GetComponent<Canvas>().enabled = true;
                GameObject.Find("PauseMenu").GetComponent<Canvas>().enabled = false;
                //GameObject.Find("Buttons").GetComponent<Canvas>().enabled = true; 
                Time.timeScale = 0.0f; //flow of time in the game is multiplied by 0, consequently stopping anything from moving or spawning
                break;
            ////////////////////////////////////////////////////////////////
            case EGameState.Playing:
                Cursor.visible = false;
                GameObject.Find("HUD").GetComponent<Canvas>().enabled = true;
                GameObject.Find("MainMenu").GetComponent<Canvas>().enabled = false;
                GameObject.Find("PauseMenu").GetComponent<Canvas>().enabled = false;
                Time.timeScale = 1.0f; //resume flow of time
                break;
            ////////////////////////////////////////////////////////////////
            case EGameState.Gameover:
                GameObject.Find("HUD").GetComponent<Canvas>().enabled = false;
                GameObject.Find("PauseMenu").GetComponent<Canvas>().enabled = false;
                Time.timeScale = 0.0f;
                break;
            ////////////////////////////////////////////////////////////////
            case EGameState.Win:
                FindObjectOfType<AudioControl>().Play("CreditsTheme", true);
                GameObject.Find("HUD").GetComponent<Canvas>().enabled = false;
                GameObject.Find("PauseMenu").GetComponent<Canvas>().enabled = false;
                Time.timeScale = 0.0f;
                break;
            ////////////////////////////////////////////////////////////////
            case EGameState.Paused:
                GameObject.Find("PauseMenu").GetComponent<Canvas>().enabled = true;
                Time.timeScale = 0.0f;
                break;
            ////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////
            // The game is in an invalid state
            default:
                throw new System.ArgumentOutOfRangeException();
                ////////////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////////
        }
        // Set our state to the new state
        _eGameState = eGameState;
    }

    public void RestartGame()
    {

        //Check whether there is already an active Game scene. If so, unload it.
        if (SceneManager.sceneCount > 1)
        {
            Debug.Log("Unloading Game Scene");
            SceneManager.UnloadSceneAsync("LevelBlockout");
        }
        
        //Load a new game scene, resetting all assets within it
        SceneManager.LoadScene("LevelBlockout", LoadSceneMode.Additive);

        
        score = 0; //reset the score


    }
    public EGameState GetState()
    {
        return _eGameState;
    }
}
