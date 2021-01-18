using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManagerScript : MonoBehaviourPunCallbacks
{
    public bool isVR = true;

    //public GameObject field;
    //private ObjectManagerScript vrObjectManagerScript;

    public GameObject originCube;
    public GameObject h8perCube;
    public Vector3 h8perPosition;

    //public int player;

    // Start is called before the first frame update

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        //vrObjectManagerScript = GameObject.FindWithTag("VRObjectManager").GetComponent<ObjectManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Game：" + PhotonNetwork.CountOfPlayers);
        //vrObjectManagerScript.myCubePos = new Vector3(1.0f, 1.0f, 1.0f);
        print("この受信したh8perPositionを合成する" + h8perPosition);
        this.h8perCube.transform.position = this.originCube.transform.position + (h8perPosition * -1);
    }


    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions(), TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        // マッチング後、自分自身のネットワークオブジェクトを生成する
        var v = new Vector3(0, 0, 0);
        PhotonNetwork.Instantiate("ObjectManagerPrefab", v, Quaternion.identity);
    }
}
