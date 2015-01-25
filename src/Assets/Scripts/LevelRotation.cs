using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Future))]
public class LevelRotation : MonoBehaviour {

	public float rotationDuration;
	private float leftTurn = 90;
	private float rightTurn = 90;

	private TransitionFloat rotationAngle;
	public float rot;

	// Use this for initialization
	void Awake( ) {
		this.rotationAngle = new TransitionFloat(0, rotationDuration, TransitionFloat.EASE_IN_OUT);
	}

	void Update( ) {
		rot = rotationAngle.CurrentValue;
		rotationAngle.Update();
		if (this.rotationAngle.IsTransitioning) {
			transform.rotation = Quaternion.Euler(0, 0, rotationAngle.CurrentValue);
		} else if (this.rotationAngle.Finished) {
			rotationAngle = bindRotation(rotationAngle);
		}

		//DEBUG
		if (Input.GetKeyDown(KeyCode.Return)) {
			this.RotateLeft(1);
		}
	}

	private TransitionFloat bindRotation(TransitionFloat rotation) {
		return new TransitionFloat(Mathf.RoundToInt(rotation.CurrentValue) % 360, rotationDuration, TransitionFloat.EASE_IN_OUT);
	}

	public void RotateLeft(int sides) {
		if (!this.rotationAngle.IsTransitioning) {
			Time.timeScale = 0;
			this.GetComponent<Future>().schedule(rotationDuration, delegate( ) {
                Time.timeScale = 1;
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
                UpdateListeners();
			});

            rotationAngle.GoTo(transform.rotation.eulerAngles.z + rightTurn * sides);
		}
	}

    private void UpdateListeners()
    {
        foreach (DirectionalPlatform platform in GameObject.FindObjectsOfType<DirectionalPlatform>())
        {
            platform.RotateState();
        }
    }
}
