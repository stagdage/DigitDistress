﻿using UnityEngine;
using UnityEditor;
using System.Collections;

public class GameControllerEditor : EditorWindow
{



    GameObject gameControllerObject;
    GameController gameController;
    Camera mainCamera;



    public bool isPerpetual = false;

    // Use this for initialization
    void OnEnable()
    {
        gameControllerObject = Resources.Load<GameObject>("GameController");
    }

    void Update()
    {
        gameController = gameControllerObject.GetComponent<GameController>();
        mainCamera = Camera.main;
    }

    [MenuItem("Game Controller Package/Editor")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(GameControllerEditor), true);
    }

    void OnGUI()
    {
        GUILayout.Label("Controller Settings", EditorStyles.boldLabel);

        if (GUILayout.Button("Add GameController"))
        {
            if (!GameObject.FindGameObjectWithTag("GameController"))
            {
                Instantiate(gameControllerObject, Vector3.zero, Quaternion.identity);
                GameObject objectToRename = GameObject.FindGameObjectWithTag("GameController");
                objectToRename.gameObject.name = "GameController";
                if(mainCamera.GetComponent<AudioListener>())
                {
                    DestroyImmediate(mainCamera.GetComponent<AudioListener>());
                }else
                {
                    Debug.Log("No audio listener on main camera");
                }
            }
            else if (GameObject.FindGameObjectWithTag("GameController"))
            {
                AlredyInUsePopup.ShowWindow();
                Debug.LogError("You already have a \"GameController\"");
            }
            else
            {
                Debug.LogError("Something went wrong with tag \"GameController\"");
            }
        }

        isPerpetual = GUILayout.Toggle(isPerpetual, "Perpetual GameController?");
        if (GUILayout.Button("Update GameController"))
        {
            if (isPerpetual)
            {
                gameController.setPerpetual(isPerpetual);
            }
        }
    }
}

public class AlredyInUsePopup : EditorWindow
{
    public static void ShowWindow()
    {
        var window = new AlredyInUsePopup();
        window.position = new Rect(Screen.width/2,Screen.height/2,250,75);
        window.ShowPopup();
        //EditorWindow.GetWindow(typeof(AlredyInUsePopup), true);
    }

    void OnGUI()
    {
        GUILayout.Label("There is already a \n\"GameController\" \nin the scene!");
        if (GUILayout.Button("Ok"))
        {
            Close();
        }
    }
}