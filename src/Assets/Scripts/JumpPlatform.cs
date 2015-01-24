using UnityEngine;
using System.Collections;

public class JumpPlatform : MonoBehaviour {

    public bool isSticky;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //DEBUG
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ChangeState();
        }
	}

    void ChangeState()
    {
        isSticky = !isSticky;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        coll.gameObject.SendMessage(isSticky ? "ApplyStickyJump" : "ApplySpringyJump");
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        coll.gameObject.SendMessage("ApplyNormalJump");
    }
}
