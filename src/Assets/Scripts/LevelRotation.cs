using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Future))]
public class LevelRotation : MonoBehaviour {

	public float rotationDuration;
	private float leftTurn = 90;
	private float rightTurn = 90;

	private TransitionFloat rotationAngle;

	// Use this for initialization
	void Awake( ) {
		this.rotationAngle = new TransitionFloat(0, rotationDuration, TransitionFloat.EASE_IN_OUT);
	}

	void Update( ) {
		rotationAngle.Update();
		if (this.rotationAngle.IsTransitioning) {
			transform.rotation = Quaternion.Euler(0, 0, rotationAngle.CurrentValue);
		}

		//DEBUG
		if (Input.GetKeyDown(KeyCode.Return)) {
			this.RotateLeft(1);
		}
	}

	public void RotateLeft(int sides) {
		Time.timeScale = 0;
		this.GetComponent<Future>().schedule(rotationDuration, delegate( ) {
			Time.timeScale = 1;
		});

		rotationAngle.GoTo(transform.rotation.eulerAngles.z + leftTurn * sides);
	}
	public void RotateRight(int sides) {
		Time.timeScale = 0;
		this.GetComponent<Future>().schedule(rotationDuration, delegate( ) {
			Time.timeScale = 1;
		});

		rotationAngle.GoTo(transform.rotation.eulerAngles.z + leftTurn * sides);
	}
}
