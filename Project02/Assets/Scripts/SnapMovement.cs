using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapMovement : BaseMovementController {
    public bool moveContinuously = false;
    public Transform currentTarget, previousTarget;
    public Vector2 targetPosition;
    public int minSpeed = 1, speedExponent = 2;
    private Coroutine snapRoutine;
    

    public void ToggleMoveMode() {
        moveContinuously = !moveContinuously;
    }

    public void SetMoveMode(bool input) {
        moveContinuously = input;
    }

    public void SetTarget(Transform newTarget) {
        previousTarget = currentTarget;
        currentTarget = newTarget;
        targetPosition = currentTarget.position;
    }

    public void ReturnToPreviousTarget() {
        currentTarget = previousTarget;
        targetPosition = currentTarget.position;
    }

    public void MoveToTarget(Vector2 target) {
        current2AxisPosition = transform.position;
        float distance = 0f;
        Vector2 direction = GetDirectionWithDistance(current2AxisPosition, targetPosition, ref distance);
        movementVector = Time.deltaTime * (Mathf.Pow(distance, speedExponent) + minSpeed) * direction;
        if (movementVector.magnitude > distance) {
            movementVector = movementVector.normalized * distance;
        }
        movementManip.Move(movementVector);
    }

    public IEnumerator SnapAndHold(Transform target, float holdTime) {
        float distance;
        bool initialMoveMode = moveContinuously;
        moveContinuously = true;
        SetTarget(target);
        distance = Vector2.Distance(current2AxisPosition, targetPosition);
        while (!Mathf.Approximately(0.0f, distance)) {
            distance = Vector2.Distance(current2AxisPosition, targetPosition);
            yield return null;
        }
        yield return new WaitForSeconds(holdTime);
        ReturnToPreviousTarget();
        distance = Vector2.Distance(current2AxisPosition, targetPosition);
        while (!Mathf.Approximately(0.0f, distance)) {
            distance = Vector2.Distance(current2AxisPosition, targetPosition);
            yield return null;
        }
        moveContinuously = initialMoveMode;
    }

    public void QuickSnap(Transform quickTarget) {
        if (snapRoutine != null) {
            StopCoroutine(snapRoutine);
        }
        snapRoutine = StartCoroutine(SnapAndHold(quickTarget, 0.1f));
    }

    private void Update() {
        if (moveContinuously) {
            current2AxisPosition = transform.position;
            targetPosition = currentTarget.position;
            MoveToTarget(targetPosition);
        }
    }
}