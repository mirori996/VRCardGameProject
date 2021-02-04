using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ObjectManagerScript : MonoBehaviourPunCallbacks, IPunObservable
{
    private Vector3 h8Pos;
    private Vector3 d9Pos;
    private Vector3 jokerPos;

    private Vector3 pokekaPos;
    private Vector3 myumyuPos;
    private Vector3 mystelytragerPos;
    private Vector3 maikaPos;
    private Vector3 karamaneroPos;
    private Vector3 dedenePos;

    private GameManagerScript gameManagerScript;
    //
    public bool isvr;

    private void Awake()
    {
        gameManagerScript = GameObject.FindWithTag("GameManager").GetComponent<GameManagerScript>();
        isvr = gameManagerScript.isVR;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Object：" + PhotonNetwork.CountOfPlayers);
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            if (gameManagerScript.isVR)
            {

            }
            else
            {
                h8Pos = gameManagerScript.h8Position;
                stream.SendNext(h8Pos);
                print("AR上のh8Posを送信しました：" + h8Pos);

                d9Pos = gameManagerScript.d9Position;
                stream.SendNext(d9Pos);
                print("AR上のd9Posを送信しました：" + d9Pos);

                jokerPos = gameManagerScript.jokerPosition;
                stream.SendNext(jokerPos);
                print("AR上のjokerPosを送信しました：" + jokerPos);

                //pokeka
                pokekaPos = gameManagerScript.pokekaPosition;
                stream.SendNext(pokekaPos);

                myumyuPos = gameManagerScript.myumyuPosition;
                stream.SendNext(myumyuPos);

                mystelytragerPos = gameManagerScript.mystelytragerPosition;
                stream.SendNext(mystelytragerPos);

                maikaPos = gameManagerScript.maikaPosition;
                stream.SendNext(maikaPos);

                karamaneroPos = gameManagerScript.karamaneroPosition;
                stream.SendNext(karamaneroPos);

                dedenePos = gameManagerScript.dedenePosition;
                stream.SendNext(dedenePos);
            }
        }
        else
        {
            if (gameManagerScript.isVR)
            {
                h8Pos = (Vector3)stream.ReceiveNext();
                print("VRアプリがAR上のh8Posを受信しました：" + h8Pos);
                gameManagerScript.h8Position = h8Pos;
                print("VRアプリがAR上のh8PosをgameManagerのh8Positionに格納しました：" + gameManagerScript.h8Position);

                d9Pos = (Vector3)stream.ReceiveNext();
                print("VRアプリがAR上のd9Posを受信しました：" + d9Pos);
                gameManagerScript.d9Position = d9Pos;
                print("VRアプリがAR上のd9PosをgameManagerのd9Positionに格納しました：" + gameManagerScript.d9Position);

                jokerPos = (Vector3)stream.ReceiveNext();
                print("VRアプリがAR上のjokerPosを受信しました：" + jokerPos);
                gameManagerScript.jokerPosition = jokerPos;
                print("VRアプリがAR上のjokerPosをgameManagerのjokerPositionに格納しました：" + gameManagerScript.jokerPosition);

                //pokeka
                pokekaPos = (Vector3)stream.ReceiveNext();
                gameManagerScript.pokekaPosition = pokekaPos;

                myumyuPos = (Vector3)stream.ReceiveNext();
                gameManagerScript.myumyuPosition = myumyuPos;

                mystelytragerPos = (Vector3)stream.ReceiveNext();
                gameManagerScript.mystelytragerPosition = mystelytragerPos;

                maikaPos = (Vector3)stream.ReceiveNext();
                gameManagerScript.maikaPosition = maikaPos;

                karamaneroPos = (Vector3)stream.ReceiveNext();
                gameManagerScript.karamaneroPosition = karamaneroPos;

                dedenePos = (Vector3)stream.ReceiveNext();
                gameManagerScript.dedenePosition = dedenePos;

            }
            else
            {
                
            }

        }
    }
}
