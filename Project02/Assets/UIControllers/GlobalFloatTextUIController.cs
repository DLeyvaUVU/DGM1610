using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class GlobalFloatTextUIController : MonoBehaviour {
    public Text uiText;
    public GlobalFloat textContent;
    private void Awake() {
        uiText = GetComponent<Text>();
        UpdateText();
    }

    public void UpdateText() {
        float[] floatValues = {textContent.currentValue, textContent.maxValue};
        string floatValue = String.Join("/", floatValues);
        uiText.text = textContent.name + ": " + floatValue;
    }
}
