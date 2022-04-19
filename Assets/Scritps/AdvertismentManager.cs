using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdvertismentManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize("4716457");
    }

    IEnumerator WaitforInitialising()
    {
        yield return new WaitUntil(() => Advertisement.isInitialized);
        Advertisement.Load("");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
