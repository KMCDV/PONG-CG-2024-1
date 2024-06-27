using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Rigidbody2D rigid;

    public float speed = 5f;
    private float basicSpeed;
    public KeyCode UpKey = KeyCode.W;
    public KeyCode DownKey = KeyCode.S;
   

    // Start is called before the first frame update
    void Start()
    {
        basicSpeed = speed;
        sprite = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        Ball.BallReset += OnBallReset;
    }

    private void OnDestroy()
    {
        Ball.BallReset -= OnBallReset;
    }

    private void OnBallReset()
    {
        speed = basicSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(UpKey) && transform.position.y < 4.5f)
        {
            rigid.velocity = Vector2.up * speed;
        }
        else if (Input.GetKey(DownKey) && transform.position.y > -4.5f)
        {
            rigid.velocity = Vector2.down * speed;
        }
        else
        {
            rigid.velocity = Vector2.zero;
        }
    }

    private void OnMouseDown()
    {
        sprite.color = Color.red;
    }
}
