using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftController : MonoBehaviour
{
    Transform _transForm;
    Rigidbody _rigidBody;
    public float _moveSpeed = 15;
    public float _rotationSpeed = 10;

    public GameObject laserPrefab;
    public Transform[] shootPosArray;

    public float _shootTime = 0.5f;
    float _timer;
    float _shootCoolDownTime;
    public int _healthPoint = 10;
    bool isAlive = true;
    public GameObject _destoryEffect;
    public AudioSource _audioSource;
    public AudioClip[] _laserSound;

    void Awake()
    {
        _transForm = GetComponent<Transform>();
        _rigidBody = GetComponent<Rigidbody>();

        _audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
    }

    public void Movement(Vector3 dir)
    {
        _rigidBody.velocity = dir * _moveSpeed;
        if (dir != Vector3.zero)
        {
            Quaternion rotationValue = Quaternion.LookRotation(dir);
            _transForm.rotation = Quaternion.Slerp(_transForm.rotation, rotationValue, Time.deltaTime * _rotationSpeed);
        }
    }

    public void Movement(float dirV, float dirH)
    {
        _rigidBody.velocity = transform.forward * dirV * _moveSpeed;
        _transForm.Rotate(transform.up, dirH * Time.deltaTime * _rotationSpeed, Space.World);
    }

    public void ShootLaser()
    {
        if (_timer >= _shootCoolDownTime)
        {
            _shootCoolDownTime = _timer + _shootTime;
            CreateLaser();
        }
    }

    public void CreateLaser()
    {
        int number = Random.Range(0, _laserSound.Length);
        _audioSource.PlayOneShot(_laserSound[number]);

        for (int i = 0; i < shootPosArray.Length; i++)
        {
            Instantiate(laserPrefab, shootPosArray[i].position, shootPosArray[i].rotation);
        }
    }

    public void UnderAttack(int value)
    {
        _healthPoint -= value;
        if (gameObject.CompareTag("Player"))
        {
            GameManager._singleton.UpdateHealthPoint(_healthPoint);
        }
        if (isAlive && _healthPoint <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        isAlive = false;
        if (gameObject.CompareTag("Player"))
        {
            GameManager._singleton.GameFail();
        }
        if (gameObject.CompareTag("Enemy"))
        {
            GameManager._singleton.GetScore();
        }
        Instantiate(_destoryEffect, _transForm.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
