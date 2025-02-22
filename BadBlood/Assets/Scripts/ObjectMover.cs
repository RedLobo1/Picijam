using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] private GameObject _moveDirection;
    [SerializeField] private float _moveSpeed = 2f;

    List<Rigidbody2D> _rigidbodiesInside;

    private Vector2 _direction;

    void Start()
    {
        _rigidbodiesInside = new List<Rigidbody2D>();

        _direction = _moveDirection.transform.position - gameObject.transform.position;
        _direction.Normalize();
        _direction *= _moveSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        if (_rigidbodiesInside.Count > 0)
        {
            foreach (Rigidbody2D rigidbody in _rigidbodiesInside)
            {

                rigidbody.AddForce(_direction);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RedCell") || collision.CompareTag("WhiteCell") || collision.CompareTag("BlackCell"))
        {
            _rigidbodiesInside.Add(collision.GetComponent<Rigidbody2D>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("RedCell") || collision.CompareTag("WhiteCell") || collision.CompareTag("BlackCell"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null && _rigidbodiesInside.Contains(rb))
            {
                _rigidbodiesInside.Remove(rb);
            }
        }
    }
}
