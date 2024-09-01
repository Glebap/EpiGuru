using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private float _distanceToTarget = 10f;
    [SerializeField] private float _heightAboveTarget = 5f;
    [SerializeField] private Vector3 _lookAtOffset;
    [SerializeField] private Transform _targetTransform;

    private void Start()
    {
        UpdatePosition();
    }

    private void Update()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        if (_targetTransform == null) return;

        Vector3 targetPosition = _targetTransform.position;
        targetPosition.z += _distanceToTarget;
        targetPosition.y += _heightAboveTarget;
    
        transform.position = targetPosition;

        Vector3 lookAtPosition = _targetTransform.position + _lookAtOffset;
        transform.LookAt(lookAtPosition);
    }

    private void OnValidate()
    {
        if (_targetTransform != null)
        {
            UpdatePosition();
        }
    }
}
