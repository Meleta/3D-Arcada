using UnityEngine;
using System.Collections;

public class BricksScript : MonoBehaviour
{
    public int hits;

    private int damage;

    public GameObject brickParticle;

    public int brickPoints;

    void OnCollisionEnter (Collision other)
    {
        damage++;

        if (damage == hits)
        {
            Instantiate(brickParticle, transform.position, Quaternion.identity);
            GMScript.instance.DestroyBrick(brickPoints);
            Destroy(gameObject);
        }
    }
}
