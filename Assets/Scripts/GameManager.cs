using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioClip newTrack;
    public GameObject Room;
    public GameObject Player;
    public float Playerx = 0;
    public float roomPos = 0;
    public bool leftFirstRoom = false;

    [HideInInspector]
    public bool collectedWater = false;

    [HideInInspector]
    public bool enteredDarkBedroom = false;

    public
    enum HeldItem
    {
        NONE,
        WATER,
        FIXED
    }
    public HeldItem heldItem;

    [SerializeField]
    GameObject Water;
    [SerializeField]
    GameObject Fixed;

    [HideInInspector]
    public GameObject FixedRef;

    public static GameManager instance
    { get; private set; }

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        SceneManager.activeSceneChanged += LevelWasLoaded;
        DontDestroyOnLoad(this);
    }

    private void OnDestroy()
    {
        SceneManager.activeSceneChanged -= LevelWasLoaded;
    }

    public void LevelSwapped(string DoorName)
    {
        switch (DoorName)
        {
            case "Bedroom(Hallway)":
                SceneManager.LoadScene(2);
                leftFirstRoom = true;
                break;

            case "Hallway(Bedroom)":
                if (heldItem == HeldItem.WATER)
                {
                    SceneManager.LoadScene(6);
                    heldItem = HeldItem.NONE;
                    MusicScript.instance.SwapTrack(newTrack);
                }
                else
                {
                    SceneManager.LoadScene(1);
                }    
                
                break;

            case "Hallway(Kitchen)":
                Playerx = -7.439995f;
                roomPos = 0.1009989f;
                SceneManager.LoadScene(3);
 
                break;

            case "Title(Bedroom)":
                SceneManager.LoadScene(0);
                break;

            case "Kitchen(Hallway)":
                roomPos = 9.089998f;
                Playerx = -5.359997f;
                SceneManager.LoadScene(2);
                
                break;

            case "Lounge(DarkHallway)":
                SceneManager.LoadScene(7);
                break;

            case "Lounge(Bathroom)":
                SceneManager.LoadScene(5);
                break;

            case "DarkHallway(Lounge)":
                SceneManager.LoadScene(4);
                break;

            case "DarkBedroom(DarkHallway)":
                SceneManager.LoadScene(7);
                break;

            case "DarkHallway(DarkBedroom)":
                SceneManager.LoadScene(6);
                break;

            case "End":
                SceneManager.LoadScene(8);
                break;

            case null:
                Debug.Log("Something seriously broke");
                break;
        }
    }

    void LevelWasLoaded(Scene fromscene, Scene toscene)
    {
        StartCoroutine(Wait());
        Player = GameObject.FindWithTag("Player");
        Room = GameObject.FindWithTag("Room");
        Player.transform.position = new Vector2(Playerx, -2.29f);
        Room.transform.position = new Vector2(roomPos, 0);
    }

    IEnumerator Wait()
    {
        yield return null;
        LoadHeldItem();
    }

    public void LoadHeldItem()
    {
        if (heldItem == HeldItem.WATER)
        {
            Instantiate(Water, new Vector3(-8f, 4.2f, 0.0f), Quaternion.identity);
        }
        else if (heldItem == HeldItem.FIXED)
        {
            FixedRef = Instantiate(Fixed, new Vector3(-8f, 4.2f, 0.0f), Quaternion.identity);
        }
    }
}
