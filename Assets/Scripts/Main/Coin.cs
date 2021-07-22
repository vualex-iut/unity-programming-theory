using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = Random.Range(120f, 720f);
        if (Random.value > 0.5)
        {
            rotationSpeed *= -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);
        }
    }
}
