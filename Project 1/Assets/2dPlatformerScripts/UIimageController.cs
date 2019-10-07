using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Image))]
public class UIimageController : MonoBehaviour {
    private Image img;
    private Coroutine animCoroutine;
    private float animDirection = 1;
    private void Awake() {
        img = GetComponent<Image>();
    }
    private IEnumerator animateFill(float magnitude) {
        // animDirection = (magnitude - img.fillAmount >= 0) ? 1 : -1;
        // for (float distance = animDirection * (magnitude - img.fillAmount); distance > 0) {

        // }
        yield return null;
    }
    public void UpdateImage(FloatData data) {
        if (animCoroutine != null) {
            StopCoroutine(animCoroutine);
        }
        animCoroutine = StartCoroutine(animateFill(data.magnitude));
        //img.fillAmount = data.magnitude;
    }
}
