using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour {
    [SerializeField] private int scene;
    void OnCollisionEnter(Collision collision) {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
