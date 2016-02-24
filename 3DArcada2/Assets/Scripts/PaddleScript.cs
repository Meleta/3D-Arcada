using UnityEngine;
using System.Collections;

public class PaddleScript : MonoBehaviour
{
    public float paddleSpeed;

    private Vector3 playerPosition;

	void Start ()
    {
         playerPosition = new Vector3(0, -9.5f, 0);
    }
	
	void Update ()
    {
        float xPosition = transform.position.x + (Input.GetAxis("Horizontal")) * paddleSpeed;
        playerPosition = new Vector3 (Mathf.Clamp(xPosition, -8f, 8f), -9.5f, 0f);
        transform.position = playerPosition;

        if (GMScript.instance.stop == true)
        {
            paddleSpeed = 0;
        }
    }
}
