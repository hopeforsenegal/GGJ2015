using UnityEngine;
using System.Collections;

public class DirectionalPlatform : MonoBehaviour {

    private bool isActive;

	// Use this for initialization
	void Start () {
        if (Mathf.Approximately(this.transform.rotation.eulerAngles.z, 90.0f) || Mathf.Approximately(this.transform.rotation.z, 270.0f))
        {
            isActive = false;
        }
        else
        {
            isActive = true;
        }

        SpriteRenderer current = GetComponent<SpriteRenderer>();
        current.color = new Color(current.color.r, current.color.g, current.color.b, isActive ? 1.0f : 0.5f);
        GetComponent<Collider2D>().enabled = isActive;
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

        isActive = !isActive;

        current.color = new Color(current.color.r, current.color.g, current.color.b, isActive ? 1.0f : 0.5f);
        GetComponent<Collider2D>().enabled = isActive;
    }
}
