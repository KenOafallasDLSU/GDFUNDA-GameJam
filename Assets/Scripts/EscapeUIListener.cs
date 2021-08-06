using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeUIListener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        
        EventBroadcaster.Instance.AddObserver(EventNames.GameJam.ON_ESCAPE, this.OnEscapeEvent);
    }

    void OnEscapeEvent()
    {
        gameObject.SetActive(true);
    }
}
