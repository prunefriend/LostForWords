using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combination : MonoBehaviour
{
    [SerializeField]
    ItemWord itemWord;


    // Start is called before the first frame update
    void Start()
    {
        if (itemWord)
            itemWord.completeDelegate += Unlock;

    }

    private void OnDestroy()
    {
        if (itemWord)
            itemWord.completeDelegate -= Unlock;
    }

    void Unlock()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetMouseButtonUp(0) && GetComponent<BoxCollider2D>().isActiveAndEnabled)
        {
            Debug.Log(Input.mousePosition.y);
            // Overlapping the inventory
            if (Input.mousePosition.y < 400.0f)
            {
                GameManager.instance.heldItem = GameManager.HeldItem.COMBINATION;
                GameManager.instance.gotCombination = true;
                GameManager.instance.LoadHeldItem();
                Destroy(gameObject);
            }
        }
    }
}
