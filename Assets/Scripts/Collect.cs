using UnityEngine;
using TMPro;

public class Collect : MonoBehaviour {
    [SerializeField] private int score = 0;
    [SerializeField] private int maxScore = 2;
    [SerializeField] private TMP_Text text;
    [SerializeField] private GameObject collectablePrefab;

    public int[] GetScoreInfo() {
        return new int[] { score, maxScore };
    }

    void OnTriggerEnter (Collider other) {
        Debug.Log(other);

        if (other.gameObject.tag == "Collectable") {
            score++;
            UpdateUI();
            //SpawnNewCollectable();
            Destroy(other.gameObject);
        }
    }

    private void UpdateUI() {
        text.text = "Score: " + score;
    }

    private void SpawnNewCollectable() {
        Vector3 randPosition = new Vector3(Random.Range(-10f, 10f), 1, Random.Range(-10f, 10f));
        Instantiate(collectablePrefab, randPosition, transform.rotation);
    }
}
