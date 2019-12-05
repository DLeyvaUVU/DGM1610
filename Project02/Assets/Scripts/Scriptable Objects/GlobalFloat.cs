using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalFloat : ScriptableObject {
    public float maxValue = 10;
    public float minValue = 0;
    public float currentValue = 10;
    public float magnitude = 1;
    public UnityAction updateAction;

    public void UpdateValue(int input) {
        currentValue += input;
        currentValue = Mathf.Clamp(currentValue, minValue, maxValue);
        magnitude = currentValue / maxValue;
        updateAction();
    }
}
