using UnityEngine;
using System.Collections;

public class JumpPlatform : MonoBehaviour {

    public bool isSticky;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (isSticky)
        {
            coll.gameObject.SendMessage("ApplyStickyJump");
        }
        else
        {
            coll.gameObject.SendMessage("ApplySpringyJump");
        }
    }


    void OnCollisionExit2D(Collision2D coll)
    {
        coll.gameObject.SendMessage("ApplyNormalJump");
    }
}
