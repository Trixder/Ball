using UnityEngine;

public class Quit : MonoBehaviour {
    void Update() {
        if (Input.anyKey) Application.Quit();
    }
}
