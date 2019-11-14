using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class TriggerEvent : BaseEventScript {
    private void Start() {
        var triggerCollider = GetComponent<Collider>();
        triggerCollider.isTrigger = true;
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other) {
        baseEvent.Invoke();
    }
}
