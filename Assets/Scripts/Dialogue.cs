using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [SerializeField]
    List<string> textToDisplay;

    bool firstChar = true;

    [SerializeField]
    GameObject FirstCharacter;

    [SerializeField]
    GameObject SecondCharacter;

    [SerializeField]
    GameObject textBox;

    Text text;

    // Start is called before the first frame update
    void Start()
    {
        textBox.transform.position = FirstCharacter.transform.position;

        text = textBox.GetComponentInChildren<Text>();
        text.text = textToDisplay[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            textToDisplay.RemoveAt(0);

            if(textToDisplay.Count > 0)
            {
                text.text = textToDisplay[0];
                firstChar = !firstChar;
                if(firstChar)
                {
                    textBox.transform.position = FirstCharacter.transform.position;
                }
                else
                {
                    textBox.transform.position = SecondCharacter.transform.position;
                }
            } 
            else
            {
                Destroy(textBox);
            }
        }
    }
}
