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

    public GameObject h8;
    public GameObject d9;
    public GameObject joker;

    public Vector3 h8Position;
    public Vector3 d9Position;
    public Vector3 jokerPosition;

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
        print("この受信したh8Positionを合成する" + h8Position);
        print("この受信したd9Positionを合成する" + d9Position);
        print("この受信したjokerPositionを合成する" + jokerPosition);

        this.h8.transform.position = this.originCube.transform.position + (h8Position * -1);
        this.d9.transform.position = this.originCube.transform.position + (d9Position * -1);
        this.joker.transform.position = this.originCube.transform.position + (jokerPosition * -1);
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
