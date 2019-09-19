using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class cController : MonoBehaviour {
    public CharacterController player;
    public float terminalVelocity, gravity = 9.81f, jumpVector, speedVector;
    private Vector3 movementVector;
    private int jumpCount;

    private void Start() {
        player = GetComponent<CharacterController>();
    }

    private void Move(float inputX) {
        movementVector.x = inputX * speedVector;
        float verticalMagnitude = Mathf.Abs(movementVector.y);
        if (!player.isGrounded) {
            movementVector.y -= gravity * Time.deltaTime;
            if (verticalMagnitude > terminalVelocity) {
                movementVector.y = -terminalVelocity;
            }
        }
        player.Move(movementVector * Time.deltaTime);
    }

    private void Update() {
        Move(Input.GetAxis("Horizontal"));
        if (Input.GetButtonDown("Jump") && jumpCount < 1) {
            movementVector.y = jumpVector;
            jumpCount++;
        }

        if (player.isGrounded) {
            jumpCount = 0;
        }
    }
}
