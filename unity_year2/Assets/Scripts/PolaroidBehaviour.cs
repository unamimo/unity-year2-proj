using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;




public class PolaroidBehaviour : MonoBehaviour
{
    public InputAction takePhotoInput;
    Texture2D capture;

    [SerializeField]
    private Image photoDisplayArea;

    private void OnEnable()
    {
        takePhotoInput.Enable();
    }

    private void OnDisable()
    {
        takePhotoInput.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        capture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (takePhotoInput.triggered)
        {
            UnityEngine.Debug.Log("yo");
            StartCoroutine(TakePhoto());
        }
    }

    IEnumerator TakePhoto()
    {
        yield return new WaitForEndOfFrame();

        Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);
        capture.ReadPixels(regionToRead, 0, 0, false);
        capture.Apply();
        ShowPhoto();
    }

    void ShowPhoto()
    {
        Sprite photoSprite = Sprite.Create(capture, new Rect(0.0f, 0.0f, capture.width, capture.height), new Vector2(0.5f, 0.5f), 100.0f);
        photoDisplayArea.sprite = photoSprite;
    }
}
