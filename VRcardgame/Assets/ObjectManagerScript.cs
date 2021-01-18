using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ObjectManagerScript : MonoBehaviourPunCallbacks, IPunObservable
{
    public Vector3 cubePos;

    private GameManagerScript gameManagerScript;

    private void Awake()
    {
        gameManagerScript = GameObject.FindWithTag("GameManager").GetComponent<GameManagerScript>();

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
                cubePos = gameManagerScript.h8perPosition;
                stream.SendNext(cubePos);
                print("AR上のcubePosを送信しました：" + cubePos);
            }
        }
        else
        {
            if (gameManagerScript.isVR)
            {
                cubePos = (Vector3)stream.ReceiveNext();
                print("VRアプリがAR上のcubePosを受信しました：" + cubePos);
                gameManagerScript.h8perPosition = cubePos;
                print("VRアプリがAR上のcubePosをgameManagerのh8perCubeのpositionに格納しました：" + gameManagerScript.h8perPosition);
            }
            else
            {
                
            }

        }
    }
}
