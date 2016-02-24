using UnityEngine;
using System.Collections;

public class DeathZoneScript : MonoBehaviour
{
    void OnTriggerEnter (Collider coll)
    {
        GMScript.instance.LoseLives();
    }
}
