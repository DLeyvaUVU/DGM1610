using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GlobalFloat : ScriptableObject {
    public int maxValue = 10;
    public int minValue = 0;
    public int currentValue = 10;
    public float magnitude = 1;

    public void UpdateValue(int input) {
        currentValue += input;
        if (currentValue > maxValue) {
            currentValue = maxValue;
        }

        if (currentValue < minValue) {
            currentValue = minValue;
        }

        magnitude = currentValue / maxValue;
    }
}
