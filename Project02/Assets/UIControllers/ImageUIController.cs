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

    private void Awake() {
        img = GetComponent<Image>();
        img.type = Image.Type.Filled;
    }

    private IEnumerator AnimateLinear(float newFill) {
        while (!Mathf.Approximately(img.fillAmount, newFill)) {
            img.fillAmount = Mathf.MoveTowards(img.fillAmount, newFill, animSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator AnimateSnap(float newFill) {
        float snapVector = Mathf.Abs(newFill - img.fillAmount);
        while (!Mathf.Approximately(img.fillAmount, newFill)) {
            snapVector = Mathf.Pow(Mathf.Abs(newFill - img.fillAmount), animPower) + animSpeed;
            snapVector *= Time.deltaTime;
            img.fillAmount = Mathf.MoveTowards(img.fillAmount, newFill, snapVector);
            yield return null;
        }
    }

    public void UpdateImage(GlobalFloat data) {
        img.fillAmount = data.magnitude;
    }

    public void UpdateImageLinear(GlobalFloat data) {
        if (animCoroutine != null) {
            StopCoroutine(animCoroutine);
        }
        animCoroutine = StartCoroutine(AnimateLinear(data.magnitude));
    }
    public void UpdateImageSnap(GlobalFloat data) {
        if (animCoroutine != null) {
            StopCoroutine(animCoroutine);
        }
        animCoroutine = StartCoroutine(AnimateSnap(data.magnitude));
    }
}
