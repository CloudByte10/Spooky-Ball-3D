using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointSystem : MonoBehaviour
{
    private static TextMeshProUGUI score;
    private static int collected;
    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();

        collected = 0;
    }
    public static int GetValue()
    {
        return collected;
    }
    public static void SetValue(int c)
    {
        collected = c;
    }
    public static void BallFound()
    {
        int c;

        c = GetValue();
        if (c < 12)
            c += 1;
        SetValue(c);
        score.text = collected.ToString() + "/12";

    }
}
