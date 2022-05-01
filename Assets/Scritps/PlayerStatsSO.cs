using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerStat", menuName = "PlayerStats")]
public class PlayerStatsSO : ScriptableObject
{
    [SerializeField] private int coins;
    [SerializeField] private float highScore;
    public event System.Action CoinChange;
    public event System.Action HighscoreChange;

    public int Coin
    {
        get => coins;
        set
        {
            coins = value;
            CoinChange?.Invoke();
        }
    }

    public float HighScore
    {
        get => highScore;
        set
        {
            highScore = value;
            HighscoreChange?.Invoke();
        }
    }
}
