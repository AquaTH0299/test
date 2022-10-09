using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GetGold : MonoBehaviour
{
    [SerializeField] AudioSource getCoinsSound;
    [SerializeField] TextMeshProUGUI coinsText;
    int coins = 0;
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coins+=15;
            coinsText.text = "Coins: " + coins;
            getCoinsSound.Play();
        }
    }
}
