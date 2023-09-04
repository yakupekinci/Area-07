using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveLight : MonoBehaviour
{
    public Light pointLight;
      public float minIntensity = 0.2f;
    public float maxIntensity = 1f;
    public float flickerSpeed = 5f;
    public float rotationSpeed = 10f;

    private float targetIntensity;

    private void Start()
    {
        // Başlangıçta hedef yoğunluğu rastgele bir değere ayarla
        targetIntensity = Random.Range(minIntensity, maxIntensity);
    }

    private void Update()
    {
        
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

       
        pointLight.intensity = Mathf.Lerp(pointLight.intensity, targetIntensity, flickerSpeed * Time.deltaTime);

      
        if (Mathf.Approximately(pointLight.intensity, targetIntensity))
        {
            targetIntensity = Random.Range(minIntensity, maxIntensity);
        }
    }
}