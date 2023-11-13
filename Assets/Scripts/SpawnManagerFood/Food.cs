using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Food : MonoBehaviour
{
    [SerializeField] private float speed;
    private float MaxRangeZ = 30;
    
    private ObjectPool<Food> _pool;
    
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        IsOutOfBound();
    }
    
    private void OnTriggerEnter(Collider collider)
    {
        GateDescription nameTriggerCollider = collider.GetComponent<GateDescription>();

        if (nameTriggerCollider != null)
        {
            switch (nameTriggerCollider.gateType)
            {
                case GateType.Animal:
                    _pool.Release(this);
                    break;
            }
        }
    }

    private void IsOutOfBound()
    {
        if(gameObject.transform.position.z > MaxRangeZ) _pool.Release(this);
    }
    
    public void SetPool(ObjectPool<Food> pool)
    {
        _pool = pool;
    }
    
}
