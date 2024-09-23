using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private GameObject _enemy;
    public bool _isPlayerNear;
    private string _inputString;
    private string _arrowDirection;

    private void Start()
    {

    }

    private void Update()
    {
        if (_isPlayerNear)
        {
            _inputString = GetComponent<SwipeDetection>()._inputString;
        }
        else if (!_isPlayerNear)
        {
            _inputString = null;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<SwipeDetection>()._inputString = null;

        if (collision.gameObject.GetComponent<Enemy>())
        {
            _isPlayerNear = true;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            _enemy = collision.gameObject;
            _arrowDirection = _enemy.GetComponent<Enemy>()._arrowDirection;

            if (_inputString == _arrowDirection)
            {
                Destroy(collision.gameObject);
                _isPlayerNear = false;
            }
        } 
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            _isPlayerNear = false;
        }
    }

    void Movement(Vector3 direction)
    {
        this.transform.position += direction;
    }
}
