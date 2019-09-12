using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterControl : MonoBehaviour
{
    //modifying your sample script "SimpleCharacterControl.cs" to fit my needs
    private Vector2 moveVector;
    private CharacterController character;
    public CameraMovement CameraScript;
    public float charSpeed = 2;
    public UnityEvent doThing;

    private void OnMouseDown() {
        doThing.Invoke();
    }
    

    private void Start()
    {
        character = GetComponent<CharacterController>();
        //I can technically make this public and just set it in the editor instead of using this code
    }

    private void Move(float inputY, float inputX)//need two axes to move in a 2d space
    {
        moveVector.x = inputX;
        moveVector.y = inputY;
        moveVector = moveVector*charSpeed*Time.deltaTime;
        character.Move(moveVector);//wasn't sure if this function accepted a Vector2 but it works
    }

    private void OnTriggerEnter(Collider other){//snaps to rooms, would need some adjustments if I put anything else in the scene other than rooms and the player
        StopAllCoroutines();//make sure the coroutine doesn't interfere with itself whenever I start it
        CameraScript.PlayerFocus = !CameraScript.PlayerFocus;
        StartCoroutine(CameraScript.CameraSnap(other.transform.position));
    }
    private void OnTriggerExit(Collider other) {//go back to following the player
        StopAllCoroutines();//make sure the coroutine doesn't interfere with itself whenever I start it
        CameraScript.PlayerFocus = !CameraScript.PlayerFocus;
    }

    private void Update()
    {
        //gets two inputs to actually move across two axes
        Move(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
    }
}
