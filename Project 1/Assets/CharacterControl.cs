using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    //modifying your sample script "SimpleCharacterControl.cs" to fit my needs
    public Vector2 moveVector;
    private CharacterController character;
    public float charSpeed = 2;

    private void Start()
    {
        character = GetComponent<CharacterController>();
    }

    private void Move(float inputY, float inputX)
    {
        moveVector.x = inputX;
        moveVector.y = inputY;
        moveVector = transform.TransformDirection(moveVector*charSpeed*Time.deltaTime);
        character.Move(moveVector);
    }

    private void Update()
    {
        Move(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
    }
}
