using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSingleton<T> : MonoBehaviour where T : Component
{
    protected static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = "Singleton_" + typeof(T).ToString();
                    _instance = obj.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(transform.gameObject);
            OnAwake();
        }
        else
        {
            if (this != _instance)
            {
                Destroy(this.gameObject);
            }
            else
            {
                OnAwake();
            }
        }

    }
    protected virtual void OnAwake()
    {

    }

    public virtual void Init()
    {

    }
}
