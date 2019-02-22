using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacale : MonoBehaviour {

    private Rigidbody2D _rigid;
    public float MoveSpeed;
    [HideInInspector]public bool _moveRight; //Set this to false to move to the left and visa versa
    

    private void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
        if (_moveRight == true)
        {
            _rigid.MovePosition(_rigid.position + new Vector2(MoveSpeed, 0));
            if (_rigid.position.x > 10)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            _rigid.MovePosition(_rigid.position + new Vector2(-MoveSpeed, 0));

            if(_rigid.position.x < -10)
            {
                Destroy(gameObject);
            }
        }
    }

}
