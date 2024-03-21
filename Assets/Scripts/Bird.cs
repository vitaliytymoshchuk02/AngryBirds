using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] float offset;
    private Slingshot slingshot;
    private bool inSlingshot;
    private void Awake()
    {
        slingshot = FindObjectOfType<Slingshot>();
        inSlingshot = true;
    }
    private void Update()
    {
        if (inSlingshot)
        {
            Vector3 direction = slingshot.GetCurrentPosition() - slingshot.GetCenterPosition();
            transform.position = slingshot.GetCurrentPosition() + direction.normalized * offset;
        }
    }

    public void SetInSlingshot(bool inSlingshot) => this.inSlingshot = inSlingshot;
}
