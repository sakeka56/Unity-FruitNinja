using UnityEngine;
using TMPro;
using System;

public class ComboUIController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI comboText;


    private float showTimer = 0;
    public float ShowTime = 2;



    private void OnEnable()
    {
        SetTextInt(0);
        if (GameManager.Instance.ComboManager != null)
        {
            GameManager.Instance.ComboManager.OnCombo += ShowCombo;
        }
    }


    private void OnDisable()
    {
        if (GameManager.Instance.ComboManager != null) GameManager.Instance.ComboManager.OnCombo -= ShowCombo;
    }



    public void ShowCombo(int comboCount)
    {
        SetTextInt(comboCount);
        comboText.color = Color.white;
        showTimer = 0;
        comboText.gameObject.SetActive(true);

    }



    public void Update()
    {
        showTimer += Time.deltaTime;
        if(showTimer >= ShowTime)
        {
            Color c = comboText.color;
            float newA = Mathf.Lerp(c.a, 0, 0.1f);
            comboText.color = new Color(c.r, c.g, c.b, newA);


            if(newA <= 0.05f)
            {
                comboText.gameObject.SetActive(false);
            }
        }
    }

    private int GetTextInt()
    {
        string s = comboText.text;
        s.Remove(0);
        return Convert.ToInt32(s);
    }

    private void SetTextInt(int count)
    {
        comboText.text = "x" + count.ToString();
    }

}
