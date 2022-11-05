using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBirds : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    SpriteRenderer _spriteRenderer;
    Vector2 _startPosition;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ResetAfterDelay());

    }

    IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(3);

        _rigidbody2D.position = _startPosition;
        _rigidbody2D.velocity = Vector2.zero;
        _spriteRenderer.color = Color.white;


    }
    // Start is called before the first frame update
    void Start()
    {
        _startPosition = _rigidbody2D.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
