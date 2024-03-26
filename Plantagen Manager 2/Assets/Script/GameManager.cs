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

    [SerializeField] private int tische;
    [SerializeField] private bool haus1Verpackstation;
    [SerializeField] private bool haus1Angestellter1;
    [SerializeField] private bool haus1Angestellter2;
    [SerializeField] private bool haus1Labor;

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

    [Space(5)]
    [Header("Haus2")]
    [Space(5)]

    [SerializeField] private GameObject haus2Schild;
    [SerializeField] private GameObject haus2Tür;
    [SerializeField] private GameObject haus2Panel;

    [Space(5)]
    [Header("Haus3")]
    [Space(5)]

    [SerializeField] private GameObject haus3Schild;
    [SerializeField] private GameObject haus3Tür;
    [SerializeField] private GameObject haus3Panel;

    [Space(5)]
    [Header("Anzeigen")]
    [Space(5)]

    [SerializeField] private TMP_Text geldanzeige;
    [SerializeField] private TMP_Text kokainanzeige;
    [SerializeField] private TMP_Text bubatzanzeige;
    [SerializeField] private TMP_Text heroinanzeige;
    [SerializeField] private TMP_Text tischAnzeige;
    [SerializeField] private TMP_Text schuldenAnzeige;

    [Space(5)]
    [Header("Inputfelder")]
    [Space(5)]

    [SerializeField] private TMP_InputField schuldenInput;

    [Space(5)]
    [Header("Spline Animate")]
    [Space(5)]

    [SerializeField] private SplineAnimate splineAnimateVerkäuferHaus1;

    [Space(5)]
    [Header("Cooldowns")]
    [Space(5)]

    [SerializeField] private float cooldownTime;
    private float lastTriggerTime;

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

        data.tische = tische;
        data.haus1Verpackstation = haus1Verpackstation;
        data.haus1Angestellter1 = haus1Angestellter1;
        data.haus1Angestellter2 = haus1Angestellter2;
        data.haus1Labor = haus1Labor;

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

        tische = data.tische;
        haus1Verpackstation = data.haus1Verpackstation;
        haus1Angestellter1 = data.haus1Angestellter1;
        haus1Angestellter2 = data.haus1Angestellter2;
        haus1Labor = data.haus1Labor;

        Aktualisieren();
    }

    public void Update()
    {
        AnzeigeUpdate();

        UIHandler();

        SpielweltHandler();

        ÜbergreifendeValueÄnderungenHandler();

        SchuldenAutomatischBezahlen();
    }

    IEnumerator DelayAndDeactivate()
    {
        yield return new WaitForSeconds(0.1f);

        verkaufMenu.SetActive(false);
        
    }

    public void Aktualisieren()
    {
        for (int i = 0; i < tische; i++)
        {
            tischeObject[i].SetActive(true);
        }

        tischAnzeige.text = "Tische: " + tische + " weiteren kaufen für: 1000$";

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
    }

    public void AnzeigeUpdate()
    {
        geldanzeige.text = geld.ToString() + "$";

        schuldenAnzeige.text = schulden.ToString() + "$";

        kokainanzeige.text = "Kokain: " + kokain.ToString() + "g";
        bubatzanzeige.text = "Bubatz: " + bubatz.ToString() + "stk";
        heroinanzeige.text = "Heroin: " + heroin.ToString() + "stk";
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
        if(geld >= 15000 && !haus1)
        {
            haus1 = true;
            geld -= 15000;
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
        if(geld >= 1000 && tische < 13)
        {
            tische++;
            geld -= 1000;

            for (int i = 0; i < tische; i++)
            {
                tischeObject[i].SetActive(true);
            }
        }

        tischAnzeige.text = "Tische: " + tische + " weiteren kaufen für: 1000$";
    }

    public void BuyVerpackstationHaus1()
    {
        if (geld >= 10000 && haus1Verpackstation == false)
        {
            haus1Verpackstation = true;
            geld -= 10000;

            verpackstationHaus1Object.SetActive(true);  
        }
    }

    public void BuyAngestellter1Haus1()
    {
        if(geld >= 15000 && haus1Angestellter1 == false)
        {
            haus1Angestellter1 = true;
            geld -= 15000;

            angestellter1Haus1Object.SetActive(true);
        }
    }

    public void BuyAngestellter2Haus1()
    {
        if(geld >= 25000 && haus1Angestellter2 == false)
        {
            haus1Angestellter2 = true;
            geld -= 25000;

            angestellter2Haus1Object.SetActive(true);
        }
    }

    public void BuyLaborHaus1()
    {
        if(geld >= 20000 && haus1Labor == false)
        {
            haus1Labor = true;
            geld -= 20000;

            haus1LaborObject.SetActive(true);
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
}