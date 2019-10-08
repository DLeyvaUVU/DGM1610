using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class globalVar : ScriptableObject {
    public GameObject player;

    public void SetPlayer(GameObject newPlayer) {
        player = newPlayer;
    }
}
