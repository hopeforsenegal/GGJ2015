using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

	public float lifetime = 1;
	private float spawnTime;

	// Use this for initialization
	void Start () {
		spawnTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (spawnTime + lifetime > Time.time) {
			GameObject.Destroy(this.gameObject);
		}
	}
}
