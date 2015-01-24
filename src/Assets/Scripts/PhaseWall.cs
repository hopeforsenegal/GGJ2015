using UnityEngine;
using System.Collections;

public class PhaseWall : MonoBehaviour{

    public bool isSlow;

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
        SpriteRenderer current = GetComponent<SpriteRenderer>();

        if (isSlow)
        {
            current.color = new Color(Color.blue.r, Color.blue.g, Color.blue.b, current.color.a);
        }
        else
        {
            current.color = new Color(Color.green.r, Color.green.g, Color.green.b, current.color.a);
        }

        isSlow = !isSlow;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.SendMessage(isSlow ? "ApplySlowMovement" : "ApplyFastMovement");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        other.gameObject.SendMessage("ApplyNormalMovement");
    }
}
