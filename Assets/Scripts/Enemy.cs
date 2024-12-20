using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 3.0f;
    private Rigidbody _enemyRb;
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _enemyRb = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (_player.transform.position - transform.position).normalized;
        _enemyRb.AddForce(lookDirection * speed);

        if (transform.position.y < -10) 
        { 
            Destroy(gameObject);
        }
    }
}
