using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerController : AxisBasedMovement {
    public bool rooted = false, stunned = false, confused = false;
    public GlobalFloat health;
    private SpriteRenderer spriteRend;
    public GameArtData artData;
    public override void Awake() {
        base.Awake();
        spriteRend = GetComponent<SpriteRenderer>();
        spriteRend.sprite = artData.art;
        spriteRend.color = artData.artColor;
    }

    public void ShiftUp(float shiftFactor) {
        MoveXY(0, shiftFactor);
    }
    public void ShiftRight(float shiftFactor) {
        MoveXY(shiftFactor, 0);
    }
    public void ShiftLeft(float shiftFactor) {
        MoveXY(-shiftFactor, 0);
    }
    public void ShiftDown(float shiftFactor) {
        MoveXY(0, -shiftFactor);
    }
    public virtual void Update() {
        if (Input.GetButtonDown("Jump") && jumpCount < maxJump) {
            jumpCount++;
            movementVector.y = jumpVector;
        }

        running = Input.GetButton("Run") ? true : false;
        MoveX(stunned? 0: rooted? 0: Input.GetAxis("Horizontal")); //can only move if you aren't stunned or rooted
        if (movementManip.isGrounded) {
            jumpCount = 0;
        }
        movementVector.y = ApplyGravity(movementVector.y);
        if (momentum != Vector2.zero) {
            ZeroMomentum();
        }
    }
}
