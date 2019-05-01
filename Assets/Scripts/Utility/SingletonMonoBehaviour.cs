using UnityEngine;

/// <summary>
/// Singleton mono behaviour.
/// </summary>
public class SingletonMonoBehaviour<Type> : MonoBehaviour where Type : SingletonMonoBehaviour<Type>
{
    protected static Type instance;
    public static Type Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (Type)FindObjectOfType(typeof(Type));

                if (instance == null)
                    Debug.LogWarning(typeof(Type) + "is nothing");
            }

            return instance;
        }
    }

    [SerializeField]
    private bool dontDestroyOnLoad;

    protected virtual void Awake()
    {
        CheckInstance();

        if (dontDestroyOnLoad)
            DontDestroyOnLoad(gameObject);
    }

    protected bool CheckInstance()
    {
        if (instance == null)
        {
            instance = (Type)this;
            return true;
        }

        if (Instance == this)
            return true;

        Destroy(this);
        return false;
    }
}