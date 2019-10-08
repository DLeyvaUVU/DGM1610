using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Image))]
public class UIimageController : MonoBehaviour {
    private Image img;
    private Coroutine animCoroutine;
    public float animSpeed = .01f;//must be less than 1 and positive
    private float animDirection = 1;
    private void Awake() {
        img = GetComponent<Image>();
    }
    private IEnumerator animateFill(float magnitude) {
        animDirection = (magnitude - img.fillAmount >= 0) ? 1 : -1;//gets whether the fill needs to increase or decrease
        float distance = animDirection * (magnitude - img.fillAmount);//gets length of animation
        for (float ft = 0; ft < distance; ft += animSpeed) {
            img.fillAmount += animDirection * animSpeed;
            yield return null;
        }
        img.fillAmount = magnitude;//floating point imprecision might not make it exact, this guarantees it.
        yield return null;
    }
    public void UpdateImage(FloatData data) {
        if (animCoroutine != null) {
            StopCoroutine(animCoroutine);//stop running animation
        }
        animCoroutine = StartCoroutine(animateFill(data.magnitude));//start animation
    }
}
