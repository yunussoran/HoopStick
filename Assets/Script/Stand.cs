using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Stand : MonoBehaviour
{
    public GameObject MovePosition;
    public GameObject[] Sockets;
    public int EmptySocket;   // Standa yený gelen kacýncý sokete oturacak onu belýrleýyor
    public List<GameObject> _Cemberler = new();
    [SerializeField] private GameManager _GameManager;


    int CircleCompletionsNumber;


    public GameObject GiveTopCircle() //sonuncu elemaný verýyor en bastaký eleman her zaman sonuncu
    {
        return _Cemberler[^1];
    }
    public GameObject GiveAvailableSocket() //sonuncu elemaný verýyor en bastaký eleman her zaman sonuncu
    {
        return Sockets[EmptySocket];
    }

    public void SocketReplacementOperations(GameObject DeletedObject)
    {

        _Cemberler.Remove(DeletedObject);


        if (_Cemberler.Count != 0)
        {
            EmptySocket--;
            _Cemberler[^1].GetComponent<Cember>().CanMovement = true;
        }
        else
        {
            EmptySocket = 0;
        }
    }

    public void ChechkTheCircle()
    {
        if (_Cemberler.Count == 4)
        {
            string Colour = _Cemberler[0].GetComponent<Cember>().Colour;


            foreach (var item in _Cemberler)
            {
                if (Colour == item.GetComponent<Cember>().Colour)
                    CircleCompletionsNumber++;
            }
            if (CircleCompletionsNumber == 4)
            {

                _GameManager.StandCompleted();
                CompletedStandTransactions();            }
            else
            {
                CircleCompletionsNumber = 0;
              

            }

        }
    }
    void CompletedStandTransactions()
    {
        foreach (var item in _Cemberler)
        {
            item.GetComponent<Cember>().CanMovement = false;
            Color32 color = item.GetComponent<MeshRenderer>().material.GetColor("_Color");
            color.a = 150;
            item.GetComponent<MeshRenderer>().material.SetColor("_Color", color);
            gameObject.tag="TamamlanmýsStand";
        }
    }






}
