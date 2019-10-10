using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class terrainTrigger : MonoBehaviour {
    public GameObject player;
    public UnityEvent triggerEvent;
    public Transform resetPoint;

    public void SetPlayer(GameObject newPlayer) {
        player = newPlayer;
    }

    private void OnTriggerEnter(Collider other) {
        player.SetActive(false);
        triggerEvent.Invoke();
        player.transform.position = resetPoint.position;
        player.SetActive(true);
    }
}
