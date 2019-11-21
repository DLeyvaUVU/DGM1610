using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class TimerVars : ScriptableObject {
    public WaitForSeconds wait5 = new WaitForSeconds(5f);
    public WaitForSeconds wait1 = new WaitForSeconds(1f);
    public WaitForSeconds wait10 = new WaitForSeconds(10f);
    public WaitForSecondsRealtime wait5Unscaled = new WaitForSecondsRealtime(5f);
    public WaitForSecondsRealtime wait1Unscaled = new WaitForSecondsRealtime(1f);
    public WaitForSecondsRealtime wait10Unscaled = new WaitForSecondsRealtime(10f);
}
