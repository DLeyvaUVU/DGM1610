using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageUIController : MonoBehaviour {
    public float animSpeed = 0.01f;
    public float animPower = 2;
    public Coroutine animCoroutine;
    public Image img;
    public GlobalFloatWithColor data;
    public bool useGradient = false;

    private void Awake() {
        img = GetComponent<Image>();
        img.type = Image.Type.Filled;
        img.color = data.colorRange.Evaluate(1);
    }

    private void UpdateColor() {
        if (useGradient) {
            img.color = data.colorRange.Evaluate(img.fillAmount);
        }
    }

    private IEnumerator AnimateLinear(float newFill) {
        while (!Mathf.Approximately(img.fillAmount, newFill)) {
            img.fillAmount = Mathf.MoveTowards(img.fillAmount, newFill, animSpeed * Time.deltaTime);
            UpdateColor();
            yield return null;
        }
        UpdateColor();
    }

    private IEnumerator AnimateSnap(float newFill) {
        float snapVector = Mathf.Abs(newFill - img.fillAmount);
        while (!Mathf.Approximately(img.fillAmount, newFill)) {
            snapVector = Mathf.Pow(Mathf.Abs(newFill - img.fillAmount), animPower) + animSpeed;
            snapVector *= Time.deltaTime;
            img.fillAmount = Mathf.MoveTowards(img.fillAmount, newFill, snapVector);
            UpdateColor();
            yield return null;
        }
        UpdateColor();
    }

    public virtual void UpdateImage() {
        img.fillAmount = data.magnitude;
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
