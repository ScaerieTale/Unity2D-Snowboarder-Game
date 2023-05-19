using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAVFX : MonoBehaviour
{
    [SerializeField] ParticleSystem dustTrail;
    [SerializeField] AudioClip playerLandSFX;
    [SerializeField] AudioClip snowboardSFX;
    private AudioSource audioPlayer;
    private Rigidbody2D rb2d;

    private void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        
    }
    void OnCollisionEnter2D(Collider2D other)
    {

    }

    private void PlayFX()
    {
        dustTrail.Play();
        audioPlayer.PlayOneShot(playerLandSFX);
        audioPlayer.Play();
    }
    private void StopFX()
    {
        dustTrail.Stop();
        audioPlayer.Stop();
    }

}