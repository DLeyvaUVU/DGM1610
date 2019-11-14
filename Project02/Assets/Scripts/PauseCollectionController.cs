using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCollectionController : MonoBehaviour {
    public DataCollection collection;
    public List<GameObject> Children;
    public List<PauseIconController> ChildScripts;
    private void Awake() {
        foreach (Transform child in transform) {
            Children.Add(child.gameObject);
        }

        foreach (var child in Children) {
            ChildScripts.Add(child.GetComponent<PauseIconController>());
        }
    }

    public void UpdateChildrenCollectibles() {
        for (int i = 0; i < collection.collectibleList.Count; i++) {
            ChildScripts[i].UpdateImage(collection.collectibleList[i].icon);
        }
    }

    public void UpdateChildrenSubweapons() {
        for (int i = 0; i < collection.subweaponList.Count; i++) {
            ChildScripts[i].UpdateImage(collection.subweaponList[i].icon);
        }
    }
}
