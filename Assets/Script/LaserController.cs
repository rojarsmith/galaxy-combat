using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public float _moveSpeed = 5f;
    public float _lifeTime = 1.5f;

    public bool _isPlayerLaser;

    public GameObject _breakParticle;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * _moveSpeed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            DestroyLaser();
        }
        if (_isPlayerLaser && other.CompareTag("Enemy"))
        {
            other.GetComponent<CraftController>().UnderAttack(1);
            DestroyLaser();
        }
        if (!_isPlayerLaser && other.CompareTag("Player"))
        {
            other.GetComponent<CraftController>().UnderAttack(1);
            DestroyLaser();
        }
    }

    void DestroyLaser()
    {
        Instantiate(_breakParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
