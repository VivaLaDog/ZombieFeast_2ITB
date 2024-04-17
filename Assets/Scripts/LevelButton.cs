using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI levelName;
    [SerializeField]
    private TMPro.TextMeshProUGUI bestTime;

    int sceneName;
    // Start is called before the first frame update
    void Start()
    {
        //on every button call SetData(level name)
        //add LevelButton jako prefab -- DONE
    }

    public void SetData(int sceneIndex)
    {
        levelName.text = $"level{sceneIndex}";
        Debug.Log(levelName.text);
        bestTime.text = "Best time:\n" + (PlayerPrefs.HasKey(name) ? PlayerPrefs.GetFloat(name).ToString() : "N/A");
        
        Button btn = GetComponent<Button>();
        sceneName = sceneIndex;
        
        btn.onClick.AddListener(LoadLevel); // doesnt work with ()
    }
    //the addlistener just does not work. no fucking clue why
    public void LoadLevel()//this MF DOOM does not want to load the scene //nvm it does now!... made this public and added the AddListener manually (because i forgot to add SetData to Start)
    {
        Debug.Log($"button {levelName} clicked lol");
        SceneManager.LoadScene(levelName.text);
    }
}
