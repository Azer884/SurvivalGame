using System.Collections;
using UnityEngine;
using Unity.Netcode;
using TMPro;
using UnityEngine.EventSystems;

public class ChatManager : NetworkBehaviour
{
    public static ChatManager Singleton;

    [SerializeField] ChatMessage chatMessagePrefab;
    [SerializeField] CanvasGroup chatContent;
    [SerializeField] TMP_InputField chatInput;

    public string playerName;
    public Movement movement;
    [SerializeField] float fadeDuration = 5f;
    public CanvasGroup Canvas;

    void Awake()
    {
        ChatManager.Singleton = this;
        playerName = EditPlayerName.Instance.playerName;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(FadeInChat());
            if (EventSystem.current.currentSelectedGameObject == chatInput.gameObject)
            {
                // Send the message and clear the input field
                movement.enabled = true;
                SendChatMessage(chatInput.text, playerName);
                chatInput.text = "";    

            }
            else
            {
                // Focus on the chat input field
                movement.enabled = false;
                chatInput.Select();
                chatInput.ActivateInputField();

            }
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            StartCoroutine(FadeOutChat());
        }
    }

    public void SendChatMessage(string _message, string _fromWho = null)
    {
        if (string.IsNullOrWhiteSpace(_message)) return;

        string S = _fromWho + " > " + _message;
        SendChatMessageServerRpc(S);
    }

    void AddMessage(string msg)
    {
        ChatMessage CM = Instantiate(chatMessagePrefab, chatContent.transform);
        CM.SetText(msg);
    }

    [ServerRpc(RequireOwnership = false)]
    void SendChatMessageServerRpc(string message)
    {
        ReceiveChatMessageClientRpc(message);
    }

    [ClientRpc]
    void ReceiveChatMessageClientRpc(string message)
    {
        ChatManager.Singleton.AddMessage(message);
    }

    // Coroutine to smoothly fade in the chat
    IEnumerator FadeInChat()
    {
        float elapsedTime = 0f;
        while (Canvas.alpha < 1f)
        {
            elapsedTime += Time.deltaTime;
            Canvas.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            yield return null;
        }
    }

    // Coroutine to smoothly fade out the chat
    IEnumerator FadeOutChat()
    {
        float elapsedTime = 0f;
        while (Canvas.alpha > 0f)
        {
            elapsedTime += Time.deltaTime;
            Canvas.alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            yield return null;
        }
    }
}
