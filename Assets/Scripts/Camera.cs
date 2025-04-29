using Unity.VisualScripting;
using UnityEngine;

public class Camera : MonoBehaviour {
    [SerializeField] private Transform playerObject;
    [SerializeField] private Transform minPos;
    [SerializeField] private Transform maxPos;
    [SerializeField] private Transform check;
    [SerializeField] private bool colOne;
    [SerializeField] private bool colTwo;
    [SerializeField] private float s;
    [SerializeField] private float f;

    private void Update() {
        RaycastHit hitOne;
        RaycastHit hitTwo;

        Debug.DrawRay(transform.position, transform.forward * f, Color.red);
        Debug.DrawRay(check.position, check.forward * f, Color.blue);

        if (Physics.Raycast(transform.position, transform.forward, out hitOne, f)) { 
            colOne = true;
            if (hitOne.collider.tag == "Player") colOne = false;
        }

        if (Physics.Raycast(check.position, check.forward, out hitTwo, f)) {
            colTwo = true;
            if (hitTwo.collider.tag == "Player") colTwo = false;
        }

        if (colOne) transform.position = Vector3.MoveTowards(transform.position, minPos.position, Time.deltaTime * s);
        else if (!colTwo) transform.position = Vector3.MoveTowards(transform.position, maxPos.position, Time.deltaTime * s);
    }
}