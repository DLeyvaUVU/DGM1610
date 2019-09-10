using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public bool PlayerFocus;//tells the camera whether or not to follow the player
    public CharacterController CameraControl;//I want to use the move function of this, but a more optimal solution would be to use Vector2.SmoothDamp() and forego most of this entirely
    public GameObject Player;//so I can set it within the editor
    public Vector3 playerPosition;
    private Vector3 CamPosition;
    public float minSpeed = 3;//otherwise the camera would take longer to get to the target.
    private void Start()
    {
        PlayerFocus = true;
    }

    public IEnumerator CameraSnap(Vector3 newFocus)//used for snapping the camera to the center of a room
    {
        while (CamPosition != newFocus && Vector2.Distance(newFocus, CamPosition) > .05)
        {
            moveTowardsTarget(newFocus);
            yield return null;//makes it so the loop completes over time
        }
        yield return null;//this coroutine is never called within the script, but it is called 
    }
    private Vector2 getDirection(Vector2 source, Vector2 target) {//I did this manually to understand how it works even though there is probably a Vector2 function that does the same thing.
        Vector2 angleVector;
        angleVector = target - source;//get the heading
        angleVector /= angleVector.magnitude;//normalizes so the length is one
        return angleVector;
    }
    private void moveTowardsTarget(Vector2 target) {//I made it a function because I would be doing essentially the same thing in more than one place
        Vector2 Direction = getDirection(CamPosition, target);
        float distance = Vector2.Distance(CamPosition, target);//at this point I felt comfortable enough to just use the built in functions and not do this manually
        CameraControl.Move(Direction*(Mathf.Pow(distance, 2)+minSpeed)*Time.deltaTime);
    }
    private void Update()
    {
        CamPosition = transform.position;
        playerPosition = Player.transform.position;
        if (PlayerFocus && Vector2.Distance(playerPosition, CamPosition) > .05) {
            StopAllCoroutines();//not necessary, but if I ever need to call my coroutine directly within this script, it might be
            moveTowardsTarget(Player.transform.position);
        }
    }
}
