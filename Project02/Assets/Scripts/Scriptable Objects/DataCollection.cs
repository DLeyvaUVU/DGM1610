using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu]
public class DataCollection : ScriptableObject {
    public enum ListType {
        Collectible, Subweapon
    }
    public List<Collectible> collectibleList;
    public List<Subweapon> subweaponList;
    public int winCondition;

    public void ClearList(int selection) {
        ListType listSelection = (ListType)selection;
        int i = 0;
        switch (listSelection) {
            case ListType.Collectible:
                i = collectibleList.Count;
                collectibleList.RemoveRange(0, i);
                break;
            case ListType.Subweapon:
                i = subweaponList.Count;
                subweaponList.RemoveRange(0, i);
                break;
        }
    }

    public void CheckWin() {
        if (collectibleList.Count >= winCondition) {
            Debug.Log("You win, I guess.");
        }
    }
    public void ClearAllLists() {
        collectibleList.Clear();
        subweaponList.Clear();
    }

    public void AddData(Collectible newCollectible) {
        if (newCollectible.isUnique) {
            collectibleList.Add(newCollectible);
        }
        else {
            newCollectible.count++;
        }
        if (!collectibleList.Contains(newCollectible)) {
            collectibleList.Add(newCollectible);
        }
        collectibleList.Sort();
        CheckWin();
    }

    public void AddData(Subweapon newSubweapon) {
        if (!subweaponList.Contains(newSubweapon)) {
            subweaponList.Add(newSubweapon);
        }
        subweaponList.Sort();
    }
}
