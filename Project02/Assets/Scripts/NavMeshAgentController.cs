using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshAgentController : MonoBehaviour {
    public NavMeshAgent agentAI;
    public Transform currentTarget;
    void Start() {
        agentAI = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update() {
        agentAI.destination = currentTarget.position;
    }
}
