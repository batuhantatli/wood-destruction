using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _hitDamage;
    [SerializeField] private Wood _wood;

    private Rigidbody _knifeRb;
    private Vector3 _movementVector;
    private bool _isMoving = false;
    void Start()
    {
        _knifeRb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        _isMoving = Input.GetMouseButton(0);

        if (_isMoving)
            _movementVector = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0f) * _movementSpeed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (_isMoving)
            _knifeRb.position += _movementVector;
    }

    private void OnCollisionStay(Collision collision)
    {
        Col coll = collision.collider.GetComponent<Col>();
        if (coll != null)
        {
            coll.HitCollider(_hitDamage);
            _wood.Hit(coll._index, _hitDamage);
        }

    }
}
