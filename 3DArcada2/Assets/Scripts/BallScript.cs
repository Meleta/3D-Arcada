using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour
{
    public float ballInitialVelocity;

    private Rigidbody rb;

    private bool ballIsActive;

    public AudioClip hitSound;

    void Awake ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
	    if(Input.GetButtonDown("Jump") && ballIsActive == false)
        {
            transform.parent = null;
            ballIsActive = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
        }

        if(GMScript.instance.stop == true)
        {
            rb.isKinematic = false;
            ballInitialVelocity = 0;
        }
    }
}
