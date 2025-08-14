using UnityEngine;

public abstract class SaiSingleton<T> : SaiMonoBehaviour where T : SaiMonoBehaviour //where T : SaiMonoBehaviour: Ràng buộc T bắt buộc phải là (hoặc kế thừa) SaiMonoBehaviour.
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null) Debug.LogError("Singleton instance has not been created yet!");
            return _instance;
        }
    }
    protected override void Awake()
    {
        base.Awake();
        this.LoadInstance();
    }
    protected virtual void LoadInstance()
    {
        if(_instance == null)
        {
            _instance = this as T; //ép kiểu sang T
            DontDestroyOnLoad(gameObject); //để object này không bị xóa khi load scene mới
            return;
        }
        if (_instance != null) Debug.LogError("Another instance of SingletonExample already exit!");
    }
}