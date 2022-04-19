using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DistanceScoreManager : MonoBehaviour
{
    public GameObject startPos;
    [SerializeField] private TextMeshProUGUI currentScore;

    private float distance;
    private float highestDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = (startPos.transform.position.y + this.transform.position.y);
        if (highestDistance < distance)
        {
            highestDistance = distance;
            currentScore.text = highestDistance.ToString("F1") + " M"; 
        }
    }
}
