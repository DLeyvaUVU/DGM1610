using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : BaseEventScript
{
    private void OnTriggerEnter(Collider other) {
        baseEvent.Invoke();
    }
}
