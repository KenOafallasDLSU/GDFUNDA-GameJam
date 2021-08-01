using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //adds observers for the ON_POSSESSION and ON_DEPOSSESSION events
        //executes the 2nd param function when the events are observed
        EventBroadcaster.Instance.AddObserver(EventNames.GameJam.ON_POSSESSION, this.OnPossessionEvent);
        EventBroadcaster.Instance.AddObserver(EventNames.GameJam.ON_DEPOSSESSION, this.OnDepossessionEvent);
    }

    /*
        Called on object destruction
        Unsubscribes observers from the EventBroadcaster 
            to avoid memory leaksand bugs
    */
    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.GameJam.ON_POSSESSION);
        EventBroadcaster.Instance.RemoveObserver(EventNames.GameJam.ON_DEPOSSESSION);
    }

    private void OnPossessionEvent()
    {
        Debug.Log("Possessing");

        //gameObject refers to the object this script is attached to
        gameObject.SetActive(false);
    }

    private void OnDepossessionEvent(Parameters parameters)
    {
        Debug.Log("Depossessing");

        //gameObject refers to the object this script is attached to
        float x = parameters.GetFloatExtra("DEPOSSESS_X_COORD", gameObject.transform.position.x);
        float y = 1 + parameters.GetFloatExtra("DEPOSSESS_Y_COORD", gameObject.transform.position.y);
        float z = parameters.GetFloatExtra("DEPOSSESS_Z_COORD", gameObject.transform.position.z);

        gameObject.transform.position = new Vector3(x,y,z);
        gameObject.SetActive(true);
    }
}
