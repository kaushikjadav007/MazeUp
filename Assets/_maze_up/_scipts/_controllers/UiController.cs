using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    public GameObject m_ui_bg;
    public GameObject m_instructions;
    [Space]
    public Button m_play;
    public Button m_restart;
    [Space]
    public TextMeshProUGUI m_count_text;
    public TextMeshProUGUI m_score_text;

    [Header("Script holder")]
    public ScriptRefrenceHolder m_script_ref;
    public Valueholder m_value_holder;

    private void OnEnable()
    {
        m_script_ref.m_ui_controller = GetComponent<UiController>();
        m_value_holder.m_score_text = m_score_text;
        m_value_holder.m_score = 0;

        m_play.onClick.AddListener(_PlayMethod);
        m_restart.onClick.AddListener(_RestartMethod);
    }

    private void OnDisable()
    {
        m_play.onClick.RemoveListener(_PlayMethod);
        m_restart.onClick.RemoveListener(_RestartMethod);
    }

    private void _RestartMethod()
    {
        m_restart.interactable = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void _PlayMethod()
    {
        m_play.gameObject.SetActive(false);
        StartCoroutine(_CountDown());
    }

    public void _OnGemaOver()
    {
        m_ui_bg.SetActive(true);
        m_restart.gameObject.SetActive(true);
    }


    IEnumerator _CountDown()
    {
        m_instructions.SetActive(false);
        m_ui_bg.SetActive(false);
        m_count_text.text = "1";
        m_count_text.gameObject.SetActive(true);

        for (int i = 1; i <= 3; i++)
        {
            m_count_text.text =i.ToString();
            yield return new WaitForSecondsRealtime(0.5f);
        }

        m_count_text.text = "GO";

        yield return new WaitForSecondsRealtime(0.5f);

        m_count_text.gameObject.SetActive(false);

        yield return new WaitForEndOfFrame();

        m_script_ref.m_player_Controller.m_input = true;
        m_value_holder.m_score = 0;
        m_score_text.text = "";
        
        m_score_text.gameObject.SetActive(true);
    }



}
