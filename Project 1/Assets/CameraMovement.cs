using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Vector3 CamFocus;
    public CharacterController CameraControl;
    public GameObject Player;
    private Vector3 CamPosition;
    public float SnapSpeed;
    public float CamSpeed;

    private void Start()
    {
        CamFocus = Player.transform.position;
    }

    public IEnumerator CameraSnap(Vector3 newFocus)
    {
        while (CamPosition != newFocus)
        {
            transform.position = Vector3.MoveTowards(transform.position, newFocus, SnapSpeed * Time.deltaTime);
        }
        CamFocus = newFocus;
        return null;
    }
    private void Update()
    {
        CamPosition = transform.position;
        /*if (CamFocus == Player.transform.position)
        {
            
        }*/
    }
}
