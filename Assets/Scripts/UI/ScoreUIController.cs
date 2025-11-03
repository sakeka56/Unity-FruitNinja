using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using System;

public class ScoreUIController : MonoBehaviour
{

    private Image scoreImage;
    private TextMeshProUGUI scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        scoreText.text = RefreshScore(GameManager.Instance.ScoreManager.Score).ToString();
    }

    public void Init()
    {
        scoreImage = GetComponentInChildren<Image>();
        scoreText = GetComponentInChildren<TextMeshProUGUI>();
        if(scoreImage == null || scoreText == null)
        {
            Debug.LogError("ScoreUIController: Missing Image or TextMeshProUGUI component.");
            return;
        }
        scoreText.text = GameManager.Instance.ScoreManager.Score.ToString();
    }

    int RefreshScore(int targetScore)
    {
        int res = Convert.ToInt32( scoreText.text);

        res = Mathf.Lerp(res, targetScore, Time.deltaTime * 5f).ConvertTo<int>();


        return res;
    }
}
