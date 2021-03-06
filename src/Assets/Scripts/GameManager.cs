﻿using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Future))]
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
    public Transform currentOrb;
    public string sceneToLoad;
	private float scoreSpacing = 0.1f;
	private Dictionary<PlayerController, int> playerScores = new Dictionary<PlayerController,int>();
	private Dictionary<PlayerController, GUIText> scoreBoard = new Dictionary<PlayerController, GUIText>();
	public int winningScore = 5;

	public float minRotationInterval = 5;
	public float maxRotationInterval = 20;
	private float nextRotationTime;
    private int previousSpawnLocation = int.MaxValue;
    private GameObject[] orbSpawns;

	// Use this for initialization
    void Start()
    {
        orbSpawns = GameObject.FindGameObjectsWithTag("Orb Spawn");
		spawnOrb();
		nextRotationTime = Time.time + Random.value * (maxRotationInterval - minRotationInterval) + minRotationInterval;
	}
	
	// Update is called once per frame
	void Update () {
		foreach (PlayerController playerController in playerScores.Keys) {
			scoreBoard[playerController].text = playerController.tag + ": " + playerScores[playerController];
		}

		if (Time.time > nextRotationTime) {
			nextRotationTime = Time.time + Random.value * (maxRotationInterval - minRotationInterval) + minRotationInterval;
			if (Random.value < 0.5) {
				FindObjectOfType<LevelRotation>().RotateLeft(Random.Range(1, 3));
			} else {
				FindObjectOfType<LevelRotation>().RotateRight(Random.Range(1, 3));
			}
		}

        if (getCurrentWinner() != null || (Input.GetButton("Cancel") && !string.IsNullOrEmpty(sceneToLoad)))
        {
            foreach (PlayerController playerController in playerScores.Keys)
            {
                PlayerPrefs.SetInt(playerController.tag, playerScores[playerController]);
            }

            print("Load Scene: " + sceneToLoad);
            Application.LoadLevel(sceneToLoad); 
        }
	}

    public Dictionary<PlayerController, int> GetScores()
    {
        return playerScores;
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

    private void spawnOrb()
    {
		int currentSpawnLocation = Random.Range(0, orbSpawns.Length);

		while (currentSpawnLocation == previousSpawnLocation) {
			if (currentSpawnLocation != previousSpawnLocation)
				break;
			currentSpawnLocation = Random.Range(0, orbSpawns.Length);
		}

		currentOrb = ((GameObject)GameObject.Instantiate(orbPrefab.gameObject, orbSpawns[currentSpawnLocation].transform.position, Quaternion.identity)).transform;
		previousSpawnLocation = currentSpawnLocation;
		currentOrb.parent = grid.transform;

		Time.timeScale = 0;
		GameObject.FindObjectOfType<CameraController>().TransitionToBounds();
		GetComponent<Future>().schedule(0.5f, delegate( ) {
			Time.timeScale = 1;
		});
	}

	private PlayerController getCurrentWinner( ) {
		foreach (PlayerController playerController in playerScores.Keys) {
			if (playerScores[playerController] >= winningScore) {
				return playerController;
			}
		}
		return null;
	}
}
