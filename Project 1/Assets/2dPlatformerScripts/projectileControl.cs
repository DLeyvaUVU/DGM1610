using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileControl : MonoBehaviour
{
    public varData variableSet;
    private float power;
    private float speed;
    private bool pierce;
    private int bounce;
    public Vector3 directionVector;

    private void Start() {
        power = variableSet.floatValue[0];
        speed = variableSet.floatValue[1];
        pierce = variableSet.boolValue[0];
        bounce = variableSet.intValue[0];
    }

    public void SetDirection(Vector2 newDirection) {
        directionVector = newDirection;
    }

    private void Update() {
        transform.Translate(speed * Time.deltaTime * directionVector);
    }
}
