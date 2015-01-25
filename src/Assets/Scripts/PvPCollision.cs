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
}
