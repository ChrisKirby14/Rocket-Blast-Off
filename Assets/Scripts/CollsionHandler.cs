using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollsionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1.5f;
    [SerializeField] float nextLevelLoad = 0.5f;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip finish;

    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem finishParticles;

    AudioSource AS;

    bool isTransitioning = false;
    bool collisionDisabled = false;

    void Start() 
    {
        AS = GetComponent<AudioSource>();
    }

    void Update() 
    {
        /*RespondToDebugKeys();
    }

    void RespondToDebugKeys()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if(Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled; // toggle collision
        }*/
    }

     void OnCollisionEnter(Collision other) 
    {
        if(isTransitioning || collisionDisabled){return;}
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("You hit a Friendly");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

      void StartSuccessSequence()
      {
          isTransitioning = true;
          AS.Stop();
          AS.PlayOneShot(finish);
          finishParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", nextLevelLoad);
      }
    


      void StartCrashSequence()
      {
          isTransitioning = true;
          AS.Stop();
          AS.PlayOneShot(crash);
          crashParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
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

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

  
        
}
