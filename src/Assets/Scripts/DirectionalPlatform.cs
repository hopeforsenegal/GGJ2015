using UnityEngine;
using System.Collections;

public class DirectionalPlatform : MonoBehaviour {

    private bool isActive;

	// Use this for initialization
	void Start () {
        RotateState();
	}
	
	// Update is called once per frame
	void Update () {

        //DEBUG
        if (Input.GetKeyDown(KeyCode.V))
        {
            ChangeState();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            RotateState();
        }
	}

    bool IsEqual(float a, float b, float precision)
    {
        return Mathf.Abs(a - b) < precision;
    }

    public void RotateState()
    {
        if (IsEqual(this.transform.rotation.eulerAngles.z, 90.0f, 5.0f) || IsEqual(this.transform.rotation.eulerAngles.z, 270.0f, 5.0f))
        {
            isActive = false;
            //print("Is NOT active: " + this.transform.rotation.eulerAngles.z);
        }
        else
        {
            isActive = true;
           // print("Is active: "+this.transform.rotation.eulerAngles.z);
        }

        SpriteRenderer current = GetComponent<SpriteRenderer>();
        current.color = new Color(current.color.r, current.color.g, current.color.b, isActive ? 1.0f : 0.5f);
        GetComponent<Collider2D>().enabled = isActive;
    }

    void ChangeState()
    {
        SpriteRenderer current = GetComponent<SpriteRenderer>();

        isActive = !isActive;

        current.color = new Color(current.color.r, current.color.g, current.color.b, isActive ? 1.0f : 0.5f);
        GetComponent<Collider2D>().enabled = isActive;
    }

    public void BelowState()
    {
        if (isActive)
        {
            GetComponent<Collider2D>().enabled = false;
        }
    }

    public void AboveState()
    {
        if (isActive && GetComponent<Collider2D>().enabled == false)
        {
            GetComponent<Collider2D>().enabled = true;
        }
    }

}
