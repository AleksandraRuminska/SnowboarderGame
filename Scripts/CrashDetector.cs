using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] private float delayCrash = 0.5f;
    [SerializeField] private ParticleSystem crashEffect;
    [SerializeField] private AudioClip crashSFX;
    bool hasCrashed = false;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ground" && !hasCrashed){
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControl();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", delayCrash);
        }
    }

    void ReloadScene(){
        SceneManager.LoadScene(0);
    }
}
