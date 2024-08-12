using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    AudioSource aud;
    [SerializeField] float crashDelay = 1f;
    [SerializeField] float levelDelay = 1f;
    [SerializeField] AudioClip sucess;
    [SerializeField] AudioClip crash;
    [SerializeField] ParticleSystem sucessParticles;
    [SerializeField] ParticleSystem crashParticles;


    bool isTransitioning = false;
    bool collisionDisabled = false;
    
    void Start() {
        aud = GetComponent<AudioSource>();
    }
    void Update() 
    {
        DebugKeys();
    }

    void DebugKeys()
    {
        if (Input.GetKey(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKey(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled;
        }
    }
    void OnCollisionEnter(Collision other) {

        if (isTransitioning || collisionDisabled) { return; }
        switch(other.gameObject.tag){
            case "Friendly":
                break;

            case "Finish":
                StartSucessSequence();
                break;

            default:
                Debug.Log("You died");
                StartCrashSequence();
                break;
        }
    }

    void StartSucessSequence()
    {
        isTransitioning = true;
        aud.Stop();
        aud.PlayOneShot(sucess);
        sucessParticles.Play();

        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelDelay);
    }

    void StartCrashSequence() 
    {
        isTransitioning = true;
        aud.Stop();
        aud.PlayOneShot(crash);
        crashParticles.Play();

        GetComponent<Movement>().enabled = false;
        Invoke("ReloadScene", crashDelay);
    }
    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void ReloadScene(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}
