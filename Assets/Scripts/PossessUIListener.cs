using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessUIListener : MonoBehaviour
{
    private int possessableCount; 
    // Start is called before the first frame update
    void Start()
    {
        this.possessableCount = 0;

        gameObject.SetActive(false);

        EventBroadcaster.Instance.AddObserver(EventNames.GameJam.ON_POSSESSION, this.ForceHideUI);
        EventBroadcaster.Instance.AddObserver(EventNames.GameJam.ON_POSSESSABLE_ENTER, this.IncPossessableCount);
        EventBroadcaster.Instance.AddObserver(EventNames.GameJam.ON_POSSESSABLE_EXIT, this.DecPossessableCount);
    }

    // Update is called once per frame
    void ForceHideUI()
    {
      this.possessableCount = 0;
      gameObject.SetActive(false);
    }

    void IncPossessableCount()
    {
      this.possessableCount += 1;
      if(possessableCount > 0)
        gameObject.SetActive(true);
    }

    void DecPossessableCount()
    {
      this.possessableCount -= 1;
      if(possessableCount <= 0)
        gameObject.SetActive(false);
    }
}