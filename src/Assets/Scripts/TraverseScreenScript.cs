using UnityEngine;
using System.Collections;

public class TraverseScreenScript : MonoBehaviour {

    public string sceneToLoad;

    void OnGUI()
    {
        if (GUI.Button(new Rect(500, 450, 200, 50), "Click Here or Press Start"))
        {
            print("Load Scene: " + sceneToLoad);
            Application.LoadLevel(sceneToLoad); 
        }
    }

    void Start()
    {
        print("Current Scene: " + Application.loadedLevelName);
    }

    void Update()
    {
        if (Input.GetButton("Submit"))
        {
            print("Load Scene: " + sceneToLoad);
            Application.LoadLevel(sceneToLoad); 
        }
    }
}
