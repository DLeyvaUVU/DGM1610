using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableScript : BaseEventScript {
    private void OnEnable() {
        baseEvent.Invoke();
    }
}
