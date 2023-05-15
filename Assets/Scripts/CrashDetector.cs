using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float invokeDelay = 2f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] GameObject ground;
    // set linear drag after player crashes
    [SerializeField] float linearDrag = 10;
    [SerializeField] AudioClip crashSFX;
    private bool hasCrashed = false;


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ground" && !hasCrashed) {
            hasCrashed = true;
            
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            ground.GetComponent<SurfaceEffector2D>().enabled = false;
            GetComponent<Rigidbody2D>().drag = linearDrag;
            // Invoke the ReloadScene() method below and give
            // it a length of time set in invokeDelay above.
            Invoke("ReloadScene", invokeDelay);
        }
    }
    // Method to reload the current scene from the start
void ReloadScene() {
    SceneManager.LoadScene(0);
}
}
