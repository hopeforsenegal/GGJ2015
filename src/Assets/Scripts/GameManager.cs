using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	// Singleton
	public static GameManager Instance {
		get {
			return instance;
		}
	}
	private static GameManager instance;
	void Awake( ) {
		if (instance == null) {
			instance = this;
		}
	}

	public GridSnap grid;
	public Transform orbPrefab;
	public GUIText scorePrefab;
	private float scoreSpacing = 0.1f;
	private Dictionary<PlayerController, int> playerScores = new Dictionary<PlayerController,int>();
	private Dictionary<PlayerController, GUIText> scoreBoard = new Dictionary<PlayerController, GUIText>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.RightShift)) {
			spawnOrb();
		}
		foreach (PlayerController playerController in playerScores.Keys) {
			scoreBoard[playerController].text = playerController.name + ": " + playerScores[playerController];
		}
	}

	public void ReportScore(PlayerController playerController) {
		if (playerScores.ContainsKey(playerController)) {
			playerScores[playerController] += 1;
		} else {
			playerScores.Add(playerController, 1);
			scoreBoard.Add(playerController, ((GameObject)GameObject.Instantiate(scorePrefab)).GetComponent<GUIText>());
		}

		spawnOrb();
	}
	public void ReportScore(PlayerController playerController, int points) {
		if (playerScores.ContainsKey(playerController)) {
			playerScores[playerController] += points;
		} else {
			playerScores.Add(playerController, points);
			scoreBoard.Add(playerController, ((GameObject)GameObject.Instantiate(scorePrefab.gameObject, new Vector3(0.05f, 0.95f - scoreBoard.Count * scoreSpacing, 0), Quaternion.identity)).GetComponent<GUIText>());
		}

		spawnOrb();
	}

	private void spawnOrb( ) {
		GameObject[] orbSpawns = GameObject.FindGameObjectsWithTag("Orb Spawn");
		((GameObject)GameObject.Instantiate(orbPrefab.gameObject, orbSpawns[Random.Range(0, orbSpawns.Length)].transform.position, Quaternion.identity)).transform.parent = grid.transform;
	}
}
