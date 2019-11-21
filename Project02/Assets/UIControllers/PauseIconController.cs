using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseIconController : MonoBehaviour {
    public GameArtData icon;
    public Image uiImage;
    public Color imageColor = Color.gray;
    private Coroutine animCoroutine;
    public float enabledAlpha = 1;

    private void Awake() {
        uiImage = GetComponent<Image>();
        Mathf.Clamp01(enabledAlpha);
        UpdateAlpha(0f);
    }
    public void FadeAlpha(float newAlpha) {
        if (animCoroutine != null) {
            StopCoroutine(animCoroutine);
        }

        animCoroutine = StartCoroutine(AnimateAlpha(newAlpha));
    }
    public void UpdateAlpha(float newAlpha) {
        Mathf.Clamp01(newAlpha);
        imageColor.a = newAlpha;
        uiImage.color = imageColor;
    }

    public void UpdateImage(GameArtData newIcon) {
        icon = newIcon;
        uiImage.sprite = icon.art;
        uiImage.useSpriteMesh = true;
        imageColor = icon.artColor;
    }

    public IEnumerator AnimateAlpha(float newAlpha) {
        float startAlpha = imageColor.a;
        for (float i = 0; i < 1; i += 2f * Time.unscaledDeltaTime) {
            UpdateAlpha(Mathf.Lerp(startAlpha, newAlpha, i));
            yield return null;
        }
        UpdateAlpha(newAlpha);
    }
    private void OnEnable() {
        FadeAlpha(enabledAlpha);
    }

    private void OnDisable() {
        UpdateAlpha(0);
    }
}
