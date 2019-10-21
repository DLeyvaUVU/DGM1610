using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : AxisBasedMovement {
    public bool rooted = false, stunned = false, confused = false;
    
    public virtual void Update() {
        if (Input.GetButtonDown("Jump") && jumpCount < maxJump) {
            jumpCount++;
            movementVector.y = jumpVector;
        }
        MoveX(stunned? 0: rooted? 0: Input.GetAxis("Horizontal"));//can only move if you aren't stunned or rooted
        if (movementManip.isGrounded) {
            jumpCount = 0;
        }
        movementVector.y = ApplyGravity(movementVector.y);
        if (momentum != Vector2.zero) {
            ZeroMomentum();
        }
    }
}
