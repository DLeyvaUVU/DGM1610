using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.Experimental.XR;

public class AxisBasedMovement : BaseMovementController
{
    public Vector2 momentum = Vector2.zero;
    public float moveSpeed = 5f, runMultiplier = 2, gravity = 9.8f, jumpVector = 10f, maxJump = 1, terminalVelocity = 20, friction = 3;
    public bool running = false;

    public float ApplyGravity(float fallAxis) {
        if (!movementManip.isGrounded) {
            fallAxis -= gravity * Time.deltaTime;
            float fallMagnitude = Mathf.Abs(fallAxis);
            if (fallMagnitude > terminalVelocity) {
                fallAxis = -terminalVelocity;
            }
        }
        else {
            fallAxis = -gravity;
        }
        return fallAxis;
    }
    public void MoveX(float input) {
        movementVector.x = moveSpeed;
        movementVector.x *= running ? runMultiplier * input : input;
        movementManip.Move((movementVector + momentum) * Time.deltaTime);
    }

    public void MoveY(float input) {
        movementVector.y = moveSpeed;
        movementVector.y *= running ? runMultiplier * input : input;
        movementManip.Move((movementVector + momentum) * Time.deltaTime);
    }

    public void MoveXY(float inputX, float inputY) {
        movementVector.x = moveSpeed * inputX;
        movementVector.y = moveSpeed * inputY;
        if (running) {
            movementVector *= runMultiplier;
        }
        movementManip.Move((movementVector + momentum) * Time.deltaTime);
    }

    public void MoveToTargetXY(Vector2 target) {
        current2AxisPosition = transform.position;
        movementVector = GetDirection(current2AxisPosition, target);
        movementVector *= running ? moveSpeed * runMultiplier : moveSpeed;
        movementManip.Move((movementVector + momentum) * Time.deltaTime);
    }

    public void ZeroMomentum() {
        Vector2 momentumRef = Vector2.zero;
        momentum = Vector2.SmoothDamp(momentum, Vector2.zero, ref momentumRef, friction);
    }
}
