using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public TMP_InputField Namespace;
    public string Name;

    public TextMeshProUGUI BestScore;
    public int Score;

    //Get the best saved values and load them for display
    void Start()
    {
        Score = StoredData.Instance.Score;
        Name = StoredData.Instance.BestName;
        BestScore.text = "Best Score: " + Name + " : " + Score;
    }
    //Update the name variable to keep track
    public void SetName()
    {
        Name = Namespace.text;
    }
    //When starting, send the name variable to the Save script to keep it temporarily 
    public void StartGame()
    { 
        StoredData.Instance.Name = Name;
        SceneManager.LoadScene(1);
    }
    
    public void QuitGame()
    {

        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }
}
