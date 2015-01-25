using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Future))]
public class LevelRotation : MonoBehaviour {

	public float rotationDuration;
	private float leftTurn = 90;
	private float rightTurn = 90;

	private TransitionFloat rotationAngle;
	public float currentAngle;
	public float targetAngle;

	// Use this for initialization
	void Awake( ) {
		this.rotationAngle = new TransitionFloat(0, rotationDuration, TransitionFloat.EASE_IN_OUT);
	}

	void Update( ) {
		currentAngle = rotationAngle.CurrentValue;
		targetAngle = rotationAngle.DestinationValue;
		rotationAngle.Update();
		if (this.rotationAngle.IsTransitioning) {
			transform.rotation = Quaternion.Euler(0, 0, rotationAngle.CurrentValue);
		}
	}

	public void RotateLeft(int sides) {
		if (!this.rotationAngle.IsTransitioning) {
			Time.timeScale = 0;
			this.GetComponent<Future>().schedule(rotationDuration, delegate( ) {
				Time.timeScale = 1;
				bindRotation(rotationAngle);
                UpdateListeners();
			});

			rotationAngle.GoTo(transform.rotation.eulerAngles.z + leftTurn * sides);
		}
	}
	public void RotateRight(int sides) {
		if (!this.rotationAngle.IsTransitioning) {
			Time.timeScale = 0;
			this.GetComponent<Future>().schedule(rotationDuration, delegate( ) {
				Time.timeScale = 1;
				bindRotation(rotationAngle);
                UpdateListeners();
			});

            rotationAngle.GoTo(transform.rotation.eulerAngles.z + rightTurn * sides);
		}
	}

	private void bindRotation(TransitionFloat rotation) {
		transform.rotation = Quaternion.Euler(0, 0, Mathf.RoundToInt(rotation.CurrentValue) % 360);
		rotationAngle = new TransitionFloat(Mathf.RoundToInt(rotation.CurrentValue) % 360, rotationDuration, TransitionFloat.EASE_IN_OUT);
	}

    private void UpdateListeners()
    {
        foreach (DirectionalPlatform platform in GameObject.FindObjectsOfType<DirectionalPlatform>())
        {
            platform.RotateState();
        }
    }
}
