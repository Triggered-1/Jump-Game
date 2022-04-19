using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceScoreManager : MonoBehaviour
{
    public GameObject startPos;
    [SerializeField]private Text score;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = (startPos.transform.position.y + this.transform.position.y);
        score.text = distance.ToString("F1") + " M";
    }
}
