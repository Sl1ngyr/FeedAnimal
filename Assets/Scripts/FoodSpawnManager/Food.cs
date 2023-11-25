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
        NameDescription nameTriggerCollider = collider.GetComponent<NameDescription>();

        if (nameTriggerCollider != null)
        {
            switch (nameTriggerCollider.nameType)
            {
                case NameType.Animal:
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
