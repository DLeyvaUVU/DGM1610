using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class TriggerEvent : BaseEventScript {
    public Transform entryFocus;
    private void Start() {
        var triggerCollider = GetComponent<Collider>();
        triggerCollider.isTrigger = true;
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
    public void OnTriggerEnter(Collider other) {
        entryFocus = other.transform;
        baseEvent.Invoke();
    }
}
