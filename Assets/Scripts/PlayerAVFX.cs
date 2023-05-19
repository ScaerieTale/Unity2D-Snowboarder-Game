using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAVFX : MonoBehaviour
{
    // make setting up audio sources easier :)
    private AudioSource audioPlayer;

    // particle FX to play behind snowboard
    // while player is on ground
    [SerializeField] ParticleSystem dustTrail;

    // sound to play when player lands
    // Disabled until I figure out why it's breaking everything else
    // [SerializeField] AudioClip playerLandSFX;
    
    // amount of delay to apply to smooth out
    // audio stop/start on rough terrain
    [SerializeField] float invokeDelay = 0.2f;
    
    

    private void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            PlayFX();
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Invoke("StopFX", invokeDelay);
        }
    }

    // play or stop both audio snowboarding sound
    // and player dust trail VFX
    private void PlayFX()
    {
        dustTrail.Play();
       // Invoke("OneShot", 10f);
        audioPlayer.Play();
    }
    private void StopFX()
    {
        dustTrail.Stop();
        audioPlayer.Pause();
    }
        // Disabled until I can figure out what's causing it to play
        // constantly despite setting a delay on how often it can trigger
        /* private void OneShot()
        {
        audioPlayer.PlayOneShot(playerLandSFX);
        } */

}