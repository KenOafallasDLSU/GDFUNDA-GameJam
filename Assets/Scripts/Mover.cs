using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private GameObject defaultPlayer;
    [SerializeField] private float playerSpeed = 2.0f;
    private GameObject activePlayer;
    private bool isPossessing;

    public const string POSSESSED_MOVER_KEY = "POSSESSED_MOVER_KEY";
    
    // Start is called before the first frame update
    void Start()
    {
        this.isPossessing = false;
        this.activePlayer = this.defaultPlayer;

        //adds observers for the ON_POSSESSION and ON_DEPOSSESSION events
        //executes the 2nd param function when the events are observed
        EventBroadcaster.Instance.AddObserver(EventNames.GameJam.ON_POSSESSION, this.OnPossessionEvent);
        EventBroadcaster.Instance.AddObserver(EventNames.GameJam.ON_DEPOSSESSION, this.OnDepossessionEvent);
    }

    // Update is called once per frame
    void Update()
    {
        //Movement Behavior
        if (Input.GetKey (KeyCode.A)) {
            this.activePlayer.gameObject.transform.Translate (Vector3.left * playerSpeed * Time.deltaTime); 
        }
        if(Input.GetKey (KeyCode.D)) {
            this.activePlayer.gameObject.transform.Translate (Vector3.right *   playerSpeed * Time.deltaTime);
        }
        if(Input.GetKey (KeyCode.W)) {
            this.activePlayer.gameObject.transform.Translate (Vector3.forward *   playerSpeed * Time.deltaTime);
        }
        if(Input.GetKey (KeyCode.S)) {
            this.activePlayer.gameObject.transform.Translate (Vector3.back *   playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Space)){
            this.activePlayer.gameObject.transform.Translate(Vector3.up * Time.deltaTime * playerSpeed);
        }
        if (Input.GetKey(KeyCode.LeftControl)){
            this.activePlayer.gameObject.transform.Translate(Vector3.down * Time.deltaTime * playerSpeed);
        }

        //Depossession Behavior
        if (Input.GetKeyDown(KeyCode.Q) && isPossessing)
            this.postDepossessEvent();
    }

    /*
        Posts event with the location of active player object as params
        so that the ghost can reappear on that location after depossessing
    */
    private void postDepossessEvent()
    {
        Parameters depossessParams = new Parameters();
        depossessParams.PutExtra("DEPOSSESS_X_COORD", this.activePlayer.transform.position.x);
        depossessParams.PutExtra("DEPOSSESS_Y_COORD", this.activePlayer.transform.position.y);
        depossessParams.PutExtra("DEPOSSESS_Z_COORD", this.activePlayer.transform.position.z);

        EventBroadcaster.Instance.PostEvent(EventNames.GameJam.ON_DEPOSSESSION, depossessParams);
        EventBroadcaster.Instance.PostEvent(EventNames.GameJam.ON_DEPOSSESSION);
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

    private void OnDepossessionEvent()
    {
        this.isPossessing = false;
        this.activePlayer = this.defaultPlayer;
    }

    private void OnPossessionEvent(Parameters parameters)
    {
        this.isPossessing = true;
        activePlayer = parameters.GetObjectExtra("POSSESSED_OBJECT_KEY") as GameObject;
    }
}
