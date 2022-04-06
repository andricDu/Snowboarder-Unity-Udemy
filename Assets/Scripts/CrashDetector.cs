using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{

    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] float delay = 1.0f;
    [SerializeField] AudioClip crashSFX;

    bool hasCrashed = false;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ground" && !hasCrashed)
        {
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", delay);
            hasCrashed = true;
        }
    }

    void ReloadScene() {
        SceneManager.LoadScene(0);
    }

}
