using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//using UnityEngine.Keyboard;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Controls;

public class EnableIME : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Keyboard.current.SetIMEEnabled(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
