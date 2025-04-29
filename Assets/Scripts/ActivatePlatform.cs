using UnityEngine;

public class ActivatePlatform : MonoBehaviour {
    [SerializeField] private Collect score;
    [SerializeField] private Platform platform;

    void Start() {
        platform = gameObject.GetComponent<Platform>();
    }

    void Update() {
        int[] scr = score.GetScoreInfo();
        if (scr[0] == scr[1]) platform.enabled = true;
    }
}
