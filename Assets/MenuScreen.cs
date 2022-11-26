using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
    [SerializeField]
    ItemWord itemWord;

    // Start is called before the first frame update
    void Start()
    {
        if (itemWord)
            itemWord.completeDelegate += StartGame;
    }

    private void OnDestroy()
    {
        if (itemWord)
            itemWord.completeDelegate -= StartGame;
    }

    void StartGame()
    {
        Invoke("LoadLevel", 3.0f);
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
