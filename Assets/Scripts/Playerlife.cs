using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playerlife : MonoBehaviour
{
    [SerializeField] AudioSource deadthSound;
    bool isDead = false;
    private void Update() 
    {
        if ( transform.position.y <= -1.8f && !isDead )
        {
            Die();
        }
    }
    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Playermovement>().enabled = false;
            Die();
        }
    }
    private void Die()
    {
        isDead = true;
        Invoke("ReLoadLevel",.75f);
        deadthSound.Play();
    }
    void ReLoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
