using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour {

	// Update is called once per frame
	void Update( ) {
		List<Vector3> points = new List<Vector3>();
		if (GameManager.Instance.currentOrb != null) {
			points.Add(GameManager.Instance.currentOrb.position);
		}
		foreach (PlayerController playerController in GameObject.FindObjectsOfType<PlayerController>()) {
			points.Add(playerController.transform.position);
		}
		Rect bounds = getMinCameraBounds(points);
		transform.position = (Vector3)bounds.center - new Vector3(0, 0, 10);
		camera.orthographicSize = Mathf.Max(Mathf.Max(
			bounds.height / 2 * 1.5f, 
			bounds.width / camera.aspect / 2 * 1.5f), 
			10);
	}

	private Rect getMinCameraBounds(List<Vector3> points) {
		Vector3 min = points[0];
		Vector3 max = points[0];

		foreach (Vector3 point in points) {
			min.x = Mathf.Min(min.x, point.x);
			min.y = Mathf.Min(min.y, point.y);
			max.x = Mathf.Max(max.x, point.x);
			max.y = Mathf.Max(max.y, point.y);
		}

		return new Rect(min.x, min.y, Mathf.Abs(min.x - max.x), Mathf.Abs(min.y - max.y));
	}
}
