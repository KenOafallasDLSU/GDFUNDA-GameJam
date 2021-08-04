using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private GameObject defaultPlayer;
    [SerializeField] private CinemachineVirtualCamera myCinemachine;
    private GameObject stalkedObject;

    // Start is called before the first frame update
    void Start()
    {
        this.stalkedObject = this.defaultPlayer;

        //adds observers for the ON_POSSESSION and ON_DEPOSSESSION events
        //executes the 2nd param function when the events are observed
        EventBroadcaster.Instance.AddObserver(EventNames.GameJam.ON_POSSESSION, this.OnPossessionEvent);
        EventBroadcaster.Instance.AddObserver(EventNames.GameJam.ON_DEPOSSESSION, this.OnDepossessionEvent);
    }

    // // Update is called once per frame
    // void Update()
    // {
    //     //moves to follow the current player-controlled GameObject
    //     Vector3 newPosition = new Vector3(stalkedObject.transform.position.x, stalkedObject.transform.position.y+2, stalkedObject.transform.position.z-3);
    //     transform.position = newPosition;
    // }

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

    void OnPossessionEvent(Parameters parameters)
    {
        this.stalkedObject = parameters.GetObjectExtra("POSSESSED_OBJECT_KEY") as GameObject;
        myCinemachine.m_Follow = this.stalkedObject.gameObject.transform;
        myCinemachine.m_LookAt = this.stalkedObject.gameObject.transform;
    }

    void OnDepossessionEvent()
    {
        this.stalkedObject = this.defaultPlayer;
        myCinemachine.m_Follow = this.stalkedObject.gameObject.transform;
        myCinemachine.m_LookAt = this.stalkedObject.gameObject.transform;
    }
}
