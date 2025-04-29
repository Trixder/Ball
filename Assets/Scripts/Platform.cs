using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Vector3 minPos;
    [SerializeField] private Vector3 maxPos;
    [SerializeField] private Vector3 toPos;

    [SerializeField] private float t;
    [SerializeField] private float speed = 1f;

    void Start() {
        toPos = maxPos;
    }

    void Update() {
        transform.position = Vector3.MoveTowards(transform.position, toPos, Time.deltaTime * speed);

        if (transform.position == maxPos || transform.position == minPos) {

            Vector3 holder = minPos;
            minPos = maxPos;
            maxPos = holder;
            toPos = maxPos;
        }
    }
}
