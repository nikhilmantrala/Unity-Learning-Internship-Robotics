using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rbody;
    AudioSource aud;
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotateThrust = 100f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainBoosterParticles;
    [SerializeField] ParticleSystem leftBoosterParticles;
    [SerializeField] ParticleSystem rightBoosterParticles;


    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        aud = GetComponent<AudioSource>();
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
            StartThrust();
        }

        else
        {
            StopThrusting();
        }

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
            StopRotating();
        }

    }

    private void StopRotating()
    {
        rightBoosterParticles.Stop();
        leftBoosterParticles.Stop();
    }
    void StartThrust()
    {
        rbody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);

        if (!aud.isPlaying == true)
        {
            aud.PlayOneShot(mainEngine);
        }

        if (!mainBoosterParticles.isPlaying)
        {
            mainBoosterParticles.Play();
        }
    }
    void StopThrusting()
    {
        aud.Stop();
        mainBoosterParticles.Stop();
    }
    void RotateRight()
    {
        ApplyRotation(-rotateThrust);

        if (!leftBoosterParticles.isPlaying)
        {
            leftBoosterParticles.Play();
        }
    }
    void RotateLeft()
    {
        ApplyRotation(rotateThrust);

        if (!rightBoosterParticles.isPlaying)
        {
            rightBoosterParticles.Play();
        }
    }
    void ApplyRotation(float rotationThisFrame)
    {
        rbody.freezeRotation = true; //freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rbody.freezeRotation = false; //unfreezing rotation so physics syustem does stuff
    }
}
