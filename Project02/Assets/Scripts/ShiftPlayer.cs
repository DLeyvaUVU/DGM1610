using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftPlayer : MonoBehaviour {
    public float strength;
    public Direction shiftDirection = Direction.Up;
    public GameObject target;
    public enum Direction {
        Up, Right, Down, Left
    }

    private void Shift(GameObject obj) {
        switch (shiftDirection) {
            case Direction.Up:
                obj.SendMessage("ShiftUp", strength);
                break;
            case Direction.Right:
                obj.SendMessage("ShiftRight", strength);
                break;
            case Direction.Left:
                obj.SendMessage("ShiftLeft", strength);
                break;
            case Direction.Down:
                obj.SendMessage("ShiftDown", strength);
                break;
        }
    }

    private void OnTriggerEnter(Collider other) {
        target = other.gameObject;
    }

    private void OnTriggerStay(Collider other) {
        Shift(target);
    }
}
