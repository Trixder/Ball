using UnityEngine;

public class SpeedBoost : MonoBehaviour {
    private GameObject player;

    public void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag != "Player") return;

        player.GetComponent<Player>().speed = 2500;
    }

    void OnCollisionExit(Collision collision) {
        if (collision.gameObject.name != "Player") return;

        player.GetComponent<Player>().speed = 500;
        Debug.Log(player.GetComponent<Player>().speed);
    }
}
