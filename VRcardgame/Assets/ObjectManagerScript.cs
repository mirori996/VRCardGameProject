using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ObjectManagerScript : MonoBehaviourPunCallbacks, IPunObservable
{
    private Vector3 myCubePos;

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
            if (gameManagerScript.isVR == false)
            {
                myCubePos = gameManagerScript.cube.transform.position;
                stream.SendNext(myCubePos);
                print("AR上のmyCubePosを送信しました：" + myCubePos);

            } else
            {
                
            }
        }
        else
        {
            if (gameManagerScript.isVR == false)
            {

            }
            else
            {
                myCubePos = (Vector3)stream.ReceiveNext();
                print("VRアプリがAR上のmyCubePosを受信しました：" + myCubePos);
                gameManagerScript.cube.transform.position = myCubePos;
                print("VRアプリがAR上のmyCubePosをgameManagerのcubeのpositionに格納しました：" + gameManagerScript.cube.transform.position);
            }

        }
    }
}
