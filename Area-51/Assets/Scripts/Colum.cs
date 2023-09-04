using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colum : MonoBehaviour
{
    public Transform checher;
    public LayerMask playerLayer;
    public float moveSpeed = .0f; // Hareket hızı
    public float maxY = 0.0f; // Yukarı sınır
    public float minY = -30.0f; // Aşağı sınır

    private bool movingUp = true;
    private bool broke = false;
    void Awake()
    {
        maxY = transform.localPosition.y;

    }

    private void Update()
    {
        if (Physics.CheckBox(checher.position, new Vector3(4, 1, 4), Quaternion.identity, playerLayer))
        {
            broke = true;
        }
        if (broke)
        {
            int direction = movingUp ? 1 : -1;

            // Yeni yüksekliği hesapla
            float newY = Mathf.Clamp(transform.position.y + direction * moveSpeed * Time.deltaTime, minY, maxY);

            // Pozisyonu güncelle
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            // Hareket yönünü değiştir
            if ((movingUp && newY >= maxY) || (!movingUp && newY <= minY))
            {
                movingUp = !movingUp;
            }
        }
    }
}