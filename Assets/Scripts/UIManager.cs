using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // store sprites as an array
    // pop off the end of the array to match the lives variable in Player

// -------------------
    // Score tracking
    [SerializeField] private GameObject heart1;
    [SerializeField] private GameObject heart2;
    [SerializeField] private GameObject heart3;
    [SerializeField] private GameObject heart4;

    private GameObject[] heartsArray;

    private void Start() {
        heartsArray = new GameObject[] {heart1, heart2, heart3, heart4};
    }

    private void UpdateLives() {
        // pop off the array
        heartsArray[heartsArray.Length - 1] = 
        // heartsArray.pop();
    }
}
