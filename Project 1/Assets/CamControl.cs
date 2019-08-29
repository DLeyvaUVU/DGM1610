using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        print(message:"Hello World");
        
    }

    private int Counter;
    private int passedTime;

    // Update is called once per frame
    void Update() {
        Counter++;
        if (Counter==60) {
            passedTime++;
            print(message: passedTime + " seconds have passed...");
            Counter = 0;
        }
    }
}
