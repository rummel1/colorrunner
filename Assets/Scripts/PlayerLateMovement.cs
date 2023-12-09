using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayLateMovement : MonoBehaviour
{
    public Transform target; // En öndeki karakterin Transform'u
    public LineRenderer followerLineRenderer;
    public float forwardSpeed = 5f;
    public float lateralSpeed = 5f;

    void Start()
    {
        followerLineRenderer.positionCount = 0;
    }

    void FixedUpdate()
    {
        // Mevcut çizgileri temizle
        followerLineRenderer.positionCount = 0;

        // İz takip kodu buraya gelecek...
        if (target != null)
        {
            // En öndeki karakterin izini takip et
            Vector3 currentPosition = transform.position;
            followerLineRenderer.positionCount++;
            followerLineRenderer.SetPosition(followerLineRenderer.positionCount - 1, currentPosition);

            // Diğer karakterin pozisyonunu X ve Z ekseni üzerinde en öndeki karakterin izini takip ederek güncelle
            float step = forwardSpeed * Time.deltaTime; // İleri yönlü hız ayarı
            Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            // Sağa sola hareket
            float horizontalStep = lateralSpeed * Time.deltaTime; // Sağa sola hız ayarı
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * (horizontalInput * horizontalStep), Space.World);
        }
    }
}