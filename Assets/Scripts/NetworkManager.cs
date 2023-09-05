using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System.Text;
using System.IO;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using TMPro;

public class NetworkManager: MonoBehaviourPunCallbacks
{
    private const int MaxPlayers = 2; // 게임 시작을 위한 최대 플레이어 수
    private bool isGameReady = false; // 게임 시작 준비 여부

    public Button createButton;
    public Button joinButton;
    public TMP_InputField inviteCodeInput;

    private string randomInviteCode; // 랜덤 초대 코드 저장 변수

    public Text TextLegacy;

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        createButton.interactable = false;
        joinButton.interactable = false;
    }

    public override void OnConnectedToMaster()
    {
        createButton.interactable = true;
        joinButton.interactable = true;
    }

    public void CreateRoomButton()
    {
        createButton.interactable = false;
        joinButton.interactable = false;

        // 랜덤 초대 코드 생성
        randomInviteCode = GenerateRandomInviteCode();
        Debug.Log("Random Invite Code: " + randomInviteCode);
        string roomCodePath = "RoomCodeTXT.txt";
        if (File.Exists(roomCodePath) == false)
        {
            using (StreamWriter sw = File.CreateText(roomCodePath))
            {
                sw.Write(randomInviteCode);
            }
        }
        else
        {
            File.WriteAllText(roomCodePath, randomInviteCode);
        }

        // 방 생성
        RoomOptions roomOptions = new RoomOptions { MaxPlayers = MaxPlayers };
        PhotonNetwork.CreateRoom(randomInviteCode, roomOptions);
        StartGame();
        Debug.Log("방을 만들었습니다");
    }

    public void JoinRoomButton()
    {
        createButton.interactable = false;
        joinButton.interactable = false;

        // 초대 코드를 사용자가 입력한 코드로 설정
        string inputInviteCode = inviteCodeInput.text.Trim();

        // 특정 방에 입장
        PhotonNetwork.JoinRoom(inputInviteCode);
        StartGame();
        Debug.Log("방에 입장했습니다");


    }

    public override void OnJoinedRoom()
    {
        Debug.Log("메인으로 이동");
        StartGame();
    }

    private void StartGame()
    {
        if (isGameReady)
        {
            return;
        }

        isGameReady = true;

        PhotonNetwork.LoadLevel("GameLobby");
    }

    private string GenerateRandomInviteCode()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        int codeLength = 6; // 초대 코드 길이

        StringBuilder codeBuilder = new StringBuilder();
        System.Random random = new System.Random();

        // 랜덤하게 초대 코드 생성
        for (int i = 0; i < codeLength; i++)
        {
            int randomIndex = random.Next(0, chars.Length);
            char randomChar = chars[randomIndex];
            codeBuilder.Append(randomChar);
        }

        return codeBuilder.ToString();
    }
}
