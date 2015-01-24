using UnityEngine;
using System.Collections;

public class StayVertical : MonoBehaviour {
	void Update( ) {
		this.transform.Find("SpriteAnchor").transform.rotation = Quaternion.identity;
		this.rigidbody2D.rotation = 0;
	}
}
