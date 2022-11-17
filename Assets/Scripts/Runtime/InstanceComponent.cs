using UnityEngine;

namespace Runtime
{
    public class InstanceComponent : MonoBehaviour
    {
        private void Awake()
        {
            UnityEngine.Debug.Log($"{nameof(InstanceComponent)}: Created", this);
        }
    }
}