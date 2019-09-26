using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFruit : MonoBehaviour {
    public string[] fruit = {"Apple", "Orange", "Peach"};
    public bool[] ripe = {false, false, false};
    private int i = 0;

    private void Start() {
        i = 0;
        bool exitLoop = false;
        while (!ripe[i] && !exitLoop) {
            print("There isn't a ripe " + fruit[i] + "?!");
            if (i + 1 < fruit.Length) {
                i++;
                print("Go check for a ripe " + fruit[i] + ".");
            }
            else {
                print("Well just come home then...");
                exitLoop = true;
            }
        }
    }
}
