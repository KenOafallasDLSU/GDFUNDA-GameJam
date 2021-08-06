using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    public GameObject p;
    public GameObject messageS;
    public GameObject messageG;
    public GameObject btn_start;
    public GameObject btn_quit;
    public GameObject btn_next;
    public GameObject btn_play;

    public void ShowStory() {
        if(p != null) {
            btn_start.SetActive(false);
            btn_quit.SetActive(false);
            messageS.SetActive(true);
            btn_next.SetActive(true);
        }
    }

    public void ShowGoal() {
        if(p != null) {
            messageS.SetActive(false);
            btn_next.SetActive(false);
            messageG.SetActive(true);
            btn_play.SetActive(true);
        }
    }

}
