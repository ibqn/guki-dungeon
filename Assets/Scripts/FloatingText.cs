
using UnityEngine;
using UnityEngine.UI;

public class FloatingText
{
    private bool active;
    public GameObject GameObjectSource { get; set; }

    public Text Text { get; set; }
    public Vector3 Motion { get; set; }
    public float Duration { get; set; }
    private float lastShown;

    public bool Active
    {
        get { return active; }
    }
    public void Show()
    {
        active = true;
        lastShown = Time.time;
        GameObjectSource.SetActive(true);
    }

    public void Hide()
    {
        active = false;
        GameObjectSource.SetActive(false);
    }

    public void UpdateFloatingText()
    {
        if (!active)
        {
            return;
        }

        if (Time.time - lastShown > Duration)
        {
            Hide();
        }

        GameObjectSource.transform.position += Motion * Time.deltaTime;
    }
}

