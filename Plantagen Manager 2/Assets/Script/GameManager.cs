using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class GameManager : MonoBehaviour
{
    [Header("Spielmodi")]
    [Space(5)]

    public bool neuesGame;
    public bool gameLaden;
    public bool browserGame;

    [Space(5)]
    [Header("Spielstand")]
    [Space(5)]

    [SerializeField] private int geld;
    [SerializeField] private int kokain;
    [SerializeField] private int bubatz;
    [SerializeField] private int heroin;

    [SerializeField] private int schulden;

    [SerializeField] private bool haus1;
    [SerializeField] private bool haus2;
    [SerializeField] private bool haus3;   

    [SerializeField] private int haus1Tische;
    [SerializeField] private bool haus1Verpackstation;
    [SerializeField] private bool haus1Angestellter1;
    [SerializeField] private bool haus1Angestellter2;
    [SerializeField] private bool haus1Labor;
    [SerializeField] private bool haus1SchwarzLicht;
    [SerializeField] private bool haus1Drohne;

    [SerializeField] private int haus2Tische;
    [SerializeField] private bool haus2Verpackstation;
    [SerializeField] private bool haus2Angestellter1;
    [SerializeField] private bool haus2Angestellter2;
    [SerializeField] private bool haus2Labor;
    [SerializeField] private bool haus2SchwarzLicht;
    [SerializeField] private bool haus2Drohne;

    [SerializeField] private int haus3Tische;
    [SerializeField] private bool haus3Verpackstation;
    [SerializeField] private bool haus3Angestellter1;
    [SerializeField] private bool haus3Angestellter2;
    [SerializeField] private bool haus3Labor;
    [SerializeField] private bool haus3SchwarzLicht;
    [SerializeField] private bool haus3Drohne;

    [Space(5)]
    [Header("Spielwelt Objekte")]
    [Space(5)]

    [SerializeField] private MonoBehaviour player;
    [SerializeField] private GameObject crosshair;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject DrogenAnkauf;
    [SerializeField] private GameObject verkaufMenu;
    [SerializeField] private GameObject saveButton;
    [SerializeField] private GameObject bankPanel;
    [SerializeField] private GameObject[] darlehenButtons;
    [SerializeField] private GameObject handy;
    [SerializeField] private GameObject häuserPanel;
    [SerializeField] private GameObject einstellungenPanel;
    [SerializeField] private GameObject steuerungsPanel;
    [SerializeField] private GameObject drohnePanel;

    [Space(5)]
    [Header("Haus1")]
    [Space(5)]

    [SerializeField] private GameObject haus1Schild;
    [SerializeField] private GameObject haus1Tür;
    [SerializeField] private GameObject haus1Panel;
    [SerializeField] private GameObject[] tischeObject;
    [SerializeField] private GameObject verpackstationHaus1Object;
    [SerializeField] private GameObject angestellter1Haus1Object;
    [SerializeField] private GameObject angestellter2Haus1Object;
    [SerializeField] private GameObject haus1LaborObject;
    [SerializeField] private GameObject haus1AngestellterPanel;
    [SerializeField] private GameObject haus1SchwarzLichtObject;
    [SerializeField] private GameObject haus1SchwarzLichtTrigger;
    [SerializeField] private GameObject drohneHaus1;

    [SerializeField] private GameObject tischeHaus1Btn;
    [SerializeField] private GameObject verpackstationHaus1Btn;
    [SerializeField] private GameObject laborHaus1Btn;
    [SerializeField] private GameObject drohneHaus1Btn;
    [SerializeField] private GameObject schwarzLichtHaus1Btn;
    [SerializeField] private GameObject angestellter1Haus1Btn;
    [SerializeField] private GameObject angestellter2Haus1Btn;

    [Space(5)]
    [Header("Haus2")]
    [Space(5)]

    [SerializeField] private GameObject haus2Schild;
    [SerializeField] private GameObject haus2Tür;
    [SerializeField] private GameObject haus2Panel;
    [SerializeField] private GameObject[] haus2TischeObject;
    [SerializeField] private GameObject verpackstationHaus2Object;
    [SerializeField] private GameObject angestellter1Haus2Object;
    [SerializeField] private GameObject angestellter2Haus2Object;
    [SerializeField] private GameObject haus2LaborObject;
    [SerializeField] private GameObject haus2AngestellterPanel;
    [SerializeField] private GameObject haus2SchwarzLichtObject;
    [SerializeField] private GameObject haus2SchwarzLichtTrigger;
    [SerializeField] private GameObject drohneHaus2;

    [SerializeField] private GameObject tischeHaus2Btn;
    [SerializeField] private GameObject verpackstationHaus2Btn;
    [SerializeField] private GameObject laborHaus2Btn;
    [SerializeField] private GameObject drohneHaus2Btn;
    [SerializeField] private GameObject schwarzLichtHaus2Btn;
    [SerializeField] private GameObject angestellter1Haus2Btn;
    [SerializeField] private GameObject angestellter2Haus2Btn;

    [Space(5)]
    [Header("Haus3")]
    [Space(5)]

    [SerializeField] private GameObject haus3Schild;
    [SerializeField] private GameObject haus3Tür;
    [SerializeField] private GameObject haus3Panel;

    [SerializeField] private GameObject[] haus3TischeObject;
    [SerializeField] private GameObject verpackstationHaus3Object;
    [SerializeField] private GameObject angestellter1Haus3Object;
    [SerializeField] private GameObject angestellter2Haus3Object;
    [SerializeField] private GameObject haus3LaborObject;
    [SerializeField] private GameObject haus3AngestellterPanel;
    [SerializeField] private GameObject haus3SchwarzLichtObject;
    [SerializeField] private GameObject haus3SchwarzLichtTrigger;
    [SerializeField] private GameObject drohneHaus3;

    [SerializeField] private GameObject tischeHaus3Btn;
    [SerializeField] private GameObject verpackstationHaus3Btn;
    [SerializeField] private GameObject laborHaus3Btn;
    [SerializeField] private GameObject drohneHaus3Btn;
    [SerializeField] private GameObject schwarzLichtHaus3Btn;
    [SerializeField] private GameObject angestellter1Haus3Btn;
    [SerializeField] private GameObject angestellter2Haus3Btn;

    [Space(5)]
    [Header("Anzeigen")]
    [Space(5)]

    [SerializeField] private TMP_Text geldanzeige;
    [SerializeField] private TMP_Text kokainanzeige;
    [SerializeField] private TMP_Text kokainanzeigeAngestellter;
    [SerializeField] private TMP_Text bubatzanzeige;
    [SerializeField] private TMP_Text bubatzanzeigeAngestellter;
    [SerializeField] private TMP_Text heroinanzeige;
    [SerializeField] private TMP_Text heroinanzeigeAngestellter;
    [SerializeField] private TMP_Text tischAnzeige;
    [SerializeField] private TMP_Text tischeAnzeigeHaus2;
    [SerializeField] private TMP_Text tischeAnzeigeHaus3;
    [SerializeField] private TMP_Text schuldenAnzeige;
    [SerializeField] private TMP_Text sensAnzeige;

    [Space(5)]
    [Header("Inputfelder")]
    [Space(5)]

    [SerializeField] private TMP_InputField schuldenInput;

    [Space(5)]
    [Header("Spline Animate")]
    [Space(5)]

    [SerializeField] private SplineAnimate splineAnimateVerkäuferHaus1;
    [SerializeField] private SplineAnimate splineAnimateVerkäuferHaus2;
    [SerializeField] private SplineAnimate splineAnimateVerkäuferHaus3;

    [Space(5)]
    [Header("Cooldowns")]
    [Space(5)]

    [SerializeField] private float cooldownTime;
    private float lastTriggerTime;

    [Space(5)]
    [Header("Slider")]
    [Space(5)]

    [SerializeField] private Slider slider;

    [Space(5)]
    [Header("SpawnPoint")]
    [Space(5)]

    [SerializeField] private GameObject spawnPoint;

    private Data data;

    void Start()
    {
        geld = 2000;

        neuesGame = PlayerPrefs.GetInt("NeuesGame", 0) == 1 ? true : false;
        gameLaden = PlayerPrefs.GetInt("GameLaden", 0) == 1 ? true : false;
        browserGame = PlayerPrefs.GetInt("BrowserGame", 0) == 1 ? true : false;

        if (browserGame)
        {
            saveButton.SetActive(false);
        }

        if (gameLaden)
        {
            LoadFromJson();
        }

        if (PlayerPrefs.HasKey("MouseSens"))
        {
            float savedValue = PlayerPrefs.GetFloat("MouseSens");
            slider.value = savedValue;

            sensAnzeige.text = savedValue.ToString();
        }
    }

    public void SaveToJson()
    {
        data = new Data();

        data.geld = geld;
        data.kokain = kokain;
        data.bubatz = bubatz;
        data.heroin = heroin;

        data.schulden = schulden;

        data.haus1 = haus1;
        data.haus2 = haus2;
        data.haus3 = haus3;

        data.haus1Tische = haus1Tische;
        data.haus1Verpackstation = haus1Verpackstation;
        data.haus1Angestellter1 = haus1Angestellter1;
        data.haus1Angestellter2 = haus1Angestellter2;
        data.haus1Labor = haus1Labor;
        data.haus1SchwarzLicht = haus1SchwarzLicht;
        data.haus1Drohne = haus1Drohne;

        data.haus2Tische = haus2Tische;
        data.haus2Verpackstation = haus2Verpackstation;
        data.haus2Angestellter1 = haus2Angestellter1;
        data.haus2Angestellter2 = haus2Angestellter2;
        data.haus2Labor = haus2Labor;
        data.haus2SchwarzLicht = haus2SchwarzLicht;
        data.haus2Drohne = haus2Drohne;

        data.haus3Tische = haus3Tische;
        data.haus3Verpackstation = haus3Verpackstation;
        data.haus3Angestellter1 = haus3Angestellter1;
        data.haus3Angestellter2 = haus3Angestellter2;
        data.haus3Labor = haus3Labor;
        data.haus3SchwarzLicht = haus3SchwarzLicht;
        data.haus3Drohne = haus3Drohne;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.dataPath + "/Data.json", json);

    }

    public void LoadFromJson()
    {
        string json = File.ReadAllText(Application.dataPath + "/Data.json");
        data = JsonUtility.FromJson<Data>(json);

        geld = data.geld;
        kokain = data.kokain;
        bubatz = data.bubatz;
        heroin = data.heroin;

        schulden = data.schulden;

        haus1 = data.haus1;
        haus2 = data.haus2;
        haus3 = data.haus3;

        haus1Tische = data.haus1Tische;
        haus1Verpackstation = data.haus1Verpackstation;
        haus1Angestellter1 = data.haus1Angestellter1;
        haus1Angestellter2 = data.haus1Angestellter2;
        haus1Labor = data.haus1Labor;
        haus1SchwarzLicht = data.haus1SchwarzLicht;
        haus1Drohne = data.haus1Drohne;

        haus2Tische = data.haus2Tische;
        haus2Verpackstation = data.haus2Verpackstation;
        haus2Angestellter1 = data.haus2Angestellter1;
        haus2Angestellter2 = data.haus2Angestellter2;
        haus2Labor = data.haus2Labor;
        haus2SchwarzLicht = data.haus2SchwarzLicht;
        haus2Drohne = data.haus2Drohne;

        haus3Tische = data.haus3Tische;
        haus3Verpackstation = data.haus3Verpackstation;
        haus3Angestellter1 = data.haus3Angestellter1;
        haus3Angestellter2 = data.haus3Angestellter2;
        haus3Labor = data.haus3Labor;
        haus3SchwarzLicht = data.haus3SchwarzLicht;
        haus3Drohne = data.haus3Drohne;

        Aktualisieren();
    }

    public void Update()
    {
        AnzeigeUpdate();

        UIHandler();

        SpielweltHandler();

        ÜbergreifendeValueÄnderungenHandler();

        SchuldenAutomatischBezahlen();

        UpgradePanelUpdate();
    }

    IEnumerator DelayAndDeactivate()
    {
        yield return new WaitForSeconds(0.1f);

        verkaufMenu.SetActive(false);
        
    }

    public void Aktualisieren()
    {
        for (int i = 0; i < haus1Tische; i++)
        {
            tischeObject[i].SetActive(true);
        }

        if (haus1Verpackstation == true)
        {
            verpackstationHaus1Object.SetActive(true);
        }

        if (haus1Angestellter1 == true)
        {
            angestellter1Haus1Object.SetActive(true);
        }

        if (haus1Angestellter2 == true)
        {
            angestellter2Haus1Object.SetActive(true);
        }

        if (haus1Labor == true)
        {
            haus1LaborObject.SetActive(true);
        }

        if(haus1SchwarzLicht == true)
        {
            haus1SchwarzLichtObject.SetActive(true);

            GameObject spawnedObject = Instantiate(haus1SchwarzLichtTrigger, spawnPoint.transform);
            spawnedObject.transform.localPosition = Vector3.zero;
        }

        if(haus1Drohne == true)
        {
            drohneHaus1.SetActive(true);
        }

        for (int i = 0; i < haus2Tische; i++)
        {
            haus2TischeObject[i].SetActive(true);
        }

        if (haus2Verpackstation == true)
        {
            verpackstationHaus2Object.SetActive(true);
        }

        if (haus2Angestellter1 == true)
        {
            angestellter1Haus2Object.SetActive(true);
        }

        if (haus2Angestellter2 == true)
        {
            angestellter2Haus2Object.SetActive(true);
        }

        if (haus2Labor == true)
        {
            haus2LaborObject.SetActive(true);
        }

        if (haus2SchwarzLicht == true)
        {
            haus2SchwarzLichtObject.SetActive(true);

            GameObject spawnedObject = Instantiate(haus2SchwarzLichtTrigger, spawnPoint.transform);
            spawnedObject.transform.localPosition = Vector3.zero;
        }

        if (haus2Drohne == true)
        {
            drohneHaus2.SetActive(true);
        }

        for (int i = 0; i < haus3Tische; i++)
        {
            haus3TischeObject[i].SetActive(true);
        }

        if (haus3Verpackstation == true)
        {
            verpackstationHaus3Object.SetActive(true);
        }

        if (haus3Angestellter1 == true)
        {
            angestellter1Haus3Object.SetActive(true);
        }

        if (haus3Angestellter2 == true)
        {
            angestellter2Haus3Object.SetActive(true);
        }

        if (haus3Labor == true)
        {
            haus3LaborObject.SetActive(true);
        }

        if (haus3SchwarzLicht == true)
        {
            haus3SchwarzLichtObject.SetActive(true);

            GameObject spawnedObject = Instantiate(haus3SchwarzLichtTrigger, spawnPoint.transform);
            spawnedObject.transform.localPosition = Vector3.zero;
        }

        if (haus3Drohne == true)
        {
            drohneHaus3.SetActive(true);
        }
    }

    public void AnzeigeUpdate()
    {
        geldanzeige.text = geld.ToString() + "$";

        schuldenAnzeige.text = schulden.ToString() + "$";

        kokainanzeige.text = "Kokain: " + kokain.ToString() + "g";
        kokainanzeigeAngestellter.text = "Kokain: " + kokain.ToString() + "g";
        bubatzanzeige.text = "Bubatz: " + bubatz.ToString() + "stk";
        bubatzanzeigeAngestellter.text = "Bubatz: " + bubatz.ToString() + "stk";
        heroinanzeige.text = "Heroin: " + heroin.ToString() + "stk";
        heroinanzeigeAngestellter.text = "Heroin: " + heroin.ToString() + "stk";

        tischAnzeige.text = "Tische: " + haus1Tische + " weiteren kaufen für: 1000$";
        tischeAnzeigeHaus2.text = "Tische: " + haus2Tische + " weiteren kaufen für: 1500$";
        tischeAnzeigeHaus3.text = "Tische: " + haus3Tische + " weiteren kaufen für: 2000$";
    }

    public void UIHandler()
    {
        if (DrogenAnkauf.activeSelf || verkaufMenu.activeSelf || haus1Panel.activeSelf || haus2Panel.activeSelf || menu.activeSelf)
        {
            crosshair.SetActive(false);
        }
        else
        {
            crosshair.SetActive(true);
        }

        if (menu.activeSelf && handy.activeSelf)
        {
            menu.SetActive(false);
            handy.SetActive(false);
        }

        if (schulden > 0)
        {
            foreach (GameObject gameobject in darlehenButtons)
            {
                gameobject.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject gameobject in darlehenButtons)
            {
                gameobject.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (DrogenAnkauf.activeSelf)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                player.enabled = true;
                DrogenAnkauf.SetActive(false);
            }
            else if (verkaufMenu.activeSelf)
            {
                StartCoroutine(DelayAndDeactivate());
            }
            else if (haus1Panel.activeSelf || haus2Panel.activeSelf || haus3Panel.activeSelf)
            {
                haus1Panel.SetActive(false);
                haus2Panel.SetActive(false);
                haus3Panel.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                player.enabled = true;
            }
            else if (häuserPanel.activeSelf)
            {
                häuserPanel.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                player.enabled = true;
            }
            else if(haus1AngestellterPanel.activeSelf)
            {
                haus1AngestellterPanel.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                player.enabled = true;
            }
            else if (bankPanel.activeSelf)
            {
                bankPanel.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                player.enabled = true;
            }
            else if (einstellungenPanel.activeSelf)
            {
                einstellungenPanel.SetActive(false);
                menu.SetActive(true);
            }
            else if (steuerungsPanel.activeSelf)
            {
                steuerungsPanel.SetActive(false);
                menu.SetActive(true);
            }
            else if(drohnePanel.activeSelf)
            {
                drohnePanel.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                player.enabled = true;
            }
            else if (haus2AngestellterPanel.activeSelf)
            {
                haus2AngestellterPanel.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                player.enabled = true;
            }
            else if(haus3AngestellterPanel.activeSelf)
            {
                haus3AngestellterPanel.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                player.enabled = true;
            }
            else
            {
                if (menu.activeSelf)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    player.enabled = true;
                    menu.SetActive(false);
                }
                else
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    player.enabled = false;
                    menu.SetActive(true);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!menu.activeSelf)
            {
                if (handy.activeSelf)
                {
                    handy.SetActive(false);
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    player.enabled = true;
                }
                else
                {
                    handy.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    player.enabled = false;
                }
            }
        }
    }

    public void SpielweltHandler()
    {
        if (haus1)
        {
            haus1Schild.SetActive(false);
            haus1Tür.SetActive(true);
        }

        if (haus2)
        {
            haus2Schild.SetActive(false);
            haus2Tür.SetActive(true);
        }

        if (haus3)
        {
            haus3Schild.SetActive(false);
            haus3Tür.SetActive(true);
        }
    }

    public void ÜbergreifendeValueÄnderungenHandler()
    {
        GameObject[] kokainTriggerObjecte = GameObject.FindGameObjectsWithTag("KokainTrigger");

        foreach (GameObject kokainTriggerObject in kokainTriggerObjecte)
        {
            Destroy(kokainTriggerObject);

            kokain += 100;
        }

        GameObject[] tausendObjecte = GameObject.FindGameObjectsWithTag("1K");

        foreach (GameObject tausendObject in tausendObjecte)
        {
            Destroy(tausendObject);

            geld += 1000;
        }

        GameObject[] bündelObjecte = GameObject.FindGameObjectsWithTag("150");

        foreach (GameObject bündelObject in bündelObjecte)
        {
            Destroy(bündelObject);

            geld += 150;
        }

        GameObject[] bubatzTriggerObjecte = GameObject.FindGameObjectsWithTag("BubatzTrigger");

        foreach (GameObject bubatzTriggerObject in bubatzTriggerObjecte)
        {
            Destroy(bubatzTriggerObject);

            bubatz += 20;
        }

        GameObject[] heroinTriggerObjecte = GameObject.FindGameObjectsWithTag("HeroinTrigger");

        foreach (GameObject heroinTriggerObject in heroinTriggerObjecte)
        {
            Destroy(heroinTriggerObject);

            heroin += 10;
        }
    }

    public void SchuldenAutomatischBezahlen()
    {
        if (Time.time > lastTriggerTime + cooldownTime)
        {
            if (schulden > 0)
            {
                if (schulden < (int)(geld * 0.1))
                {
                    geld -= schulden;
                    schulden -= schulden;
                }
                else if (schulden >= (int)(geld * 0.1))
                {
                    schulden -= (int)(geld * 0.1);
                    geld -= (int)(geld * 0.1);
                }
            }

            lastTriggerTime = Time.time;
        }
    }

    public void UpgradePanelUpdate()
    {
        if(haus1Tische == 13)
        {
            tischeHaus1Btn.SetActive(false);
        }

        if(haus1Verpackstation == true)
        {
            verpackstationHaus1Btn.SetActive(false);
        }

        if(haus1Labor == true)
        {
            laborHaus1Btn.SetActive(false);
        }

        if(haus1SchwarzLicht == true)
        {
            schwarzLichtHaus1Btn.SetActive(false);
        }

        if(haus1Drohne == true)
        {
            drohneHaus1Btn.SetActive(false);
        }

        if(haus1Angestellter1 == true)
        {
            angestellter1Haus1Btn.SetActive(false);
        }

        if(haus1Angestellter2 == true)
        {
            angestellter2Haus1Btn.SetActive(false);
        }

        if (haus2Tische == 15)
        {
            tischeHaus2Btn.SetActive(false);
        }

        if (haus2Verpackstation == true)
        {
            verpackstationHaus2Btn.SetActive(false);
        }

        if (haus2Labor == true)
        {
            laborHaus2Btn.SetActive(false);
        }

        if (haus2SchwarzLicht == true)
        {
            schwarzLichtHaus2Btn.SetActive(false);
        }

        if (haus2Drohne == true)
        {
            drohneHaus2Btn.SetActive(false);
        }

        if (haus2Angestellter1 == true)
        {
            angestellter1Haus2Btn.SetActive(false);
        }

        if (haus2Angestellter2 == true)
        {
            angestellter2Haus2Btn.SetActive(false);
        }

        if (haus3Tische == 17)
        {
            tischeHaus3Btn.SetActive(false);
        }

        if (haus3Verpackstation == true)
        {
            verpackstationHaus3Btn.SetActive(false);
        }

        if (haus3Labor == true)
        {
            laborHaus3Btn.SetActive(false);
        }

        if (haus3SchwarzLicht == true)
        {
            schwarzLichtHaus3Btn.SetActive(false);
        }

        if (haus3Drohne == true)
        {
            drohneHaus3Btn.SetActive(false);
        }

        if (haus3Angestellter1 == true)
        {
            angestellter1Haus3Btn.SetActive(false);
        }

        if (haus3Angestellter2 == true)
        {
            angestellter2Haus3Btn.SetActive(false);
        }
    }

    public void OnSliderValueChanged()
    {
        float roundedValue = Mathf.Round(slider.value * 100f) / 100f;
        PlayerPrefs.SetFloat("MouseSens", roundedValue);
        PlayerPrefs.Save();

        sensAnzeige.text = roundedValue.ToString();
    }

    public void BuyKokain()
    {
        if(geld >= 150 && kokain == 0)
        {
            kokain = 100;
            geld -= 150;
        }
    }

    public void BuyBubatz()
    {
        if (geld >= 80 && bubatz == 0)
        {
            bubatz = 10;
            geld -= 80;
        }
    }

    public void BuyHeroin()
    {
        if (geld >= 120 && heroin == 0)
        {
            heroin = 3;
            geld -= 120;
        }
    }

    public void SellKokain()
    {
        if(kokain >= 10)
        {
            kokain -= 10;
            geld += 40;
        }
    }

    public void SellBubatz()
    {
        if(bubatz >= 1)
        {
            bubatz -= 1;
            geld += 20;
        }
    }

    public void SellHeroin()
    {
        if(heroin >= 1)
        {
            heroin -= 1;
            geld += 70;
        }
    }

    public void BuyHaus1()
    {
        if(geld >= 10000 && !haus1)
        {
            haus1 = true;
            geld -= 10000;
        }
    }

    public void BuyHaus2()
    {
        if(geld >= 30000 && !haus2)
        {
            haus2 = true;
            geld -= 30000;
        }
    }

    public void BuyHaus3()
    {
        if(geld >= 50000 && !haus3)
        {
            haus3 = true;
            geld -= 50000;
        }
    }

    public void BuyTisch()
    {
        if(geld >= 1000 && haus1Tische < 13)
        {
            haus1Tische++;
            geld -= 1000;

            for (int i = 0; i < haus1Tische; i++)
            {
                tischeObject[i].SetActive(true);
            }
        }
    }

    public void BuyTischHaus2()
    {
        if (geld >= 1500 && haus2Tische < 15)
        {
            haus2Tische++;
            geld -= 1500;

            for (int i = 0; i < haus2Tische; i++)
            {
                haus2TischeObject[i].SetActive(true);
            }
        }
    }

    public void BuyTischHaus3()
    {
        if (geld >= 2000 && haus3Tische < 17)
        {
            haus3Tische++;
            geld -= 2000;

            for (int i = 0; i < haus3Tische; i++)
            {
                haus3TischeObject[i].SetActive(true);
            }
        }
    }

    public void BuyVerpackstationHaus1()
    {
        if (geld >= 7500 && haus1Verpackstation == false)
        {
            haus1Verpackstation = true;
            geld -= 7500;

            verpackstationHaus1Object.SetActive(true);  
        }
    }

    public void BuyVerpackstationHaus2()
    {
        if (geld >= 10000 && haus2Verpackstation == false)
        {
            haus2Verpackstation = true;
            geld -= 10000;

            verpackstationHaus2Object.SetActive(true);
        }
    }

    public void BuyVerpackstationHaus3()
    {
        if (geld >= 15000 && haus3Verpackstation == false)
        {
            haus3Verpackstation = true;
            geld -= 15000;

            verpackstationHaus3Object.SetActive(true);
        }
    }

    public void BuyAngestellter1Haus1()
    {
        if(geld >= 10000 && haus1Angestellter1 == false)
        {
            haus1Angestellter1 = true;
            geld -= 10000;

            angestellter1Haus1Object.SetActive(true);
        }
    }

    public void BuyAngestellter1Haus2()
    {
        if (geld >= 15000 && haus2Angestellter1 == false)
        {
            haus2Angestellter1 = true;
            geld -= 15000;

            angestellter1Haus2Object.SetActive(true);
        }
    }

    public void BuyAngestellter1Haus3()
    {
        if (geld >= 20000 && haus3Angestellter1 == false)
        {
            haus3Angestellter1 = true;
            geld -= 20000;

            angestellter1Haus3Object.SetActive(true);
        }
    }

    public void BuyAngestellter2Haus1()
    {
        if(geld >= 15000 && haus1Angestellter2 == false)
        {
            haus1Angestellter2 = true;
            geld -= 15000;

            angestellter2Haus1Object.SetActive(true);
        }
    }

    public void BuyAngestellter2Haus2()
    {
        if (geld >= 20000 && haus2Angestellter2 == false)
        {
            haus2Angestellter2 = true;
            geld -= 20000;

            angestellter2Haus2Object.SetActive(true);
        }
    }

    public void BuyAngestellter2Haus3()
    {
        if (geld >= 25000 && haus3Angestellter2 == false)
        {
            haus3Angestellter2 = true;
            geld -= 25000;

            angestellter2Haus3Object.SetActive(true);
        }
    }

    public void BuyLaborHaus1()
    {
        if(geld >= 10000 && haus1Labor == false)
        {
            haus1Labor = true;
            geld -= 10000;

            haus1LaborObject.SetActive(true);
        }
    }

    public void BuyLaborHaus2()
    {
        if (geld >= 15000 && haus2Labor == false)
        {
            haus2Labor = true;
            geld -= 15000;

            haus2LaborObject.SetActive(true);
        }
    }

    public void BuyLaborHaus3()
    {
        if (geld >= 20000 && haus3Labor == false)
        {
            haus3Labor = true;
            geld -= 20000;

            haus3LaborObject.SetActive(true);
        }
    }

    public void BuySchwarzLichtHaus1()
    {
        if(geld >= 15000 && haus1SchwarzLicht == false)
        {
            haus1SchwarzLicht = true;
            geld -= 15000;

            haus1SchwarzLichtObject.SetActive(true);

            GameObject spawnedObject = Instantiate(haus1SchwarzLichtTrigger, spawnPoint.transform);
            spawnedObject.transform.localPosition = Vector3.zero;
        } 
    }

    public void BuySchwarzLichtHaus2()
    {
        if (geld >= 20000 && haus2SchwarzLicht == false)
        {
            haus2SchwarzLicht = true;
            geld -= 20000;

            haus2SchwarzLichtObject.SetActive(true);

            GameObject spawnedObject = Instantiate(haus2SchwarzLichtTrigger, spawnPoint.transform);
            spawnedObject.transform.localPosition = Vector3.zero;
        }
    }

    public void BuySchwarzLichtHaus3()
    {
        if (geld >= 25000 && haus3SchwarzLicht == false)
        {
            haus3SchwarzLicht = true;
            geld -= 25000;

            haus3SchwarzLichtObject.SetActive(true);

            GameObject spawnedObject = Instantiate(haus3SchwarzLichtTrigger, spawnPoint.transform);
            spawnedObject.transform.localPosition = Vector3.zero;
        }
    }

    public void BuyDrohneHaus1()
    {
        if(geld >= 20000 && haus1Drohne == false)
        {
            haus1Drohne = true;
            geld -= 20000;

            drohneHaus1.SetActive(true);
        }
    }

    public void BuyDrohneHaus2()
    {
        if (geld >= 25000 && haus2Drohne == false)
        {
            haus2Drohne = true;
            geld -= 25000;

            drohneHaus2.SetActive(true);
        }
    }

    public void BuyDrohneHaus3()
    {
        if (geld >= 30000 && haus3Drohne == false)
        {
            haus3Drohne = true;
            geld -= 30000;

            drohneHaus3.SetActive(true);
        }
    }

    public void KokainVerkaufenAngestellter()
    {
        int verkauftesKokain = 0;
        bool limit = false;

        while(kokain >= 10 && !limit)
        {
            kokain -= 10;
            geld += 30;

            verkauftesKokain += 10;

            if(verkauftesKokain >= 2500)
            {
                limit = true;
            }
        }

        if (verkauftesKokain > 0)
        {
            splineAnimateVerkäuferHaus1.Restart(true);
            splineAnimateVerkäuferHaus1.Play();
        }
    }

    public void BubatzVerkaufenAngestellter()
    {
        int verkauftesBubatz = 0;
        bool limit = false;

        while (bubatz >= 1 && !limit)
        {
            bubatz -= 1;
            geld += 15;

            verkauftesBubatz += 1;

            if (verkauftesBubatz >= 500)
            {
                limit = true;
            }
        }

        if (verkauftesBubatz > 0)
        {
            splineAnimateVerkäuferHaus2.Restart(true);
            splineAnimateVerkäuferHaus2.Play();
        }
    }

    public void HeroinVerkaufenAngestellter()
    {
        int verkauftesHeroin = 0;
        bool limit = false;

        while (heroin >= 1 && !limit)
        {
            heroin -= 1;
            geld += 60;

            verkauftesHeroin += 1;

            if (verkauftesHeroin >= 250)
            {
                limit = true;
            }
        }

        if (verkauftesHeroin > 0)
        {
            splineAnimateVerkäuferHaus3.Restart(true);
            splineAnimateVerkäuferHaus3.Play();
        }
    }

    public void Darlehen1()
    {
        if(geld >= 3000)
        {
            schulden += (int)(10000 * 1.1);
            geld += 10000;
        }
    }

    public void Darlehen2()
    {
        if(geld >= 10000)
        {
            schulden += (int)(25000 * 1.25);
            geld += 25000;
        }
    }

    public void Darlehen3()
    {
        if(geld >= 50000)
        {
            schulden += (int)(100000 * 1.5);
            geld += 100000;
        }
    }

    public void SchuldenBezahlen()
    {
        string input = schuldenInput.text;

        int schuldenBetrag;
        bool isNumeric = int.TryParse(input, out schuldenBetrag);

        if (isNumeric)
        {
            if(schuldenBetrag <= geld && schuldenBetrag <= schulden)
            {
                geld -= schuldenBetrag;
                schulden -= schuldenBetrag;
            }
        }
    }

    public void Einstellungen()
    {
        einstellungenPanel.SetActive(true);
        menu.SetActive(false);
    }

    public void Steuerung()
    {
        steuerungsPanel.SetActive(true);
        menu.SetActive(false);
    }
}