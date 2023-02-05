using UnityEngine;

namespace AbstractFactory {
    public interface IFactory<T> {
        T GetNewInstance(Vector3 position, Quaternion rotation);
        T GetNewInstance();
    }
}