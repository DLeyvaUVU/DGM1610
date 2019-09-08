using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public bool PlayerFocus;
    public CharacterController CameraControl;
    public GameObject Player;
    private Vector3 CamPosition;
    private Vector2 Direction;
    public float SnapSpeed = 5;
    public float CamSpeed = 3;
    private Vector2 PlayerDistance;

    private void Start()
    {
        PlayerFocus = true;
    }

    public IEnumerator CameraSnap(Vector3 newFocus)
    {
        while (CamPosition != newFocus && Vector2.Distance(newFocus, CamPosition) > .05)
        {
            getDirection(CamPosition, newFocus);
            CameraControl.Move(Direction*Vector2.Distance(newFocus, CamPosition)*SnapSpeed*Time.deltaTime);
            yield return null;
        }
        yield return null;
    }
    private void getDirection(Vector2 source, Vector2 target) {
        Direction = target - source;
        Direction /= Direction.magnitude;
    }
    private void Update()
    {
        CamPosition = transform.position;
        if (PlayerFocus && Vector2.Distance(Player.transform.position, CamPosition) > .05) {
            getDirection(CamPosition, Player.transform.position);
            CameraControl.Move(Direction*Vector2.Distance(CamPosition, Player.transform.position)*CamSpeed*Time.deltaTime);
        }
    }
}
