using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
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

    public static Inventory instance
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
                break;

            case "Hallway(Bedroom)":
                if (heldItem == HeldItem.WATER)
                {
                    SceneManager.LoadScene(6);
                    heldItem = HeldItem.NONE;
                }
                else
                {
                    SceneManager.LoadScene(1);
                }    
                
                break;

            case "Hallway(Kitchen)":
                SceneManager.LoadScene(3);
                break;

            case "Title(Bedroom)":
                SceneManager.LoadScene(0);
                break;

            case "Kitchen(Hallway)":
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

            case null:
                Debug.Log("Something seriously broke");
                break;
        }
    }

    void LevelWasLoaded(Scene fromscene, Scene toscene)
    {
        StartCoroutine(Wait());
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
    }
}
