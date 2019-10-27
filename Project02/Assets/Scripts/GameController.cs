using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : StartEvent {
    public GameObject mainCam;
    public PlayerData selectedPlayer;
    public GameObject playerInstance;
    private void Awake() {
        selectedPlayer.instanceAction = SetPlayer;
        selectedPlayer.InstantiateObject(transform.position);
    }
    private void SetPlayer(GameObject obj) {
        playerInstance = obj;
        var camScript = mainCam.GetComponent<SnapMovement>();
        camScript.SetTarget(playerInstance.transform);
    }
}
