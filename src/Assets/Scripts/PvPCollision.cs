using UnityEngine;
using System.Collections;

public class PvPCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //DEBUG
        if (Input.GetKeyDown(KeyCode.Return))
        {
            PushedBack();
        }
	}

    void PushedBack()
    {
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (this.gameObject.tag.CompareTo("PlayerOne") == 0)
        {
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        print("Exit!");
    }
}
