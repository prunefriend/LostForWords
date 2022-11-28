using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedRoomManager : MonoBehaviour
{
    [SerializeField]
    InteractableObject door;
    [SerializeField]
    InteractableObject toyBox;

    [SerializeField]
    GameObject Dialogue;

    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.instance.leftFirstRoom == true)
        {
            door.Locked = false;
            Destroy(toyBox.gameObject);
            Destroy(Dialogue);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
