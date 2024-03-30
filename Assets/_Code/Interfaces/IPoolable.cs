using Assets._Code.Utilities;
using UnityEngine;

namespace Assets._Code.Interfaces
{
    public interface IPoolable<T> where T : MonoBehaviour, IPoolable<T>
    {
        ObjectPool<T> Pool { get; set;  }
    }
}