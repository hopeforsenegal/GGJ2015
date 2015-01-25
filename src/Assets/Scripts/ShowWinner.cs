using UnityEngine;
using System.Collections;

public class ShowWinner : MonoBehaviour
{
    void OnGUI()
    {
        int playerOne = PlayerPrefs.GetInt("PlayerOne");
        GUI.Label(new Rect(300, 300, 200, 50), "PlayerOne" + ": " + playerOne);
        int playerTwo = PlayerPrefs.GetInt("PlayerTwo");
        GUI.Label(new Rect(300, 320, 200, 50), "PlayerTwo" + ": " + playerTwo);
    }

    void Start()
    {
    }

    void Update()
    {
    }
}
