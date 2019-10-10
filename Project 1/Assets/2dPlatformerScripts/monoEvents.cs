using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class monoEvents : MonoBehaviour {
    public UnityEvent startEvent;
    public ArtData playerData;
    public GameObject player;
    public CameraMovement camScript;
    public terrainTrigger resetTrigger;

    private void Start() {
        player = playerData.InstancePlayer();
        startEvent.Invoke();
        camScript.SetPlayer(player);
        resetTrigger.SetPlayer(player);
    }
}
