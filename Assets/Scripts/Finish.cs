using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] AudioClip success;
    AudioSource audioSource;
    private void Start() 
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.name == "Player")
        {
            audioSource.Stop();
            audioSource.PlayOneShot(success);
            Invoke("LoadLevel",.75f);
        }
    }
    void LoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
