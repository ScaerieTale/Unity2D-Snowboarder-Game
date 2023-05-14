using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float invokeDelay = 2f;
    [SerializeField] GameObject ground;

    // Allow setting the finish line particle effect inside Unity Inspector
    [SerializeField] ParticleSystem finishEffect;
    
    // Activate When something touches the trigger
    private void OnTriggerEnter2D(Collider2D other) {
        
// Check if entity touching trigger is player.  If yes, continue, else do nothing.
if (other.tag == "Player"){

            GetComponent<AudioSource>().Play();
            finishEffect.Play();
            ground.GetComponent<SurfaceEffector2D>().enabled = false;
            // Invoke the ReloadScene() method below and give
            // it a length of time set in invokeDelay above.
            Invoke("ReloadScene", invokeDelay);
}    }
// Method to reload the current scene from the start
void ReloadScene() {
    SceneManager.LoadScene(0);
}
}
