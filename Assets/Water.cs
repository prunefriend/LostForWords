using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Water : MonoBehaviour
{
    [SerializeField]
    ItemWord itemWord;

    [SerializeField]
    Sprite inActiveSprite;
    [SerializeField]
    Sprite activeSprite;

    // Start is called before the first frame update
    void Start()
    {
        if(itemWord)
            itemWord.completeDelegate += Unlock;

        if(GetComponent<BoxCollider2D>().isActiveAndEnabled)
        {
            GetComponentInChildren<Image>().sprite = activeSprite;
        }
        else
        {
            if(GameManager.instance.collectedWater == true)
            {
                Destroy(gameObject);
            }
            GetComponentInChildren<Image>().sprite = inActiveSprite;

        }
    }

    private void OnDestroy()
    {
        if (itemWord)
            itemWord.completeDelegate -= Unlock;
    }

    void Unlock()
    {
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponentInChildren<Image>().sprite = activeSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<ItemWord>()._selectedObject != null && Input.GetMouseButtonUp(0) && GetComponent<BoxCollider2D>().isActiveAndEnabled)
        {
            // Overlapping the inventory
            if (Input.mousePosition.y < 400.0f)
            {
                GameManager.instance.heldItem = GameManager.HeldItem.WATER;
                GameManager.instance.collectedWater = true;
                GameManager.instance.LoadHeldItem();
                Destroy(gameObject);
            }
        }
    }
}
