using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.IO;

public class ElevenLabsTTS : MonoBehaviour
{
    private string apiKey = "sk_0005f20f652143c33d035a852157c8d217af0bf77b46fa32"; // �߱޹��� API Ű
    private string apiUrl = "https://api.elevenlabs.io/v1/text-to-speech/XFukrH2WmHuDAfPG2W8N";

    public AudioSource audioSource;

    public void GenerateVoice(string text, string voiceId = "XFukrH2WmHuDAfPG2W8N")
    {
        StartCoroutine(SendTTSRequest(text, voiceId));
    }

    private IEnumerator SendTTSRequest(string text, string voiceId)
    {
        // ��û ������ ����
        var postData = new
        {
            text = text,
            voice_id = voiceId,
            model_id = "eleven_multilingual_v2"
        };

        string jsonData = JsonConvert.SerializeObject(postData);
        byte[] jsonBytes = System.Text.Encoding.UTF8.GetBytes(jsonData);

        using (UnityWebRequest request = new UnityWebRequest(apiUrl, "POST"))
        {
            request.uploadHandler = new UploadHandlerRaw(jsonBytes);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("xi-api-key", apiKey);

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("TTS Response received.");
                byte[] audioData = request.downloadHandler.data;

                // ���� �����͸� AudioClip���� ��ȯ�Ͽ� ���
                PlayAudio(audioData);
            }
            else
            {
                Debug.LogError("Error: " + request.error);
                Debug.LogError($"Response Text: {request.downloadHandler.text}");
            }
        }
    }

    private void PlayAudio(byte[] audioData)
    {
        string tempMp3Path = Path.Combine(Application.persistentDataPath, "temp.mp3");
        File.WriteAllBytes(tempMp3Path, audioData);

        // MP3 ���� �ε� �� ���
        WWW www = new WWW("file://" + tempMp3Path);
        while (!www.isDone) { } // ���� �ε� �Ϸ� ���

        AudioClip audioClip = www.GetAudioClip();
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();

        // �ӽ� ���� ����
        File.Delete(tempMp3Path);
    }
}