using UnityEngine;
using System.Collections;

public class PhaseWall : MonoBehaviour{

    public bool isSlow;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isSlow)
        {
            other.gameObject.SendMessage("ApplySlowMovement");
        }
        else
        {
            other.gameObject.SendMessage("ApplyFastMovement");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        other.gameObject.SendMessage("ApplyNormalMovement");
    }
}
