using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDustTrail : MonoBehaviour
{
[SerializeField] ParticleSystem dustTrail;

private void OnCollisionEnter2D(Collision2D other)
{
    if (other.gameObject.tag == "Ground")
    {
        dustTrail.Play();
    }
}

private void OnCollisionExit2D(Collision2D other)
{
    if (other.gameObject.tag == "Ground")
    {
        dustTrail.Stop();
    }
}
    
}