using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InstancerData : ScriptableObject {
    public UnityAction<GameObject> instanceAction;
    public GameArtData artData;
    public GameObject prefab;

    public void InstantiateObject(Vector3 instancePosition) {
        var objectInstance = Instantiate(prefab);
        objectInstance.transform.position = instancePosition;
        instanceAction(objectInstance);
    }
}
