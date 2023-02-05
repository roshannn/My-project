using UnityEngine;

namespace AbstractFactory {
    public abstract class AbstractFactory<T> : MonoBehaviour, IFactory<T> where T : MonoBehaviour {
        [SerializeField]
        protected T m_Prefab;

        /// <summary>Creates an instance of the prefab with the type of factory attached to it </summary>

        public virtual T GetNewInstance() {
            return Instantiate(m_Prefab);
        }
        
        public virtual T GetNewInstance(Vector3 position, Quaternion rotation) {
            return Instantiate(m_Prefab, position, rotation);
        }
    }
}