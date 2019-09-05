﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    //modifying your sample script "SimpleCharacterControl.cs" to fit my needs
    private Vector2 moveVector;
    private CharacterController character;
    public GameObject Camera;
    public float charSpeed = 2;

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

    private void OnTriggerEnter(Collider other)
    {
        Camera.CameraSnap(other.transform.position);
    }

    private void Update()
    {
        //gets two inputs to actually move across two axes
        Move(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
    }
}
