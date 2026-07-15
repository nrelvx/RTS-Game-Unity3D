using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Rain : MonoBehaviour
{
    public Light dirLight;
    private ParticleSystem _ps;
    private bool _isRain = false;

    private void Start()
    {
        _ps = GetComponent<ParticleSystem>();
        // Intervals of rain
        StartCoroutine(Weather());
    }

    // Smooth change of light
    private void Update()
    {
        if (_isRain && dirLight.intensity > 0.25f)
            LightIntensity(-1);
        else if (!_isRain && dirLight.intensity < 0.5f) 
            LightIntensity(1);
    }

    private void LightIntensity(int mult)
    {
        // Decrease intensity of light
        dirLight.intensity += 0.1f * Time.deltaTime * mult;
    }

    IEnumerator Weather()
    {
        while (true)
        {
            // Random time
            yield return new WaitForSeconds(UnityEngine.Random.Range(30f, 90f));

            _isRain = !_isRain;
            if (_isRain)
                _ps.Play();
            else
                _ps.Stop();
        }
    }
    
    // Rain movement with camera
    public Transform cameraTransform;
    public float height = 20f;

    void LateUpdate()
    {
        transform.position = new Vector3(
            cameraTransform.position.x,
            cameraTransform.position.y + height,
            cameraTransform.position.z
        );
    }
    
}
