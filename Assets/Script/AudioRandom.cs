using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRandom : MonoBehaviour
{
    public AudioClip[] _audioArray;
    AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _audioSource.clip = _audioArray[Random.Range(0, _audioArray.Length)];
        _audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
