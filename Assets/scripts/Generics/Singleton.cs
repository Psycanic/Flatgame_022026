using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {//if _instance not assigned, try find in the scene

                _instance = FindObjectOfType<T>();
                if (_instance == null)//if still no , make one
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    _instance = obj.AddComponent<T>();
                }
            }
            return _instance;

        }
    }

    protected virtual void Awake()
    {
        if (_instance != null)
        {

            _instance = this as T;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);// ensuring only one instance exists
        }

    }

    
        

}
