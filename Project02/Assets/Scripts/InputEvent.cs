using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputEvent : MonoBehaviour {
    public UnityEvent input;
    public string inputword;
    private void Update() {
        if (Input.GetButtonDown(inputword)) {
            input.Invoke();
        }
    }
}
