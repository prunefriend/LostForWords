using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class popUpWindow : MonoBehaviour
{

    private GameObject winSolved;

    public UnityEvent _events;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.SetActive(false);
            _events.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
