using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cember : MonoBehaviour
{
    public GameObject _BelongStand; //ait oldugu stand
    public GameObject _CircleSocket; // ait oldugu
    public bool CanMovement;
    public string Colour;
    public GameManager _GameManager;


    GameObject MovementPosition;
    GameObject StandToGo;


    bool Chose, ChangePos, SoketOtur, SoketGeriGit;



    public void HareketEt(string islem, GameObject Stand = null, GameObject Socket = null, GameObject GidilecekObje = null)
    {
        switch (islem)
        {
            case "Secim":
                MovementPosition = GidilecekObje;
                Chose = true;
                break;

            case "PozisyonDegistir":
                StandToGo = Stand;
                _CircleSocket = Socket;
                MovementPosition = GidilecekObje;
                ChangePos = true;
                break;

            case "SoketeGeriGit":

                SoketGeriGit = true;
                break;


        }

    }
    void Update()
    {
        if (Chose)
        {
            transform.position = Vector3.Lerp(transform.position, MovementPosition.transform.position, .2f);
            if (Vector3.Distance(transform.position, MovementPosition.transform.position) < .10)
            {
                Chose = false;
            }

        }

        if (ChangePos)
        {
            transform.position = Vector3.Lerp(transform.position, MovementPosition.transform.position, .2f);
            if (Vector3.Distance(transform.position, MovementPosition.transform.position) < .10)
            {
                ChangePos = false;
                SoketOtur = true;
            }

        }

        if (SoketOtur)
        {
            transform.position = Vector3.Lerp(transform.position, _CircleSocket.transform.position, .2f);
            if (Vector3.Distance(transform.position, _CircleSocket.transform.position) < .10)
            {
                transform.position = _CircleSocket.transform.position;

                SoketOtur = false;
                _BelongStand = StandToGo;

                if (_BelongStand.GetComponent<Stand>()._Cemberler.Count > 1)
                {
                    _BelongStand.GetComponent<Stand>()._Cemberler[^2].GetComponent<Cember>().CanMovement = false;
                }
                _GameManager.HareketVar = false;

            }

        }


        if (SoketGeriGit)
        {
            transform.position = Vector3.Lerp(transform.position, _CircleSocket.transform.position, .2f);
            if (Vector3.Distance(transform.position, _CircleSocket.transform.position) < .10)
            {
                transform.position = _CircleSocket.transform.position;

                SoketGeriGit = false;
                _GameManager.HareketVar = false;

            }

        }





    }

}
