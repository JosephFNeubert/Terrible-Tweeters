using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBehavior : MonoBehaviour
{
    [SerializeField] float _launchForce = 500;
    [SerializeField] float _maxDragDistance = 3.5f;
    public Rigidbody2D _rb;
    public SpriteRenderer _sr;
    Vector2 _startPosition;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _startPosition = _rb.position;
        _rb.isKinematic = true;
        _sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnMouseDown()
    {
        _sr.color = Color.red;
    }

    void OnMouseUp()
    {
        Vector2 currentPosition = _rb.position;
        Vector2 direction = _startPosition - currentPosition;
        direction.Normalize();
        _rb.isKinematic = false;
        _rb.AddForce(direction * _launchForce);
        _sr.color = Color.white;
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 desiredPosition = mousePosition;

        float distance = Vector2.Distance(desiredPosition, _startPosition);
        if(distance > _maxDragDistance)
        {
            Vector2 direction = desiredPosition - _startPosition;
            direction.Normalize();
            desiredPosition = _startPosition + (direction * _maxDragDistance);
        }

        if (desiredPosition.x > _startPosition.x)
        {
            desiredPosition.x = _startPosition.x;
        }

        _rb.position = desiredPosition;
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        StartCoroutine(ResetAfterDelay());
    }

    IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(3);
        _rb.position = _startPosition;
        _rb.isKinematic = true;
        _rb.velocity = Vector2.zero;
    }
}
