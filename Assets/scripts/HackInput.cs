using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HackInput : MonoBehaviour
{
    [SerializeField] InputField inputField;
    [SerializeField] Text resultText;
    public float delay = 5;

    private void Start()
    {
        resultText.text = "Waiting For Input To Start Hacking";
    }

    public void OnValidate()
    {
        string input = inputField.text;

        if (input == "185")
        {
            resultText.text = "System Hacked. Loading Next Level";
            resultText.color = Color.green;
            StartCoroutine(LoadLevelAfterDelay(delay));
        }

        else
        {
            resultText.text = "Code Invalid";
            resultText.color = Color.red;
        }
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }

}
