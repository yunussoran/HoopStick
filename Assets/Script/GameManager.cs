using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject SeciliObje; // sectýgýmýz cemberý burda tutacaðýz
    GameObject SeciliStand;
    Cember _Cember;
    public bool HareketVar;

    public int NumberTargetStand;
    int NumberStandCompleted;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100))
            {
                if (hit.collider != null && hit.collider.CompareTag("Stand"))
                {
                    if (SeciliObje != null && SeciliStand != hit.collider.gameObject)
                    {// býr cemberý gonderme

                        Stand _Stand = hit.collider.GetComponent<Stand>();

                        if (_Stand._Cemberler.Count != 4 && _Stand._Cemberler.Count != 0)  
                        {
                            if (_Cember.Colour == _Stand._Cemberler[^1].GetComponent<Cember>().Colour)
                            {
                                SeciliStand.GetComponent<Stand>().SocketReplacementOperations(SeciliObje);
                                _Cember.HareketEt("PozisyonDegistir", hit.collider.gameObject, _Stand.GiveAvailableSocket(), _Stand.MovePosition);
                                _Stand.EmptySocket++;
                                _Stand._Cemberler.Add(SeciliObje);
                                _Stand.ChechkTheCircle();
                                SeciliObje = null;
                                SeciliStand = null;
                            }
                            else
                            {
                                _Cember.HareketEt("SoketeGeriGit");
                                SeciliObje = null;
                                SeciliStand = null;
                            }
                           

                        }
                        else if (_Stand._Cemberler.Count==0 ) // bos standa soket gonderme  
                        {
                            SeciliStand.GetComponent<Stand>().SocketReplacementOperations(SeciliObje);
                            _Cember.HareketEt("PozisyonDegistir", hit.collider.gameObject, _Stand.GiveAvailableSocket(), _Stand.MovePosition);
                            _Stand.EmptySocket++;
                            _Stand._Cemberler.Add(SeciliObje);
                            _Stand.ChechkTheCircle();

                            SeciliObje = null;
                            SeciliStand = null;
                        }
                        
                        
                        else  // cemberý sokete gerý gonderme 
                        {
                            _Cember.HareketEt("SoketeGeriGit");
                            SeciliObje = null;
                            SeciliStand = null;
                        }

                    }
                    else if (SeciliStand == hit.collider.gameObject)
                    {
                        _Cember.HareketEt("SoketeGeriGit");
                        SeciliObje = null;
                        SeciliStand = null;
                    }
                    else
                    {
                        Stand _Stand = hit.collider.GetComponent<Stand>();
                        SeciliObje = _Stand.GiveTopCircle();
                        _Cember = SeciliObje.GetComponent<Cember>();
                        HareketVar = true;

                        if (_Cember.CanMovement)
                        {
                            _Cember.HareketEt("Secim", null, null, _Cember._BelongStand.GetComponent<Stand>().MovePosition);
                            SeciliStand = _Cember._BelongStand;
                        }


                    }

                }



            }







        }





    }

    public void StandCompleted()
    {
        NumberStandCompleted++;
        if (NumberStandCompleted == NumberTargetStand)
            Debug.Log("KAZANDIN"); // KAZANDIN PANELI CIKACAK

    }


}
