using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class Enemy : MonoBehaviour
{

    public float speed = 6f;
    public string _arrowDirection;
    [SerializeField] GameObject _arrowImage;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _arrowImage.GetComponent<RectTransform>().localScale *= 1.3f;
    }
}
