using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class CoreController : MonoBehaviour {
    public Rigidbody coreBody;
    public float moveForce, jumpForce;
    public GlobalFloat health;

    private void Awake() {
        coreBody = GetComponent<Rigidbody>();
        coreBody.constraints = RigidbodyConstraints.FreezePositionZ;
    }
    private IEnumerator OnTriggerEnter(Collider other) {
        yield return null;
        if (Mathf.Approximately(health.currentValue, 0)) {
            print("You lost, lol.");
            yield return null;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void Update() {
        coreBody.AddForce(Input.GetAxis("Horizontal")*moveForce, 0, 0);
        if (Input.GetButtonDown("Jump") && Mathf.Approximately(0, coreBody.velocity.y)) {
            coreBody.AddForce(0, jumpForce, 0);
        }
    }
}
