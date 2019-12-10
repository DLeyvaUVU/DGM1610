using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class InstancerData : ScriptableObject {
    public UnityAction<GameObject> instanceAction;
    public GameObject prefab;

    public void InstantiateObject(Vector3 instancePosition) {
        var objectInstance = Instantiate(prefab);
        objectInstance.transform.position = instancePosition;
        instanceAction(objectInstance);
    }

    public void InstantiateObject(Transform creationAnchor) {
        var objectInstance = Instantiate(prefab);
        objectInstance.transform.position = creationAnchor.position;
    }
}
