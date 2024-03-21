using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    private Vector3 currentPoint;
    private Vector3 targetPoint;
    private float elapsedTime;
    private float timeToTargetPoint;
    [SerializeField] private float speed = 1f;

    private void Start()
    {
        TargetPoint();
    }
    void Update()
    {
            elapsedTime += Time.deltaTime;
            float elapsedPercentage = elapsedTime / timeToTargetPoint;
            transform.position = Vector3.Lerp(currentPoint, targetPoint, elapsedPercentage);

            if (elapsedPercentage >= 1)
            {
                Destroy(gameObject);
            }
    }
    private void TargetPoint()
    {
        currentPoint = transform.position + Vector3.up;
        targetPoint = currentPoint + Vector3.up;
        elapsedTime = 0f;

        float distanceToPoint = Vector3.Distance(currentPoint, targetPoint);
        timeToTargetPoint = distanceToPoint / speed;
    }
}
