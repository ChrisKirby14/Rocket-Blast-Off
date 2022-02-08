
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    
    [SerializeField] float mainThrust = 1f;
    [SerializeField] float rotationLeftThrust = 200f;
    [SerializeField] float rotationRightThrust = -200f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainBooster;
    [SerializeField] ParticleSystem leftBooster;
    [SerializeField] ParticleSystem rightBooster;
    Rigidbody rb;
    AudioSource AS;
    ParticleSystem PS;
    


    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>();
       AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }


    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }

    }

    private void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!AS.isPlaying)
        {
            AS.PlayOneShot(mainEngine);
        }
        if (!mainBooster.isPlaying)
        {
            mainBooster.Play();
        }
    }

    private void StopThrusting()
    {
        AS.Stop();
        mainBooster.Stop();
    }

    void ProcessRotation()
    {
         if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }

        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotation();
        }

    }
    private void RotateLeft()
    {
        ApplyRotation(rotationLeftThrust);
        if (!AS.isPlaying)
        {
            AS.PlayOneShot(mainEngine);
        }
        if (!rightBooster.isPlaying)
        {
            rightBooster.Play();
        }
    }

    private void RotateRight()
    {
        ApplyRotation(rotationRightThrust);
        if (!AS.isPlaying)
        {
            AS.PlayOneShot(mainEngine);
        }
        if (!leftBooster.isPlaying)
        {
            leftBooster.Play();
        }
    }

    private void StopRotation()
    {
        rightBooster.Stop();
        leftBooster.Stop();
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation so the physics ststem can take over
    }
}
