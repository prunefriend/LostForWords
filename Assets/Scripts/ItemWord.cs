using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWord : MonoBehaviour
{
    public int _key;
    public GameObject _targetBubble;
    public GameObject _selectedObject;
    public InteractableObject door;

    Vector3 _offset;
    // Update is called once per frame

    public delegate void MultiDelegate();
    public MultiDelegate completeDelegate;

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject)
            {
                if (targetObject.gameObject.tag == "Interactable")
                {
                    _selectedObject = targetObject.transform.gameObject;
                    _offset = _selectedObject.transform.position - mousePosition;
                }
            }
        }
        if (_selectedObject)
        {
            _selectedObject.transform.position = mousePosition + _offset;
        }
        if (Input.GetMouseButtonUp(0) && _selectedObject)
        {
            _selectedObject = null;
        }
        if (_targetBubble && _targetBubble.activeInHierarchy == true && GetComponentInParent<BoxCollider2D>().OverlapPoint(_targetBubble.transform.position))
        {
            if (_targetBubble.GetComponent<PopUp>().Activate(_key))
            {
                if(completeDelegate != null)
                {
                    completeDelegate.Invoke();
                }
                if(door)
                    door.Locked = false;
                gameObject.SetActive(false);
            }
        }
    }
}
