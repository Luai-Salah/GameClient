using System.Net;
using UnityEngine;

public class ClientHandle : MonoBehaviour
{
    public static void Welcome(Packet _packet)
	{
		string _msg = _packet.ReadString();
		int _myId = _packet.ReadInt();

		Debug.Log($"Massage From The Server: {_msg}");
		Client.instance.myId = _myId;

		ClientSend.WelcomeReceived();

		Client.instance.udp.Connect(((IPEndPoint)Client.instance.tcp.socket.Client.LocalEndPoint).Port);
	}

	public static void SpawnPlayer(Packet _packet)
	{
		int _id = _packet.ReadInt();
		string _userName = _packet.ReadString();
		Vector3 _pos = _packet.ReadVector3();
		Quaternion _rot = _packet.ReadQuaternion();

		GameManager.instance.SpawnPlayer(_id, _userName, _pos, _rot);
	}
}
