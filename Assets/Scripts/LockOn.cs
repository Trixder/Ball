using UnityEngine;

public class LockOn : MonoBehaviour {
    [SerializeField] Transform cameraPivot;
    void Update() {
        transform.position = cameraPivot.position;
    }
}
