using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : StartEvent {
    public GameObject mainCam;
    public PlayerData selectedPlayer;
    public GameObject playerInstance;
    public UnityEvent pauseEvent;
    private bool paused = false;
    private void Awake() {
        selectedPlayer.instanceAction = SetPlayer;
        selectedPlayer.InstantiateObject(transform.position);
    }
    private void SetPlayer(GameObject obj) {
        playerInstance = obj;
        var camScript = mainCam.GetComponent<SnapMovement>();
        camScript.SetTarget(playerInstance.transform);
    }

    public void ToggleActive(GameObject obj) {
        obj.SetActive(!obj.activeSelf);
    }
    private void Update() {
        if (Input.GetButtonDown("Submit")) {
            pauseEvent.Invoke();
            paused = !paused;
            Time.timeScale = paused ? 0 : 1;
        }
    }
}
