using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class BaseMovementController : MonoBehaviour {
    public CharacterController movementManip;
    public Vector2 movementVector = Vector3.zero;
    public Vector2 current2AxisPosition = Vector2.zero;
    public virtual void Awake() {
        movementManip = GetComponent<CharacterController>();
        current2AxisPosition = transform.position;
    }

    public Vector2 GetDirection(Vector2 source, Vector2 target) {
        Vector2 direction = target - source;
        direction.Normalize();
        return direction;
    }

    public Vector2 GetDirectionWithDistance(Vector2 source, Vector2 target, ref float dist) {
        Vector2 direction = target - source;
        dist = direction.magnitude;
        direction.Normalize();
        return direction;
    }
}
