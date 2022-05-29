using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    [SerializeField]
    private GameObject textContainer;
    [SerializeField]
    private GameObject textPrefab;

    private List<FloatingText> floatingTexts = new List<FloatingText>();

    private void Update()
    {
        foreach (var floatingText in floatingTexts)
        {
            floatingText.UpdateFloatingText();
        }
    }

    public void Show(string message, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingText floatingText = GetFloatingText();

        floatingText.Text.text = message;
        floatingText.Text.fontSize = fontSize;
        floatingText.Text.color = color;
        // transfer world space to screens space so we can use it in the UI
        floatingText.GameObjectSource.transform.position = Camera.main.WorldToScreenPoint(position);
        floatingText.Motion = motion;
        floatingText.Duration = duration;

        floatingText.Show();
    }

    private FloatingText GetFloatingText()
    {
        FloatingText floatingText = floatingTexts.Find(text => !text.Active);

        if (floatingText == null)
        {
            floatingText = new FloatingText();
            floatingText.GameObjectSource = Instantiate(textPrefab);
            floatingText.GameObjectSource.transform.SetParent(textContainer.transform);
            floatingText.Text = floatingText.GameObjectSource.GetComponent<Text>();

            floatingTexts.Add(floatingText);
        }

        return floatingText;
    }
}
