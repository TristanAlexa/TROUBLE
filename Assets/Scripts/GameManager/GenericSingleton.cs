using UnityEngine;

// This code is based on: http://www.unitygeek.com/unity_c_singleton/ 

namespace Assets
{
    /// <summary>
    /// A generic Singleton class that can be used to create game controller: game manager, audio manager, ..
    /// </summary>

    // We inherit from MonoBehaviour to get access to events from the game 
    // The <T> is something like a template in cpp: we specify the class name when we use it. 
    public class GenericSingleton<T> : MonoBehaviour where T : Component
    {
        // private field of the instance of this object
        private static T instance;

        // public property for the private field "instance"
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    // Search for existing instance of this Singleton object
                    instance = FindObjectOfType<T>();
                    // If no current instance is found, create a new one
                    if (instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.name = typeof(T).Name;
                        instance = obj.AddComponent<T>();
                    }
                }
                return instance;
            }
        }

        // Gets called when the script is being loaded (i.e., before the start of the game)
        public virtual void Awake()
        {
            if (instance == null)
            {
                instance = this as T;
                // Prevents the Singleton instance from being destroyed when we move to a new scene
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
