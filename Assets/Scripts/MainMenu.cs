using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // vytvoøit list dostupných levelù
        // pro každý level vytvoøit button
        // na každém LevelButtonu zavolat SetData s názvem levelu
        // Pøidat LevelButton jako prefab
        // Pøidat všechny level buttony jako childy pro grid layout
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
