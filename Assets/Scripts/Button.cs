using UnityEngine;

public class Button : MonoBehaviour {
    [SerializeField] private Material material;
    private bool pushed = false;
    private static int done = 0;
    [SerializeField] private int maxButn;

    void OnCollisionEnter(Collision collision) {
        if (pushed) return;

        gameObject.GetComponent<MeshRenderer>().material = material;

        pushed = true;
        done++;

        if (done == maxButn) {
            foreach (GameObject door in GameObject.FindGameObjectsWithTag("Door")) {
                Destroy(door);
            }
        }
    }
}
