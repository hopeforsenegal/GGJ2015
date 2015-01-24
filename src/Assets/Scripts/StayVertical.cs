using UnityEngine;
using System.Collections;

public class StayVertical : MonoBehaviour {
	void Update( ) {
        Transform spriteTransform = this.transform.Find("SpriteAnchor");
        if (spriteTransform)
        {
            this.transform.Find("SpriteAnchor").transform.rotation = Quaternion.identity;
            this.rigidbody2D.rotation = 0;
        }
	}
}
