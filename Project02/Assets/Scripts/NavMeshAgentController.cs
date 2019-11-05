using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshAgentController : MonoBehaviour {
    public NavMeshAgent agentAI;
    public Transform currentTarget;
    private void Awake() {
        agentAI = GetComponent<NavMeshAgent>();
    }
}
