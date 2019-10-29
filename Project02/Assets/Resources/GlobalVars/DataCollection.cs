using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class DataCollection : ScriptableObject {
    public List<Collectible> collectionList;

    public void ClearList() {
        int i = collectionList.Count;
        collectionList.RemoveRange(0, i);
    }

    public void AddData(Collectible newCollectible) {
        if (newCollectible.isUnique) {
            collectionList.Add(newCollectible);
        }
        if (!collectionList.Contains(newCollectible)) {
            collectionList.Add(newCollectible);
        }
        collectionList.Sort();
        newCollectible.count++;
    }
}
