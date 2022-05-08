using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : Collidable
{
    [SerializeField]
    private string[] sceneNames;

    protected override void OnCollide(Collider2D collider)
    {
        // base.OnCollide(collider);
        if (collider.name == "Player")
        {
            GameManager.Instance.SaveState();
            string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
            SceneManager.LoadScene(sceneName);
        }
    }
}
