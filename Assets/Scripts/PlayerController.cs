using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    private float speed = 5.0f;
    public bool _hasPowerup;
    private float _powerupStrength = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            _hasPowerup = true;
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && _hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>(); 
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + _hasPowerup);
            enemyRigidbody.AddForce(awayFromPlayer * _powerupStrength, ForceMode.Impulse);
        }

    }
}
