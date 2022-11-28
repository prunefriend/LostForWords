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
        _leftEdge =  _mapSprite.bounds.max.x-9+0.1119995f;
        _rightEdge =  _mapSprite.bounds.min.x+9-0.1119995f;
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
        if(_map.position.x == _leftEdge || _map.position.x ==_rightEdge )
        {
            //move player
            if(_map.position.x == _leftEdge)
            {
                transform.position += new Vector3(direction*_walkSpeed*Time.deltaTime,0,0);
                if(transform.position.x < -8)
                {
                    transform.position = new Vector3(-8, transform.position.y,0);
                }
                else if(transform.position.x > 0)
                {
                    float movement = transform.position.x;
                    transform.position = new Vector3(0,transform.position.y,0);
                    _map.position += new Vector3(-movement,0,0);
                }
            }
            if(_map.position.x == _rightEdge)
            {
                transform.position += new Vector3(direction*_walkSpeed*Time.deltaTime,0,0);
                if(transform.position.x > 8)
                {
                    transform.position = new Vector3(8, transform.position.y,0);
                }
                else if(transform.position.x < 0)
                {
                    float movement = transform.position.x;
                    transform.position = new Vector3(0,transform.position.y,0);
                    _map.position += new Vector3(-movement,0,0);
                }
            }
        }
        else
        {
            //move map
            if(_leftEdge >=_map.position.x && _rightEdge <= _map.position.x)
            {
                _map.position+= new Vector3(-direction*_walkSpeed*Time.deltaTime,0,0);
            }
            if(_leftEdge <_map.position.x )
            {
                _map.position = new Vector3(_leftEdge,0,0);
            }
            if(_rightEdge >_map.position.x )
            {
                _map.position = new Vector3(_rightEdge,0,0);
            }
        }

        //animation logic
        _characterSprite.flipX = direction==1;
        _spriteIntex++;
        if(_spriteIntex/10 == _walkAnim.Count)
        {
            _spriteIntex = 0;
        }
    }
}
