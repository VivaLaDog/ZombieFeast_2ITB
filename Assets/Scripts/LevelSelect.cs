using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    //on start, list of available levels
    [SerializeField]
    List<SceneAsset> listOfScenes;
    [SerializeField]
    LevelButton buttonPrefab;

    GridLayoutGroup grid;

    // Start is called before the first frame update
    void Start()
    {
        //pridat vsechny level buttony jako child pro grid layout
        grid = GetComponentInChildren<GridLayoutGroup>();


        //for every level create a button -- CREATE A LIST OF SCENES - DONE
        for(int i = 0; i < listOfScenes.Count; i++)
        {
            buttonPrefab.SetData(i+1);
            Instantiate(buttonPrefab, grid.transform); //uses grid as parent for the buttons
        }
    }
}
