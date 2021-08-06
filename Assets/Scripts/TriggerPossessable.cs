using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPossessable : MonoBehaviour
{
    private bool isCollided;

    // Start is called before the first frame update
    void Start()
    {
        this.isCollided = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isCollided)
        {
            Parameters possessParams = new Parameters();
            possessParams.PutObjectExtra("POSSESSED_OBJECT_KEY", gameObject.transform.parent.gameObject);

            //Posting 2 events because the event with parameters is considered different from event without
            //Despite having the same event name

            //Only observers that take params like Mover.OnPossessionEvent are activated by this PostEvent with params
            EventBroadcaster.Instance.PostEvent(EventNames.GameJam.ON_POSSESSION, possessParams);

            //Only observes that take no params like GhostBehavior.OnPossessionEvent are activated by this PostEvent
            EventBroadcaster.Instance.PostEvent(EventNames.GameJam.ON_POSSESSION);
            
            this.isCollided = false;
        }   
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ghost")
        {
            Debug.Log("Entered");
            EventBroadcaster.Instance.PostEvent(EventNames.GameJam.ON_POSSESSABLE_ENTER);
            this.isCollided = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Ghost")
        {
            Debug.Log("Exited");
            EventBroadcaster.Instance.PostEvent(EventNames.GameJam.ON_POSSESSABLE_EXIT);
            this.isCollided = false;
        }
    }
}
