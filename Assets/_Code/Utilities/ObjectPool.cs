using Assets._Code.Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Code.Utilities
{
    public class ObjectPool<T> where T : MonoBehaviour, IPoolable<T>
    {
        private List<T> _avialableObjects;
        private Func<T> _creationFunc;

        public ObjectPool(Func<T> createFunc, int initialCount)
        {
            _avialableObjects = new List<T>();
            _creationFunc = createFunc;

            for (int i = 0; i < initialCount; i++)
            {
                var obj = _creationFunc();

                obj.Pool = this;
                obj.gameObject.SetActive(false);

                _avialableObjects.Add(obj);
            }
        }

        public void AddToPool(T instance)
        {
            instance.gameObject.SetActive(false);
            _avialableObjects.Add(instance);
        }

        public T GetFromPool()
        {
            T instance = null;

            for (int i = 0; i < _avialableObjects.Count; i++)
            {
                if (_avialableObjects[i].isActiveAndEnabled == false)
                {
                    instance = _avialableObjects[i];
                    instance.gameObject.SetActive(true);
                    return instance;
                }
            }

            instance = CreateNewInstance();
            instance.gameObject.SetActive(true);
            return instance;
        }

        public void Release(T instance)
        {
            instance.gameObject.SetActive(false);
        }

        private T CreateNewInstance()
        {
            var obj = _creationFunc();

            obj.Pool = this;
            _avialableObjects.Add(obj);
            obj.gameObject.SetActive(false);

            return obj;
        }
    }
}