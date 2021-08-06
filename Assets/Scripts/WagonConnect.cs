using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonConnect : MonoBehaviour
{
    [SerializeField] private GameObject wagon;
    [SerializeField] private GameObject car;
    [SerializeField] private GameObject fusion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wagon")
        {
            wagon.SetActive(false);
            car.SetActive(false);
            fusion.SetActive(true);

            Parameters possessParams = new Parameters();
            possessParams.PutObjectExtra("POSSESSED_OBJECT_KEY", fusion);

            //Posting 2 events because the event with parameters is considered different from event without
            //Despite having the same event name

            //Only observers that take params like Mover.OnPossessionEvent are activated by this PostEvent with params
            EventBroadcaster.Instance.PostEvent(EventNames.GameJam.ON_POSSESSION, possessParams);

            //Only observes that take no params like GhostBehavior.OnPossessionEvent are activated by this PostEvent
            EventBroadcaster.Instance.PostEvent(EventNames.GameJam.ON_POSSESSION);
        }
    }
}