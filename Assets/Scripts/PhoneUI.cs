using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhoneUI : MonoBehaviour
{
    public GameObject phone;
    public GameObject notibar;
    public GameObject notiBG;
    public GameObject notiIcon;
    public GameObject notiText;

    public void noti(ChatContainer chatRoom)
    {
        //GameObject notiBG = this.notibar.transform.Find("BG").gameObject;
        //GameObject notiIcon = notiBG.transform.Find("icon").gameObject;
        //GameObject notiText = notiBG.transform.Find("TextNoti").gameObject;

        this.notiBG.SetActive(true);
        this.notiIcon.SetActive(true);
        this.notiText.SetActive(true);

        StopCoroutine("Fade");
        StartCoroutine("Fade");
    }

    IEnumerator Fade()
    {
        Image imgBG = this.notiBG.GetComponent<Image>();
        Image imgIcon = this.notiIcon.GetComponent<Image>();
        TextMeshProUGUI txt = this.notiText.GetComponentInChildren<TextMeshProUGUI>();

        for (float f = 0; f <= 1; f += 0.01f)
        {
            Color colorBG = imgBG.color;
            Color colorIcon = imgIcon.color;
            Color colorText = txt.color;

            colorBG.a = f;
            colorIcon.a = f;
            colorText.a = f;

            imgBG.color = colorBG;
            imgIcon.color = colorIcon;
            txt.color = colorText;

            yield return new WaitForSeconds(0.01f);
            //yield return new WaitForSeconds(0.01f);
        }

        for (int i = 0; i < 4; i++)
        {
            for (float f = 1f; f >= 0; f -= 0.01f)
            {
                Color color = imgBG.color;
                color.a = f;
                imgBG.color = color;
                yield return new WaitForSeconds(0.01f);
                //yield return new WaitForSeconds(0.01f);
            }

            for (float f = 0f; f <= 1; f += 0.01f)
            {
                Color color = imgBG.color;
                color.a = f;
                imgBG.color = color;
                yield return new WaitForSeconds(0.01f);
                //yield return new WaitForSeconds(0.01f);
            }

            
        }


        for (float f = 1f; f >= 0; f -= 0.01f)
        {
            Color colorBG = imgBG.color;
            Color colorIcon = imgIcon.color;
            Color colorText = txt.color;

            colorBG.a = f;
            colorIcon.a = f;
            colorText.a = f;

            imgBG.color = colorBG;
            imgIcon.color = colorIcon;
            txt.color = colorText;

            yield return new WaitForSeconds(0.01f);
            //yield return new WaitForSeconds(0.01f);
        }



    }
}
