using UnityEngine;
using System.Collections;

public class GridSnap : MonoBehaviour {

	public float cellSize;
	public int cellCount;

	public void SnapChildren( ) {
		foreach (Transform child in this.transform) {
			Vector3 localPosition = child.localPosition;
			localPosition /= cellSize;
			localPosition = new Vector3(Mathf.Round(localPosition.x), Mathf.Round(localPosition.y), Mathf.Round(localPosition.z));
			localPosition *= cellSize;
			child.localPosition = localPosition;
		}
	}
}
