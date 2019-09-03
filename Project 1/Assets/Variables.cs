using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

public class Variables : MonoBehaviour
{
    public float floatValue = 5.5f;
    public int intValue = 20;
    public string stringValue = "Bob";
    public UnityEvent Event;
    private void OnTriggerEnter(Collider other)
    {
        //Event.Invoke();
        ParticleSystem explosion = other.gameObject.GetComponent(typeof(ParticleSystem)) as ParticleSystem;
        explosion.Emit(100);
    }
}
