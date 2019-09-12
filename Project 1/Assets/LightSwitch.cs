using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightSwitch : MonoBehaviour {
    public UnityEvent toggleLight;
    public ParticleSystem sparks;
    private void OnMouseDown() {
        toggleLight.Invoke();
        //sparks.Emit(5);
        
    }
}
