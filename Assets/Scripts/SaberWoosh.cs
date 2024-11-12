using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Manipulation;

public class SaberWoosh : MonoBehaviour
{
    public Rigidbody saberRigidBody;
    public AudioSource audio;

    [SerializeField] private float velocityMin;  // Minimum velocity (stationary)
    [SerializeField] private float velocityMax;  // Maximum velocity (at fastest movement)
    [SerializeField] private float volumeMin = 0f;
    [SerializeField] private float volumeMax = 0f;

    [SerializeField]
    private UxrGrabbableObject grabbableObject;
    
    private Vector3 previous;
    private float velocity;

    // Start is called before the first frame update
    void Start()
    {
        previous = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = ((transform.position - previous).magnitude) / Time.deltaTime;
        previous = transform.position;

        // Map velocity to volume range of 0-1
        float mappedVolume = Remap(velocity, velocityMin, velocityMax, volumeMin, volumeMax);
        
        audio.volume = mappedVolume;

        // Optional: Debugging volume and velocity
        Debug.Log($"Velocity: {velocity}, Volume: {mappedVolume}");
    }

    // Remap function to scale the value from one range to another
    private float Remap(float value, float fromMin, float fromMax, float toMin, float toMax)
    {
        return Mathf.Clamp01((value - fromMin) / (fromMax - fromMin) * (toMax - toMin) + toMin);
    }
}