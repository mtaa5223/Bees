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
    private const int MaxPlayers = 2; // ���� ������ ���� �ִ� �÷��̾� ��
    private bool isGameReady = false; // ���� ���� �غ� ����

    public Button createButton;
    public Button joinButton;
    public TMP_InputField inviteCodeInput;

    private string randomInviteCode; // ���� �ʴ� �ڵ� ���� ����

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

        // ���� �ʴ� �ڵ� ����
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

        // �� ����
        RoomOptions roomOptions = new RoomOptions { MaxPlayers = MaxPlayers };
        PhotonNetwork.CreateRoom(randomInviteCode, roomOptions);
        StartGame();
        Debug.Log("���� ��������ϴ�");
    }

    public void JoinRoomButton()
    {
        createButton.interactable = false;
        joinButton.interactable = false;

        // �ʴ� �ڵ带 ����ڰ� �Է��� �ڵ�� ����
        string inputInviteCode = inviteCodeInput.text.Trim();

        // Ư�� �濡 ����
        PhotonNetwork.JoinRoom(inputInviteCode);
        StartGame();
        Debug.Log("�濡 �����߽��ϴ�");


    }

    public override void OnJoinedRoom()
    {
        Debug.Log("�������� �̵�");
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
        int codeLength = 6; // �ʴ� �ڵ� ����

        StringBuilder codeBuilder = new StringBuilder();
        System.Random random = new System.Random();

        // �����ϰ� �ʴ� �ڵ� ����
        for (int i = 0; i < codeLength; i++)
        {
            int randomIndex = random.Next(0, chars.Length);
            char randomChar = chars[randomIndex];
            codeBuilder.Append(randomChar);
        }

        return codeBuilder.ToString();
    }
}
