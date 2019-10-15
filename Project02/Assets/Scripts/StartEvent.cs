using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEvent : BaseEventScript
{
    private void Start() {
        baseEvent.Invoke();
    }
}
