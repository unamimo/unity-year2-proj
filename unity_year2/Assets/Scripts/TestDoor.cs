using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDoor : MonoBehaviour
{
    public bool isOpen = false;
    [SerializeField]
    private bool isRotatingDoor = true;
    [SerializeField]
    private float Speed = 1f;
    [Header("Rotation Configs")]
    [SerializeField]
    private float RotationAmount = 90f;
    [SerializeField]
    private float ForwardDirection = 0;

    private Vector3 StartRotation;
    private Vector3 Forward;

    private Coroutine AnimationCoroutine;

    private void Awake()
    {
        StartRotation = transform.rotation.eulerAngles;
        Forward = transform.right;
    }

    public void Open(Vector3 UserPosition)
    {
        if (!isOpen)
        {
            if(AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);
            }

            if(isRotatingDoor)
            {
                // dot calculates where in relation to the player is the door 
                // means that the door opens away from the player
                float dot = Vector3.Dot(Forward, (UserPosition - transform.position).normalized);
                AnimationCoroutine = StartCoroutine(DoRotationOpen(dot));
            }
        }
    }

    private IEnumerator DoRotationOpen(float ForwardAmount)
    {
        Quaternion StartRotation = transform.rotation;
        Quaternion EndRotation;

        //which way is the door rotating?
        if (ForwardAmount >= ForwardDirection)
        {
            EndRotation = Quaternion.Euler(new Vector3(0, StartRotation.y - RotationAmount, 0));
        }
        else
        {
            EndRotation = Quaternion.Euler(new Vector3(0, StartRotation.y + RotationAmount, 0));
        }

        isOpen = true;

        //lerping
        float time = 0;
        while(time < 1)
        {
            transform.rotation = Quaternion.Slerp(StartRotation, EndRotation, time);
            yield return null;
            time += Time.deltaTime * Speed;
        }
    }

    public void close()
    {
        if (!isOpen)
        {
            if (AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);
            }

            if (isRotatingDoor)
            {
                AnimationCoroutine = StartCoroutine(DoRotationClose());
            }
        }
    }

    private IEnumerator DoRotationClose()
    {
        Quaternion StartRotation = transform.rotation;
        Quaternion EndRotation = Quaternion.Euler(StartRotation.eulerAngles);

        isOpen = true;

        //lerping
        float time = 0;
        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(StartRotation, EndRotation, time);
            yield return null;
            time += Time.deltaTime * Speed;
        }
    }




}
