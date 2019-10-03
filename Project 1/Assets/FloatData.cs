using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class FloatData : ScriptableObject
{
    public float maxValue;
    public float currentValue;
    public float magnitude = 1f;

    public void AdjustValue(int input) {
        currentValue += input;
        if (currentValue <= 0) {
            currentValue = maxValue;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (currentValue >= maxValue) {
            currentValue = maxValue;
        }
        magnitude = currentValue / maxValue;
    }
}
