using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public List<Sprite> _walkAnim;
    public float _walkSpeed = 1.0f;
    public Transform _map;
    private SpriteRenderer _mapSprite;
    private float _rightEdge;
    private float _leftEdge;
    public SpriteRenderer _characterSprite;
    private int _spriteIntex = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        _characterSprite = GetComponentInParent<SpriteRenderer>();
        _mapSprite = _map.GetComponentInParent<SpriteRenderer>();
        _leftEdge =  _mapSprite.bounds.min.x + 1f;
        _rightEdge =  _mapSprite.bounds.max.x - 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKeyDown(KeyCode.A))
        {
            Walk(-1);
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.D))
        {
            Walk(1);
        }
        else
        {
            _spriteIntex = 0;
        }
        _characterSprite.sprite = _walkAnim[_spriteIntex/10];
        
    }

    void Walk(int direction)
    {
        //movement logic
        float newPos = transform.position.x + direction * _walkSpeed * Time.deltaTime;

        if(newPos < _leftEdge)
        {
            newPos = _leftEdge;
        }
        else if(newPos > _rightEdge)
        {
            newPos = _rightEdge;
        }

        transform.position = new Vector3(newPos, transform.position.y, 0);



        //animation logic
        _characterSprite.flipX = direction==1;
        _spriteIntex++;
        if(_spriteIntex/10 == _walkAnim.Count)
        {
            _spriteIntex = 0;
        }
    }
}
