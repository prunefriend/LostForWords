using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class InteractableObject : MonoBehaviour
{
    private SpriteRenderer _sprite;
    private Character _player;
    private GameObject popUps;
    public UnityEvent _events;

    public bool Locked = false;
    public bool IsTouchingObject = false;
    public bool GeneratesPopUp = false;
    public string DoorName;

    // Start is called before the first frame update
    void Start()
    {
        _sprite = GetComponentInParent<SpriteRenderer>();
        _sprite.enabled = false;
        _player = FindObjectOfType<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsTouchingObject && !Locked)
        {
            CheckCurrentObject();
        }
        if (_sprite.enabled && Input.GetKeyDown(KeyCode.E))
        {
            _events.Invoke();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered");
        _sprite.enabled = true;
        IsTouchingObject = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        _sprite.enabled = false;
        IsTouchingObject = false;

        if (GeneratesPopUp == true)
        {
            popUps = GameObject.FindWithTag("popUp");
            if(popUps)
            {
                popUps.gameObject.SetActive(false);
            }
        }
        
    }

    void CheckCurrentObject()
    {
        GameManager.instance.LevelSwapped(DoorName);
    }
}
