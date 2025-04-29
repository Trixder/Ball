using UnityEngine;

public class lookat : MonoBehaviour {
    [SerializeField] private Transform lookAtThis;
    void Update() { transform.LookAt(lookAtThis); }
}
