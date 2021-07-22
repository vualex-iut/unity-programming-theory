using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    protected Rigidbody rb;
    protected string _name;
    public string Name
    {
        get { return _name; }
        set
        {
            if (!string.IsNullOrEmpty(_name))
            {
                _name = value;
            }
            else
            {
                Debug.LogError("Invalid name given to Enemy");
            }
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        rb.AddForce(
            Random.Range(-1f, 1f) * speed,
            0,
            Random.Range(-1f, 1f) * speed
        );
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Die();
        }
    }

    public virtual void Die()
    {
        DisplayDeathMessage();
        Destroy(gameObject);
    }

    public virtual void DisplayDeathMessage()
    {
        Debug.Log($"Enemy {_name} died.");
    }
}
