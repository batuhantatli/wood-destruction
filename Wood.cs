using UnityEngine;
using DG.Tweening;

public class Wood : MonoBehaviour   
{
    [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
    [SerializeField] private Transform _woodTransform;
    [SerializeField] private Vector3 _rotationVector;
    [SerializeField] private float _rotationDuration;

    private void Start()
    {
        _woodTransform.DOLocalRotate(_rotationVector, _rotationDuration, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Restart)
            .SetEase(Ease.Linear);
    }

    public void Hit(int _keyIndex,float _damage)
    {
        float _colliderHeight = 240.5704f;
        float _newWeight = _skinnedMeshRenderer.GetBlendShapeWeight (_keyIndex)+_damage * (100f/ _colliderHeight); // collider size Y
        _skinnedMeshRenderer.SetBlendShapeWeight(_keyIndex, _newWeight);
    }
}
