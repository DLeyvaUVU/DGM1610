﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class cController : MonoBehaviour {
    public CharacterController player;
    public float terminalVelocity, gravity = 9.81f, jumpVector, speedVector, charSpeed, runSpeed;
    private bool busy = false;
    private Vector3 movementVector;
    private int jumpCount;
    public ParticleSystem charge;
    private ParticleSystem.ShapeModule chargeShapeModule;
    private Coroutine initCharge;

    private void Start() {
        player = GetComponent<CharacterController>();
        chargeShapeModule = charge.shape;
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

    private IEnumerator BulletTimeFire(Vector3 initialMovement) {
        initCharge = StartCoroutine(ChargeEffect());
        while (Input.GetButton("Fire2")) {
            movementVector *= 0;
            yield return null;
        }

        if (initCharge != null) {
            StopCoroutine(initCharge);
        }
        movementVector = initialMovement;
        busy = false;
        chargeShapeModule.radiusThickness = 0;
        print("shoot projectile in direction of mouse or left stick on controller");
        //at this point I would shoot something, but I'm not quite sure how to do that yet.
    }

    private IEnumerator ChargeEffect() {
        int counter = 1;
        while (Input.GetButton("Fire2")) {
            charge.Emit(5*counter);
            counter++;
            chargeShapeModule.radiusThickness += .01f;
            yield return new WaitForSeconds(.5f);
        }

        chargeShapeModule.radiusThickness = 0;
    }
    private void Update() {
        if (!busy) {
            Move(Input.GetAxis("Horizontal"));
        }
        if (Input.GetButtonDown("Jump") && jumpCount < 1) {
            movementVector.y = jumpVector;
            jumpCount++;
        }
        speedVector = Input.GetButton("Run") ? runSpeed : charSpeed;
        if (player.isGrounded) {
            jumpCount = 0;
        }

        if (Input.GetButtonDown("Fire2") && !player.isGrounded) {
            busy = true;
            StartCoroutine(BulletTimeFire(movementVector));
        }
    }
}
