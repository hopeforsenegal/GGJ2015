using UnityEngine;
using System.Collections;

public class OrbController : MonoBehaviour {

	public int pointValue = 1;
	public Transform burstEffect;

	void OnTriggerEnter2D( Collider2D collider ) {
		if (collider.GetComponent<PlayerController>() != null) {
			GameManager.Instance.ReportScore(collider.GetComponent<PlayerController>(), this.pointValue);
			if (burstEffect != null) {
				GameObject.Instantiate(burstEffect, this.transform.position, Quaternion.identity);
			}
			GameObject.Destroy(this.gameObject);
		}
	}
}
