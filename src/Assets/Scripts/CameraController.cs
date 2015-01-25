using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour {

	public bool lockToBounds = true;
	private TransitionFloat sizeTransition;
	private TransitionFloat xTransition;
	private TransitionFloat yTransition;

	void Start( ) {
	}

	// Update is called once per frame
	void Update( ) {
		if (lockToBounds) {
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
		} else {
			transform.position = new Vector3(xTransition.CurrentValue, yTransition.CurrentValue, -10);
			camera.orthographicSize = sizeTransition.CurrentValue;
		}
		if (sizeTransition != null) {
			sizeTransition.Update();
			xTransition.Update();
			yTransition.Update();
		}
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

	public void TransitionToBounds() {
		lockToBounds = false;
		sizeTransition = new TransitionFloat(camera.orthographicSize, 0.5f, TransitionFloat.EASE_OUT);
		xTransition = new TransitionFloat(transform.position.x, 0.5f, TransitionFloat.EASE_OUT);
		yTransition = new TransitionFloat(transform.position.y, 0.5f, TransitionFloat.EASE_OUT);
		GetComponent<Future>().schedule(0.5f, delegate( ) {
			lockToBounds = true;
		});


		List<Vector3> points = new List<Vector3>();
		if (GameManager.Instance.currentOrb != null) {
			points.Add(GameManager.Instance.currentOrb.position);
		}
		foreach (PlayerController playerController in GameObject.FindObjectsOfType<PlayerController>()) {
			points.Add(playerController.transform.position);
		}
		Rect bounds = getMinCameraBounds(points);

		sizeTransition.GoTo(Mathf.Max(Mathf.Max(
			bounds.height / 2 * 1.5f,
			bounds.width / camera.aspect / 2 * 1.5f),
			10));
		xTransition.GoTo(bounds.center.x);
		yTransition.GoTo(bounds.center.y);
	}
}
