using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class cController : MonoBehaviour {
    public CharacterController player;
    public float terminalVelocity, gravity = 9.81f, jumpVector, speedVector, charSpeed, runSpeed;
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

    public IEnumerator BulletTimeFire(Vector3 initialMovement) {
        while (Input.GetButton("Fire2")) {
            yield return null;
        }
        movementVector = initialMovement;
    }
    private void Update() {
        Move(Input.GetAxis("Horizontal"));
        if (Input.GetButtonDown("Jump") && jumpCount < 1) {
            movementVector.y = jumpVector;
            jumpCount++;
        }
        if (Input.GetButton("Run")) {
            speedVector = runSpeed;
        }
        else {
            speedVector = charSpeed;
        }
        if (player.isGrounded) {
            jumpCount = 0;
        }

        // if (Input.GetButtonDown("Fire2")) {
        //     StartCoroutine(BulletTimeFire(movementVector));
        // }
    }
}
