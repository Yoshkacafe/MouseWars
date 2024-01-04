using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvaManager : MonoBehaviour
{
    public Animator anim;
    public GameObject LoadingScreen1;
    public GameObject LoadingScreen2;
    public GameObject Menu;
    public GameObject Select;
    public Slider loadingSlider;

    void Start()
    {
        // Booléens
        anim.GetComponent<Animator>().SetBool("canOpenMouseSelector", false);
        anim.GetComponent<Animator>().SetBool("canGoToMenu", false);

        // Activation du menu
        Menu.SetActive(false);
        LoadingScreen2.SetActive(true);
        Select.SetActive(false);
    }

    void Update()
    {
        StartCoroutine(LoadingScreenTime());
    }

    public void LoadMouseSelector()
    {
        Select.SetActive(true);
        anim.GetComponent<Animator>().SetBool("canOpenMouseSelector", true);    
    }

    public void QuitMouseSelector()
    {
        if (anim.GetComponent<Animator>().GetBool("canOpenMouseSelector") == true)
        {
            anim.GetComponent<Animator>().SetBool("canGoToMenu", true);
            anim.GetComponent<Animator>().SetBool("canOpenMouseSelector", false);
            Select.SetActive(false);
            StartCoroutine(waiter());

        }
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1f);
        anim.GetComponent<Animator>().SetBool("canGoToMenu", false);
    }

    IEnumerator LoadingScreenTime()
    {
        yield return new WaitForSeconds(2f);
        LoadingScreen2.SetActive(false);
        LoadingScreen1.SetActive(true);
        yield return new WaitForSeconds(2f);
        LoadingScreen1.SetActive(false);
        Menu.SetActive(true);
    }
}
