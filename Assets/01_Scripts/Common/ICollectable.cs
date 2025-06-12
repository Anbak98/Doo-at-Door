using UnityEngine;

public interface ICollectable
{
    void Drain(Transform from);
    int Get();
}
