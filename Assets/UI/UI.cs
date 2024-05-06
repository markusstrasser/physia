using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    public PlayerRotation playerRotation; // Reference to the PlayerRotation component

    private void OnEnable()
    {
        // Get the root Visual Element of the UI Document
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        // Find buttons by their names
        Button A = root.Q<Button>("A");
        Button B = root.Q<Button>("B");

        // Assign click events to buttons for starting and stopping rotation
        A.clicked += () => playerRotation.StartRotate();
        B.clicked += () => playerRotation.StopRotate();
    }
}