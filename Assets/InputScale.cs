using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputScale : MonoBehaviour
{
    public InputAction encoder;

    void Start()
    {
        encoder.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        print(encoder.ReadValue<float>());


    }
}
