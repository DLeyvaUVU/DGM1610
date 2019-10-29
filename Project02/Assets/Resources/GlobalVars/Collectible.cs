using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Collectible : ScriptableObject {
    public int count = 0;
    public GameArtData icon;
    public bool isUnique = false;
}
