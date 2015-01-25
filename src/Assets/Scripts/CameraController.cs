using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour {

	// Update is called once per frame
	void Update( ) {
		if (GameManager.Instance.currentOrb != null) {
			Transform orb = GameManager.Instance.currentOrb;
			Transform furthestPlayer = null;
			foreach (PlayerController playerController in GameObject.FindObjectsOfType<PlayerController>()) {
				if (furthestPlayer == null || Vector3.Distance(orb.position, playerController.transform.position) > Vector3.Distance(orb.position, furthestPlayer.position)) {
					furthestPlayer = playerController.transform;
				}
			}
			Vector3 difference = orb.position - furthestPlayer.position;

			transform.position = (orb.position + furthestPlayer.position) / 2 - new Vector3(0, 0, 10);
			camera.orthographicSize = Mathf.Max(Mathf.Max(Mathf.Abs(difference.y) / 2 * 1.5f, Mathf.Abs(difference.x) / camera.aspect / 2 * 1.5f), 6);
		}
	}
}
