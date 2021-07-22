using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestrictStartPosition : MonoBehaviour
{
    [SerializeField] private float maxXStartRange = 40;
    [SerializeField] private float maxZStartRange = 22.5f;

    // Start is called before the first frame update
    void Start()
    {
        RestrictPosition();
    }

    private void RestrictPosition()
    {
        if (transform.position.x > maxXStartRange)
        {
            transform.position = new Vector3(maxXStartRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -maxXStartRange)
        {
            transform.position = new Vector3(-maxXStartRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z > maxZStartRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, maxZStartRange);
        }
        else if (transform.position.z < -maxZStartRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -maxZStartRange);
        }
    }
}
