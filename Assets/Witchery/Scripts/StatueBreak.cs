using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class StatueBreak : MonoBehaviour
{
    public ParticleSystem ps = null;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ps.Play();
           // Destroy(gameObject);

        }
    }
}
