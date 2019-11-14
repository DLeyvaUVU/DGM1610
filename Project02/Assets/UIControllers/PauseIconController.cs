using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseIconController : MonoBehaviour {
    public GameArtData icon;
    public Image uiImage;
    private Color imageColor;
    private Coroutine animCoroutine;

    private void Awake() {
        uiImage = GetComponent<Image>();
        imageColor = Color.gray;
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
        FadeAlpha(1);
    }

    private void OnDisable() {
        UpdateAlpha(0);
    }
}
