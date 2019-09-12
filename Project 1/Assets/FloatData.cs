using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class FloatData : ScriptableObject
{
    public float maxValue;
    public float currentValue;
    public float magnitude;

    public void AdjustValue(int input) {
        currentValue += input;
        if (currentValue < 0) {
            currentValue = 0;
        }
        magnitude = currentValue / maxValue;
    }
}
