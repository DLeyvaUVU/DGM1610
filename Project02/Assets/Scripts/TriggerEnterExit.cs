using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEnterExit : TriggerEvent {
    public UnityEvent exitEvent;
    

    private void OnTriggerExit(Collider other) {
        exitEvent.Invoke();
        
    }
}
