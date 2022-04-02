using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Col : MonoBehaviour
{
    public int _index;

    BoxCollider _boxCollider;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _index = transform.GetSiblingIndex();
    }

    public void HitCollider(float _damage)
    {
        if (_boxCollider.size.y - _damage > 0.0f)
            _boxCollider.size = new Vector3(_boxCollider.size.x, _boxCollider.size.y - _damage, _boxCollider.size.z);
        else
            Destroy(this);
    }
}
