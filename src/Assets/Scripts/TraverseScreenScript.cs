using UnityEngine;
using System.Collections;

public class TraverseScreenScript : MonoBehaviour {

    public string sceneToLoad;

    //void OnGUI()
    //{
    //    GUI.Label(new Rect(Screen.width / 2 - 5, Screen.height - 8, 300, 300), "Current Scene: " + (Application.loadedLevelName));

    //    if (GUI.Button(new Rect(Screen.width / 2 - 5, Screen.height - 5, 300, 300), "Load Scene " + sceneToLoad))
    //    {
    //        Application.LoadLevel(sceneToLoad);
    //    }
    //}

    void Start()
    {
        print("Current Scene: " + Application.loadedLevelName);
    }

    void Update()
    {
        if (Input.GetButton("Submit"))
        {
            print("Load Scene " + sceneToLoad);
            Application.LoadLevel(sceneToLoad); 
        }
    }
}
