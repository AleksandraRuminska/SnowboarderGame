using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private float delayFinish = 2.0f;
    [SerializeField] private ParticleSystem finishEffect;
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player"){
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", delayFinish);
        }
    }

    void ReloadScene(){
        SceneManager.LoadScene(0);
    }
}
