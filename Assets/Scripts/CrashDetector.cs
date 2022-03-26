using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{

    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] float delay = 1.0f;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ground")
        {
            crashEffect.Play();
            Invoke("ReloadScene", delay);
        }
    }

    void ReloadScene() {
        SceneManager.LoadScene(0);
    }

}
