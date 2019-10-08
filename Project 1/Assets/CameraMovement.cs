using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class CameraMovement : MonoBehaviour
{
    public bool PlayerFocus;//tells the camera whether or not to follow the player
    public CharacterController CameraControl;//I want to use the move function of this, but a more optimal solution would be to use Vector2.SmoothDamp() and forego most of this entirely
    public GameObject Player;//so I can set it within the editor
    private Vector2 playerPosition;
    private Vector2 CamPosition;
    public float minSpeed = 3;//otherwise the camera would take longer to get to the target.
    public float camSizeRoom;
    public float camSizePlayer;
    public Camera cam;
    private void Start()
    {
        PlayerFocus = true;
    }

    public void SetPlayer(GameObject newPlayer) {
        Player = newPlayer;
    }

    public IEnumerator CameraSnap(Vector2 newFocus)//used for snapping the camera to the center of a room (only called within characterControl.cs)
    {
        while (CamPosition != newFocus && Vector2.Distance(newFocus, CamPosition) > .05)
        {
            MoveTowardsTarget(newFocus);
            yield return null;//makes it so the loop completes over time
        }
        yield return null;
    }
    private Vector2 getDirection(Vector2 source, Vector2 target) {//I did this manually to understand how it works even though there is probably a Vector2 function that does the same thing.
        var angleVector = target - source;
        angleVector /= angleVector.magnitude;//normalizes so the length is one
        return angleVector;
    }
    public IEnumerator camZoom (float newZoom) {
        //float camAdjust;
        //float adjustDirection = Mathf.Sign(cam.orthographicSize - newZoom);
        float camSpeed = 0f;
        while (cam.orthographicSize != newZoom) {
            cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, newZoom, ref camSpeed, 0.5f);
            yield return null;
        }
        yield return null;
    }
    private void MoveTowardsTarget(Vector2 target) {//I made it a function because I would be doing essentially the same thing in more than one place
        Vector2 direction = getDirection(CamPosition, target);
        float distance = Vector2.Distance(CamPosition, target);//at this point I felt comfortable enough to just use the built in functions and not do this manually
        CameraControl.Move(Time.deltaTime*(Mathf.Pow(distance, 2)+minSpeed)*direction);
    }
    private void Update()
    {
        CamPosition = transform.position;
        playerPosition = Player.transform.position;
        if (PlayerFocus && Vector2.Distance(playerPosition, CamPosition) > .05) {
            MoveTowardsTarget(playerPosition);
        }
    }
}
