using UnityEngine;

public class ItemInstance : MonoBehaviour, IPooledObject, ICollectable
{
    public ItemData itemData;
    public int ItemID;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    float speed = 0f;
    float acceleration = 0.1f; // 점점 빨라지는 정도
    float maxSpeed = 1f;
    float distanceThreshold = 0.1f;

    public void Init(int itemID)
    {
        _spriteRenderer.sprite = itemData.GetItemData(itemID).sprite;
        ItemID = itemID;
    }

    public void Drain(Transform from)
    {
        if (Vector3.Distance(transform.position, from.position) > distanceThreshold)
        {
            speed = Mathf.Min(speed + acceleration * Time.deltaTime, maxSpeed);

            Vector3 direction = (from.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
        else
        {
            transform.position = from.position; // 정확히 도착 지점으로 정렬
        }
    }

    public int Get()
    {
        ObjectPool.Instance.Return<ItemInstance>(gameObject);
        return ItemID;
    }

    public void OnGetFromPool()
    {
    }

    public void OnReturnToPool()
    {
    }
}