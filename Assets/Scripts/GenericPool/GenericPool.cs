using AbstractFactory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenericPoolUtil {

    public class GenericPool<T> : MonoBehaviour where T : MonoBehaviour {
        public List<T> pooledItems = new List<T>();
        public List<T> itemsInUse = new List<T>();
        public int initItemCount;
        [SerializeField] protected AbstractFactory<T> itemFactory;
        public bool isExpandable = false;

        protected virtual void Awake() {
            for (int i = 0; i < initItemCount; i++) {
                var item = itemFactory.GetNewInstance();
                pooledItems.Add(item);
                item.transform.parent = this.transform;
                item.gameObject.SetActive(false);
            }
        }
        public T GetItemFromPool() {
            if (pooledItems.Count > 0) {
                T toReturn = pooledItems[0];
                itemsInUse.Add(pooledItems[0]);
                pooledItems.Remove(pooledItems[0]);
                toReturn.gameObject.SetActive(true);
                return toReturn;
            } else if (isExpandable) {
                T newInstance = itemFactory?.GetNewInstance();
                itemsInUse.Add(newInstance);
                newInstance.gameObject.SetActive(true);
                return newInstance;
            }
            return null;
        }

        public void ReturnItemToPool(T item) {
            pooledItems.Add(item);
            if (itemsInUse.Contains(item)) {
                itemsInUse.Remove(item);
            }
            item.transform.parent = this.transform;
            item.gameObject.SetActive(false);
        }

        public void ReturnAllItemsToPool() {
            foreach (T item in itemsInUse) {
                pooledItems.Add(item);
                item.gameObject.SetActive(false);
            }
            itemsInUse.Clear();
        }
    }
}