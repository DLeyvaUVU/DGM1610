using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFruit : MonoBehaviour {
    public string[] fruit = {"Apple", "Orange", "Peach"};
    public bool[] ripe = {false, false, false, true};
    private int i = 0;

    private void Start() {
        i = 0;
        while (!ripe[i]) {
            print("There isn't a ripe " + fruit[i] + "?!");
            i++;
            if (i < fruit.Length) {
                print("Go check for a ripe " + fruit[i] + ".");
            }
            else {
                print("Well just come home then...");
            }
        }
    }
}
