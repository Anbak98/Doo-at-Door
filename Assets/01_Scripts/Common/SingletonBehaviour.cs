using UnityEngine;

public abstract class SingletonBehaviour<T> : MonoBehaviour where T : SingletonBehaviour<T>
{
    private static T _instacne = null;

    public static T Instance
    {
        get
        {
            if (_instacne == null)
            {
                Create();
            }

            return _instacne;
        }
    }

    protected static void Create()
    {
        if (_instacne == null)
        {
            T[] objects = FindObjectsOfType<T>();

            if (objects.Length > 0)
            {
                _instacne = objects[0];

                for (int i = 1; i < objects.Length; ++i)
                {
                    if (Application.isPlaying)
                    {
                        Destroy(objects[i].gameObject);
                    }
                    else
                    {
                        DestroyImmediate(objects[i].gameObject);
                    }
                }
            }
            else
            {
                GameObject go = new GameObject(string.Format("{0}", typeof(T).Name));
                _instacne = go.AddComponent<T>();
            }
        }
    }

    protected virtual void Awake()
    {
        Create();

        if (_instacne != this)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this);
        }
    }

    protected virtual void OnEnable() { }
    protected virtual void Start() { }
    protected virtual void Update() { }
    protected virtual void FixedUpdate() { }
    protected virtual void LateUpdate() { }
    protected virtual void OnDisable() { }


    protected virtual void OnDestroy()
    {
        _instacne = null;
    }
}
