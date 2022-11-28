using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkBedroomManager : MonoBehaviour
{
    [SerializeField]
    GameObject dialgoue;

    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.instance.enteredDarkBedroom)
        {
            Destroy(dialgoue);
        }
        else
        {
            GameManager.instance.enteredDarkBedroom = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
