using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InputScale : MonoBehaviour
{
    public InputAction encoder;
    public InputAction button;

    [Range(0, 1)]
    public float progress;
    float progressSpeed;
    public float drag = 1;
    public float collisionDrag = 5;
    public float inputMultiplier = 0.2f;
    public ParticleSystem particle_burst;
    public ParticleSystem particle_boule;
    public ParticleSystem particle_heart;

    public float timeToGoBack = 3;
    float lastInput;

    void Start()
    {
        particle_burst.Stop();
        particle_boule.Stop();
        particle_heart.Stop();
        encoder.Enable();
        button.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        float input = encoder.ReadValue<float>() * inputMultiplier;
        float inputChangeSpeed = (input - lastInput)/ Time.deltaTime;

        inputChangeSpeed = -inputChangeSpeed;
        inputChangeSpeed = Mathf.Max(0, inputChangeSpeed);

        progressSpeed += inputChangeSpeed * Time.deltaTime;
        progressSpeed -= 1f/timeToGoBack * Time.deltaTime;

        float dragMultiplier = Mathf.Exp(-Time.deltaTime * drag); //0.99f;
        progressSpeed *= dragMultiplier;
        progress += progressSpeed * Time.deltaTime;

        if (progress > 1)
            progressSpeed *= Mathf.Exp(-Time.deltaTime * collisionDrag);
        if (progress < 0)
            progressSpeed *= Mathf.Exp(-Time.deltaTime * collisionDrag);

        progress = Mathf.Clamp01(progress);


        transform.localScale = Mathf.Lerp(0.2f, 1.0f, progress) * Vector3.one;

        if (encoder.activeControl != null)
        {

            var espdevice = encoder.activeControl.device as Esp32InputDevice;
            espdevice.SendMotorSpeed(progress);

        }

        if (button.WasPressedThisFrame())
        {

            SceneManager.LoadScene("GlitCoeur");
            Debug.Log("GLIT RESTART");
        };

        if (progress >= 1)
        {
            Destroy(gameObject);
            particle_burst.Play();
            particle_boule.Play();
            particle_heart.Play();
            
        }

        lastInput = input;
    }
}
