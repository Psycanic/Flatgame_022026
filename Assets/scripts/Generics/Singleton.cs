using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<T>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject(typeof(T).Name);
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
            // 如果你希望它跨场景存在，取消下面这行注释
            // DontDestroyOnLoad(gameObject); 
        }
        else if (_instance != this)
        {
            Debug.LogWarning($"发现重复的单例 {typeof(T).Name}，已自动删除。");
            Destroy(gameObject);
        }
    }
}