using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableLight : MonoBehaviour {
    public Light lightComponent;
    void ToggleLight() {
        lightComponent.enabled = !lightComponent.enabled;
    }
}
