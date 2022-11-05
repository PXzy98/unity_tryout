using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] float _launchForce = 500;
    [SerializeField] float _maxDragDistance = 5;
    Vector2 _startPosition;
    Rigidbody2D _rigidbody2D;
    SpriteRenderer _spriteRenderer;

     void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {

        _startPosition = _rigidbody2D.position;
        _rigidbody2D.isKinematic = true; //set to not moving

    }

    void OnMouseDown()
    {
        _spriteRenderer.color = new Color(1, 0, 1);
        //GetComponent<SpriteRenderer>().color = Color.red;
    }

    void OnMouseUp()
    {
        var currentPosition = _rigidbody2D.position;
        Vector2 direction = _startPosition - currentPosition;
        direction.Normalize();
        _rigidbody2D.isKinematic = false;
        _rigidbody2D.AddForce(direction * _launchForce);
        _spriteRenderer.color = Color.white;
    }

    void OnMouseDrag()
    {

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 desiredPosition = mousePosition;

        

        float distance = Vector2.Distance(desiredPosition, _startPosition);

        if (distance > _maxDragDistance)
        {
            Vector2 direction = desiredPosition - _startPosition;
            direction.Normalize();
            desiredPosition = _startPosition + direction * _maxDragDistance;
        }

        if (desiredPosition.x > _startPosition.x)
            desiredPosition.x = _startPosition.x;

        _rigidbody2D.position = desiredPosition;
        
        //transform.position = new Vector3( mousePosition.x,mousePosition.y,transform.position.z);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ResetAfterDelay());
        
    }

    IEnumerator ResetAfterDelay()
    {
        _spriteRenderer.color = Color.black;
        yield return new WaitForSeconds(3);

        _rigidbody2D.position = _startPosition;
        _rigidbody2D.isKinematic = true; //set to not moving
        _rigidbody2D.velocity = Vector2.zero;
        _spriteRenderer.color = Color.white;


    }
}
