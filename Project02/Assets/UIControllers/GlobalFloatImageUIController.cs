using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class GlobalFloatImageUIController : MonoBehaviour {
    public float animSpeed = 0.01f;
    public float animPower = 2;
    public Coroutine animCoroutine;
    public Image uiImage;
    public GlobalFloatWithColor data;
    public bool useGradient = false;
    public AnimType updateMode = AnimType.Instant;
    private void Awake() {
        uiImage = GetComponent<Image>();
        uiImage.type = Image.Type.Filled;
        uiImage.color = data.colorRange.Evaluate(1);
        switch (updateMode) {
            case AnimType.Snap:
                data.updateAction = UpdateImageSnap;
                break;
            case AnimType.Linear:
                data.updateAction = UpdateImageLinear;
                break;
            case AnimType.Instant:
                data.updateAction = UpdateImage;
                break;
        }
    }

    public enum AnimType {
       Snap, Linear, Instant 
    }
    private void UpdateColor() {
        if (useGradient) {
            uiImage.color = data.colorRange.Evaluate(uiImage.fillAmount);
        }
    }

    private IEnumerator AnimateLinear(float newFill) {
        while (!Mathf.Approximately(uiImage.fillAmount, newFill)) {
            uiImage.fillAmount = Mathf.MoveTowards(uiImage.fillAmount, newFill, animSpeed * Time.unscaledDeltaTime);
            UpdateColor();
            yield return null;
        }
        UpdateColor();
    }

    private IEnumerator AnimateSnap(float newFill) {
        float snapVector = Mathf.Abs(newFill - uiImage.fillAmount);
        while (!Mathf.Approximately(uiImage.fillAmount, newFill)) {
            snapVector = Mathf.Pow(Mathf.Abs(newFill - uiImage.fillAmount), animPower) + animSpeed;
            snapVector *= Time.unscaledDeltaTime;
            uiImage.fillAmount = Mathf.MoveTowards(uiImage.fillAmount, newFill, snapVector);
            UpdateColor();
            yield return null;
        }
        UpdateColor();
    }

    public virtual void UpdateImage() {
        uiImage.fillAmount = data.magnitude;
        UpdateColor();
    }

    public void UpdateImageLinear() {
        if (animCoroutine != null) {
            StopCoroutine(animCoroutine);
        }
        animCoroutine = StartCoroutine(AnimateLinear(data.magnitude));
    }
    public void UpdateImageSnap() {
        if (animCoroutine != null) {
            StopCoroutine(animCoroutine);
        }
        animCoroutine = StartCoroutine(AnimateSnap(data.magnitude));
    }
}
