using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;




public class PolaroidBehaviour : MonoBehaviour
{
    private GameController _gameController;
    public InputAction takePhotoInput;
    public InputAction holdUpPhoto;
    Texture2D capture;
    public Camera _Camera;
    private int soundIndex = 1;
    public float takePhotoDelay;
    private bool canTakePhoto = true;

    [SerializeField]
    private Image photoDisplayArea;
    [SerializeField]
    private RenderTexture renderTexture;

    [SerializeField]
    private GameObject cameraFlash;
    [SerializeField]
    private float flashTime;

    private void OnEnable()
    {
        takePhotoInput.Enable();
        holdUpPhoto.Enable();
    }

    private void OnDisable()
    {
        takePhotoInput.Disable();
        holdUpPhoto.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        capture = new Texture2D(Screen.width, Screen.height, TextureFormat.ARGB32, false);
        photoDisplayArea.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -1000);
        _gameController = GameObject.Find("GameManager").GetComponent<GameController>();
        cameraFlash.SetActive(false);
        _Camera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameController.GetState() != GameController.EGameState.Playing)
            return;
        if ((takePhotoInput.triggered) && !(holdUpPhoto.ReadValue<float>() > 0.1f))
            {
            StartCoroutine(TakePhoto());
        }

        if (holdUpPhoto.ReadValue<float>() > 0.1f)
        {
            photoDisplayArea.GetComponent<RectTransform>().anchoredPosition = new Vector2(-Screen.width/2 + 320, -Screen.height/2 + 330);
        }                                                                           //hacked for now, 306 = size of polaroid image / 2
        else
        {
            photoDisplayArea.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -1000);
        }
    }

    IEnumerator CameraFlashEffect()
    {
        cameraFlash.SetActive(true);
        yield return new WaitForSeconds(flashTime);
        cameraFlash.SetActive(false);
    }

    IEnumerator TakePhoto()
    {
        if (canTakePhoto)
        {
            canTakePhoto = false;
            soundIndex = Random.Range(1, 4);
            switch (soundIndex)
            {
                case 1:
                    FindObjectOfType<AudioControl>().Play("Shutter1", false);
                    break;
                case 2:
                    FindObjectOfType<AudioControl>().Play("Shutter2", false);
                    break;
                case 3:
                    FindObjectOfType<AudioControl>().Play("Shutter3", false);
                    break;
                default:
                    break;
            }
            _Camera.enabled = true;
            cameraFlash.SetActive(true);
            //_Camera.cullingMask = _Camera.cullingMask ^ (1 << 10);
            // _Camera.cullingMask = _Camera.cullingMask ^ (1 << 11);
            yield return new WaitForEndOfFrame();
            Rect regionToRead = new Rect(0, 0, renderTexture.width, renderTexture.height);
            RenderTexture currentRenderTexture = RenderTexture.active;
            RenderTexture.active = renderTexture;
            capture.ReadPixels(regionToRead, 0, 0, false);
            capture.Apply();
            ShowPhoto();
            // _Camera.cullingMask = _Camera.cullingMask ^ (1 << 10);
            // _Camera.cullingMask = _Camera.cullingMask ^ (1 << 11);
            RenderTexture.active = currentRenderTexture;
            yield return new WaitForSeconds(flashTime);
            _Camera.enabled = false;
            cameraFlash.SetActive(false);        
            yield return new WaitForSeconds(takePhotoDelay);
            canTakePhoto = true;
        }
        
    }

    void ShowPhoto()
    {
        //StartCoroutine(CameraFlashEffect());
        Sprite photoSprite = Sprite.Create(capture, new Rect(0.0f, 0.0f, capture.width, capture.height), new Vector2(0.5f, 0.5f), 100.0f);
        photoDisplayArea.sprite = photoSprite;
    }
}
