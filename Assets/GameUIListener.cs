using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIListener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey (KeyCode.Escape)) {
            EventBroadcaster.Instance.PostEvent(EventNames.GameJam.ON_ESCAPE);
        }
    }
}
