/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using System;
using UnityEditor.SceneManagement;

public class UnpackPocky : EditorWindow {

    
    public GameObject Enemy;
    public GameObject Enter;
    //public GameObject RefreshPoint;
    public GameObject MapStore;

    [MenuItem("Tool/UnpackPocky")]
    static void Start() {
        UnpackPocky myWindow = (UnpackPocky)EditorWindow.GetWindow(typeof(UnpackPocky), false, "UnpackPocky", true);
        myWindow.Show();
    }

    // Update is called once per frame
    void OnGUI() {
        MapStore = (GameObject)EditorGUI.ObjectField(new Rect(50, 20, 200, 20), MapStore, typeof(GameObject),false);
        Enter = (GameObject)EditorGUI.ObjectField(new Rect(50, 40, 200, 20), Enter, typeof(GameObject),false);
        Enemy = (GameObject)EditorGUI.ObjectField(new Rect(50, 60, 200, 20), Enemy, typeof(GameObject),false);
        //RefreshPoint = (GameObject)EditorGUI.ObjectField(new Rect(50, 80, 200, 20), RefreshPoint, typeof(GameObject),false);
        
        
        Enemy = GameObject.Find("Enemy");
        Enter = GameObject.Find("Enter");
        //RefreshPoint = GameObject.Find("RefreshPoint");
        MapStore = Enemy.transform.parent.gameObject;

        if (GUI.Button(new Rect(50, 100, 100, 30), "断绝关系")) {


            if (Enemy==null || Enter==null || MapStore==null) {
                Debug.LogError("没找到鸭");
            }

            GameObject[] EnemyList = new GameObject[Enemy.transform.childCount];
            GameObject[] EnterList = new GameObject[Enter.transform.childCount];

            GameObject[] list = new GameObject[3+Enter.transform.childCount+Enemy.transform.childCount];
            list[0] = MapStore;
            list[1] = Enemy;
            list[2] = Enter;
            //list[3] = RefreshPoint;

            for (int i = 0; i < Enter.transform.childCount; i++) {
                EnterList[i]=Enter.transform.GetChild(i).gameObject;
                list[i+3] = EnterList[i];
            }
           
            for (int i = 0; i < Enemy.transform.childCount; i++) {
                EnemyList[i]=Enemy.transform.GetChild(i).gameObject;
                list[i+3+Enter.transform.childCount] = EnemyList[i];
            }

            for (int i = 0; i < list.Length; i++) {

                if(PrefabUtility.IsPartOfPrefabInstance(list[i])){
                    Debug.Log("Unpack!");
                    PrefabUtility.UnpackPrefabInstance(list[i], PrefabUnpackMode.Completely, InteractionMode.UserAction);
                } 
                else{//Debug.Log("No Problem");
                }
            }
			
        }
                EditorSceneManager.SaveOpenScenes();
    }
}
 */