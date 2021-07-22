using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // ENCAPSULATION
    [SerializeField] Text coinCountText;
    private int coinCount;

    private void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            UpdateCoinCountText();
        }
    }

    public void IncrementCoinCount(int increment) // ABSTRACTION
    {
        coinCount += increment;
        UpdateCoinCountText();
    }

    private void UpdateCoinCountText() // ABSTRACTION
    {
        coinCountText.text = "Coins : " + coinCount;
    }
}
