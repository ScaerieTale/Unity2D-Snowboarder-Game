using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables setup
    
    // set up vars to get Rigidbody2D in Start 
    //and SurfaceEffector2D in RespondToBoost()
     Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;

    // torqueAmount determines how fast player character rotates
    // when pressing a key
    [SerializeField] float torqueAmount = 10f;
    
    // Used to determine amount of speed boost to apply
    // when boost key is pressed
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float effectorBaseSpeed = 20f;
    
    // Used to determine if player has crashed, and if so
    // what linear drag amount to apply so the player
    // skids to a stop instead of continuing out of control
    private bool hasCrashed = false;
    [SerializeField] float linearDrag = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        RespondToBoost();

    }
    private void RotatePlayer()
    // if player has not crashed, allow rotation left or right
    // by pressing A, D, or Left or Right arrow keys
    {
        if (!hasCrashed)
        { 
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                rb2d.AddTorque(torqueAmount);
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                rb2d.AddTorque(-torqueAmount);
            }}
    }
    private void RespondToBoost()
    {
        if (!hasCrashed)
        {
            if (Input.GetKey(KeyCode.Space) 
            || Input.GetKey(KeyCode.W) 
            || Input.GetKey(KeyCode.UpArrow))
            {
                surfaceEffector2D.speed = boostSpeed;
            }
            else
            {
                surfaceEffector2D.speed = effectorBaseSpeed;
;
            }
        }
    }
    public void DisableControls()
    {
        hasCrashed = true;
        surfaceEffector2D.enabled = false;
        rb2d.drag = linearDrag;
    }
}