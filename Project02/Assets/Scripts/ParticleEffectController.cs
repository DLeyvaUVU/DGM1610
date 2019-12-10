using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(ParticleSystem))]
public class ParticleEffectController : MonoBehaviour {
    public ParticleSystem effectSystem;
    public int emitAmount = 10;
    public EffectData colorData;

    private void Awake() {
        effectSystem = GetComponent<ParticleSystem>();
        var sysMain = effectSystem.main;
        sysMain.startColor = colorData.particleColor;
    }

    void Start()
    {
        effectSystem.Emit(10);
        Destroy(gameObject, 2);
    }
}
