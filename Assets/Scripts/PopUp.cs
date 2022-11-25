using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PopUp : MonoBehaviour
{
    public int _key;
    public string _newText;
    public Text _textBox; 
    public bool Activate(int key)
    {
        if(_key == key)
        {
            _textBox.text = _newText;
            StopCoroutine(DisableCoroutine());
            return true;
        }
        return false;
    }
    public void DelayedDisable()
    {
       StartCoroutine(DisableCoroutine());
    }

    IEnumerator DisableCoroutine()
    {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
    }

    public void travel(string sceneName)
    {
        if (_textBox.text == _newText)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}
