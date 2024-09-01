using System;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    public event Action<Collider> TriggerEntered;
    
    
    private void Update()
    {
        transform.Translate(Vector3.forward * (-_speed * Time.deltaTime));
    }
    
    private void OnTriggerEnter(Collider other)
    {
        TriggerEntered?.Invoke(other);
    }
    
}
