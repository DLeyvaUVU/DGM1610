using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FlyingEnemyAI : NavMeshAgentController {
    public List<Transform> patrolPoints;
    public Transform chaseTarget;
    public int currentPatrolPoint;
    public float patrolPause = 0.5f, patrolSpeed = 2, chaseSpeed = 4;
    public bool patrolling = true, pausing = false;
    private Coroutine patrolRoutine;
    public PatrolState currentState = PatrolState.Patrolling;
    public TriggerEnterExit detectionScript;
    private WaitForSeconds pauseWait;
    
    public enum PatrolState {
        Patrolling, Chasing, Pausing
    }

    public void StartChase() {
        agentAI.speed = chaseSpeed;
        agentAI.isStopped = false;
        currentState = PatrolState.Chasing;
        chaseTarget = detectionScript.entryFocus;
    }
    public void StopChase() {
        agentAI.speed = patrolSpeed;
        currentState = PatrolState.Pausing;
        Invoke(nameof(ReturnToPatrol), patrolPause);
    }
    private void Start() {
        agentAI.destination = patrolPoints[0].position;
        pauseWait = new WaitForSeconds(patrolPause);
    }
    private void StartRoutine(IEnumerator routine) {
        if (patrolRoutine != null) {
            StopCoroutine(patrolRoutine);
        }
        patrolRoutine = StartCoroutine(routine);
    }
    public void AddPatrolPoint(Transform newPatrolPoint) {
        patrolPoints.Add(newPatrolPoint);
    }

    private void ReturnToPatrol() {//returns to closest patrol point
        if (currentState == PatrolState.Pausing) {
            currentState = PatrolState.Patrolling;
            agentAI.isStopped = false;
            List<float> distances = new List<float>();
            int closestPointIndex = 0;
            foreach (var point in patrolPoints) {
                //puts distances to patrol points in a list
                float distance = Vector2.Distance(transform.position, point.position);
                distances.Add(distance);
            }

            for (int i = 0; i < distances.Count; i++) {
                //gets index of the closest patrol point
                if (distances[i] < distances[closestPointIndex]) {
                    closestPointIndex = i;
                }
            }

            agentAI.destination = patrolPoints[closestPointIndex].position;
            currentPatrolPoint = closestPointIndex;
        }
    }
    public IEnumerator PatrolToNextPoint() {
        currentState = PatrolState.Pausing;
        agentAI.isStopped = true;
        yield return pauseWait;
        currentPatrolPoint++;
        if (currentPatrolPoint > patrolPoints.Count - 1) {
            currentPatrolPoint = 0;
        }
        agentAI.destination = patrolPoints[currentPatrolPoint].position;
        currentState = PatrolState.Patrolling;
        agentAI.isStopped = false;
    }
    
    
    private void Update() {
        switch (currentState) {
            case PatrolState.Patrolling:
                if (Mathf.Approximately(agentAI.remainingDistance, 0)) {
                    StartRoutine(PatrolToNextPoint());
                }
                break;
            case PatrolState.Chasing:
                agentAI.destination = chaseTarget.position;
                break;
            case PatrolState.Pausing:
                agentAI.isStopped = true;
                break;
        }
    }
}
