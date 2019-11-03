using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]
public class TextUIController : MonoBehaviour {
    public Text uiText;
    public List<string> textContent;
    public string currentText, nextText;

    public enum TextAnimType {
        Slow, Medium, Fast, DoubleFast, Instant
    }
    public virtual void Awake() {
        uiText = GetComponent<Text>();
        
    }

    public void UpdateText() {
        uiText.text = String.Empty;
        foreach (var textItem in textContent) {
            uiText.text += textItem;
        }
    }
}
