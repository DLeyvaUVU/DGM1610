using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class PlayerSwitcherScript : MonoBehaviour {
    public GameObject mainCam;
    public PlayerData selectedPlayer;
    public GameObject playerInstance;
    public SpriteRenderer icon;
    private Coroutine animRoutine;

    private void Awake() {
        GetComponent<Collider>().isTrigger = true;
        icon.sprite = selectedPlayer.artData.art;
        icon.color = selectedPlayer.artData.artColor;
    }

    private void OnTriggerEnter(Collider other) {
        selectedPlayer.instanceAction = SetPlayer;
        if (other.gameObject != playerInstance) {
            selectedPlayer.InstantiateObject(transform.position);
            StartCoroutine(FixPosition());/*I cannot for the life of me figure out
            why the object is getting moved to 0 immediately after instantiating, 
            especially since it doesn't happen at the beginning of the game. 
            So I made a coroutine to wait a frame to fix the position as 
            the bug moving it to zero happens at the end of the frame as far as I can tell*/
            Destroy(other.gameObject, 0.2f);
        }
        else {
            if (animRoutine != null) {
                StopCoroutine(animRoutine);
            }
            animRoutine = StartCoroutine(AnimateInteraction());
        }
    }

    private IEnumerator FixPosition() {
        yield return null;
        yield return null;
        playerInstance.transform.position = transform.position;
        var camScript = mainCam.GetComponent<SnapMovement>();
        camScript.SetTarget(playerInstance.transform);
    }

    private IEnumerator AnimateInteraction() {
        var newColor = icon.color;
        for (float i = 0f; i < 0.8f; i += 0.05f) {
            newColor.a = i;
            icon.color = newColor;
            yield return null;
        }
        for (float i = 0.2f; i < 1; i += 0.05f) {
            newColor.a = i;
            icon.color = newColor;
            yield return null;
        }
    }
    private void SetPlayer(GameObject obj) {
        playerInstance = obj;
    }
}
