using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepossessUIListener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        
        EventBroadcaster.Instance.AddObserver(EventNames.GameJam.ON_POSSESSION, this.OnPossessionEvent);
        EventBroadcaster.Instance.AddObserver(EventNames.GameJam.ON_DEPOSSESSION, this.OnDepossessionEvent);
    }

    void OnDepossessionEvent()
    {
      gameObject.SetActive(false);
    }

    void OnPossessionEvent()
    {
        gameObject.SetActive(true);
    }
}
