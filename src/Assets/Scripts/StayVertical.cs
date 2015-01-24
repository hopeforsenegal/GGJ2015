using UnityEngine;
using System.Collections;

public class StayVertical : MonoBehaviour {
	void Update( ) {
		if (this.GetComponent<PlayerController>() != null) {
			Transform spriteTransform = this.transform.Find("SpriteAnchor");
			if (spriteTransform) {
				this.transform.Find("SpriteAnchor").transform.rotation = Quaternion.identity;
				this.rigidbody2D.rotation = 0;
			}
		} else {
			this.transform.rotation = Quaternion.identity;
		}
	}
}
