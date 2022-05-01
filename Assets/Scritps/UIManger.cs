using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManger : MonoBehaviour
{
    [SerializeField] private PlayerStatsSO playerStats;
    [SerializeField] private TextMeshProUGUI highscoreTxt;
    [SerializeField] private TextMeshProUGUI coinTxt;

    // Start is called before the first frame update
    void Start()
    {
        playerStats.CoinChange += ChangeCoinUI;
        playerStats.HighscoreChange += ChangeHighscoreUI;
        ChangeHighscoreUI();
        ChangeCoinUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangeCoinUI()
    {
        coinTxt.text = playerStats.Coin.ToString();
    }

    private void ChangeHighscoreUI()
    {
        highscoreTxt.text = playerStats.HighScore.ToString("F1") + " M";
    }
}
