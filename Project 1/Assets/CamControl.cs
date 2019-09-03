using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start() {
        print(message:"Hello World");
    }

    public int Counter; //used for timer
    public int passedTime; //used for timer
    // Update is called once per frame
    public int counterInterval; //timing interval
    public string intervalType; //name of the interval
    private void Update() {
        Counter++; //increments counter every frame
        if (Counter==counterInterval) { //60 means 60 frames or 1 second has passed
            passedTime++; //increment my timer every scond
            print(message: passedTime + " " + intervalType + "s have passed...");//show on the console how much time has passed in seconds
            Counter = 0; //reset to 0 so we can start counting the new second
        }
    }
}
