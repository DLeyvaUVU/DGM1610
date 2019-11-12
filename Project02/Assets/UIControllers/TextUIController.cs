using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]
public class TextUIController : MonoBehaviour {
    public Text uiText;
    public List<string> textContent;
    public string currentText, nextText;
    public TextAnimType textSpeed = TextAnimType.Slow;
    private Coroutine textAnim;
    private WaitForSecondsRealtime wfsSlow = new WaitForSecondsRealtime(0.1f);
    private WaitForSecondsRealtime wfsMedium = new WaitForSecondsRealtime(0.05f);
    public enum TextAnimType {
        Slow, Medium, Fast, DoubleFast, Instant
    }
    public virtual void Awake() {
        uiText = GetComponent<Text>();
        
    }

    public void AddText(string newItem) {
        textContent.Add(newItem);
    }

    public void AddText(float newItem) {
        textContent.Add(newItem.ToString());
    }
    public void AddText(int newItem) {
        textContent.Add(newItem.ToString());
    }
    public void UpdateText() {
        uiText.text = String.Empty;
        nextText = String.Join(" ", textContent);
        if (textSpeed == TextAnimType.Instant) {
            uiText.text = nextText;
        }
        else {
            if (textAnim != null) {
                StopCoroutine(textAnim);
            }

            textAnim = StartCoroutine(AnimateText());
        }
    }

    public IEnumerator AnimateText() {
        var textChars = nextText.ToCharArray();
        bool waiting = true;
        foreach (var textChar in textChars) {
            uiText.text += textChar;
            switch (textSpeed) {
                case TextAnimType.DoubleFast:
                    if (waiting) {
                        waiting = false;
                    }
                    else {
                        waiting = true;
                        yield return null;
                    }
                    break;
                case TextAnimType.Fast:
                    yield return null;
                    break;
                case TextAnimType.Medium:
                    yield return wfsMedium;
                    break;
                case TextAnimType.Slow:
                    yield return wfsSlow;
                    break;
                
            }

        }
    }
}
