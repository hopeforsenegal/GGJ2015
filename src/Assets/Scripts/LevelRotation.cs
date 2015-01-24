using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Future))]
[RequireComponent(typeof(TransitionTransform))]
public class LevelRotation : MonoBehaviour {

	public float rotationDuration;
	private Quaternion leftTurn = Quaternion.FromToRotation(Vector3.right, Vector3.up);
	private Quaternion rightTurn = Quaternion.FromToRotation(Vector3.up, Vector3.right);

	// Use this for initialization
	void Start () {
		this.GetComponent<TransitionTransform>().ConfigRotation(rotationDuration, TransitionFloat.EASE_IN_OUT);
	}

	void Update( ) {
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

		Quaternion newRotation = Quaternion.Euler(this.GetComponent<TransitionTransform>().rotation);
		for (int i = 0; i < sides; i++) {
			newRotation *= leftTurn;
		}
		this.GetComponent<TransitionTransform>().rotation = newRotation.eulerAngles;
	}
	public void RotateRight(int sides) {
		Time.timeScale = 0;
		this.GetComponent<Future>().schedule(rotationDuration, delegate( ) {
			Time.timeScale = 1;
		});

		Quaternion newRotation = Quaternion.Euler(this.GetComponent<TransitionTransform>().rotation);
		for (int i = 0; i < sides; i++) {
			newRotation *= rightTurn;
		}
		this.GetComponent<TransitionTransform>().rotation = newRotation.eulerAngles;
	}
}
