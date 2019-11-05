using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FlyingEnemyAI : NavMeshAgentController {
    public List<Vector2> patrolPoints;
    public int currentPatrolPoint;
    public float patrolPause = 0.5f;
    public bool patrolling = true, pausing = false;
    private Coroutine patrolRoutine;
    public PatrolState CurrentState = PatrolState.Patrolling;
    
    public enum PatrolState {
        Patrolling, Chasing, Pausing
    }
    public void AddPatrolPoint(Transform newPatrolPoint) {
        patrolPoints.Add(newPatrolPoint.position);
    }

    public void AddPatrolPoint(Vector2 newPatrolPoint) {
        patrolPoints.Add(newPatrolPoint);
    }

    private void ReturnToPatrol() {//returns to closest patrol point
        List<float> distances = new List<float>();
        int closestPointIndex = 0;
        foreach (var point in patrolPoints) {//puts distances to patrol points in a list
            float distance = Vector2.Distance(transform.position, point);
            distances.Add(distance);
        }
        for (int i = 0; i < distances.Count; i++) {//gets index of the closest patrol point
            if (distances[i] < distances[closestPointIndex]) {
                closestPointIndex = i;
            }
        }
        agentAI.destination = patrolPoints[closestPointIndex];
        currentPatrolPoint = closestPointIndex;
    }
    public IEnumerator PatrolToNextPoint() {
        CurrentState = PatrolState.Pausing;
        yield return new WaitForSeconds(patrolPause);
        currentPatrolPoint++;
        if (currentPatrolPoint > patrolPoints.Count) {
            currentPatrolPoint = 0;
        }
        agentAI.destination = patrolPoints[currentPatrolPoint];
        CurrentState = PatrolState.Patrolling;
        yield return null;
    }

    private void StartRoutine(IEnumerator routine) {
        if (patrolRoutine != null) {
            StopCoroutine(patrolRoutine);
        }
        patrolRoutine = StartCoroutine(routine);
    }
    private void Update() {
        switch (CurrentState) {
            case PatrolState.Patrolling:
                if (agentAI.isStopped) {
                    StartRoutine(PatrolToNextPoint());
                }
                break;
            case PatrolState.Chasing:
                break;
            case PatrolState.Pausing:
                break;
        }
    }
}
