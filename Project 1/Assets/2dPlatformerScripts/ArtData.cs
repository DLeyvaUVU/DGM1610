using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ArtData : ScriptableObject {
    public Sprite sprite;
    public Color color;
    public GameObject prefab;

    public void InstancePlayer() {
        var newPlayer = Instantiate(prefab);
        var playerSprite = newPlayer.GetComponentInChildren<SpriteRenderer>();
        playerSprite.color = color;
        playerSprite.sprite = sprite;
    }
}
