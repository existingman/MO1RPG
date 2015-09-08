using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using MO1.Definitions.Dialogues;
using UnityEngine.Events;

using MO1.Definitions;

namespace MO1.GUI
{
    public static class DialogueGUI
    {
        private static Dialogue _dialogue;
        private static Conversation _conversation;
        private static int _juncture;
        private static Quest _quest;

        private static GameObject _canvasObject;

        public static void Initialise()
        {
            
        }

        static void DoAThing()
        {
            Debug.Log("doing something");
            Debug.Log(Time.time);
        }

        public static void initiate(Dialogue d)
        {
            _dialogue = d;
            _conversation = _dialogue.Conversations[d.EntryPoint];
            _juncture = 0;
            Draw();
        }

        public static void Draw()
        {
            _canvasObject = new GameObject("Canvas");
            var canvas = _canvasObject.AddComponent<Canvas>();
            _canvasObject.AddComponent<GraphicRaycaster>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.pixelPerfect = true;

            int x = 0;
            foreach (Reply r in _conversation.Junctures[_juncture].Replies)
            {
                if (r.Enabled)
                {
                    x++;
                    var buttonObject = new GameObject("Button");
                    var image = buttonObject.AddComponent<Image>();
                    image.transform.parent = canvas.transform;
                    image.rectTransform.sizeDelta = new Vector2(Screen.width, 50);
                    image.rectTransform.anchoredPosition = Vector2.zero;
                    image.rectTransform.position = new Vector2(Screen.width / 2f, 50 * x);
                    image.color = new Color(.2f, .2f, .2f, .5f);

                    var textObject = new GameObject("text");
                    textObject.transform.parent = buttonObject.transform;
                    var text = textObject.AddComponent<Text>();
                    text.rectTransform.sizeDelta = Vector2.zero;
                    text.rectTransform.anchorMin = Vector2.zero;
                    text.rectTransform.anchorMax = Vector2.one;
                    text.rectTransform.anchoredPosition = new Vector2(.5f, .5f);
                    text.text = r.Text;
                    text.font = Resources.FindObjectsOfTypeAll<Font>()[0];
                    text.fontSize = 20;
                    text.color = Color.white;
                    text.alignment = TextAnchor.MiddleCenter;

                    var button = buttonObject.AddComponent<Button>();
                    button.targetGraphic = image;

                    //button.onClick.AddListener(new UnityAction(DoAThing));
                    //button.onClick.AddListener(DoAThing);

                    var Ref = r.Ref;
                    switch (r.LinkType)
                    {
                        case ReplyLinkType.Conversation:
                            button.onClick.AddListener(() =>
                            {
                                close();
                                _conversation = _dialogue.Conversations[Ref];
                                _juncture = 0;
                                Draw();
                            });
                            break;
                        case ReplyLinkType.End:
                            button.onClick.AddListener(() =>
                            {
                                close();
                            });
                            break;
                        case ReplyLinkType.Juncture:
                            button.onClick.AddListener(() =>
                            {
                                close();
                                _juncture = Ref;
                                Draw();
                            });
                            break;
                        case ReplyLinkType.Quest:
                            button.onClick.AddListener(() =>
                            {
                                close();
                                _quest = MO1.Content.Data.Quests[Ref];
                                _conversation = _quest.IntialConversation;
                                _juncture = 0;
                                Draw();
                            });
                            break;
                    }

                    if (r.Action != null)
                    {
                        var a = r.Action;
                        button.onClick.AddListener(() =>
                        {
                            a.Do();
                        });
                    }


                    //button.onClick.AddListener(() => Debug.Log(Time.time));
                    //button.onClick.Invoke();

                    //UnityAction myAction;
                    //myAction = () => Debug.Log("Thing");
                    //myAction = DoAThing;
                }
            }

            
            var backingObject = new GameObject("Button");
            var image2 = backingObject.AddComponent<Image>();
            image2.transform.parent = canvas.transform;
            image2.rectTransform.sizeDelta = new Vector2(Screen.width, 200);
            image2.rectTransform.anchoredPosition = Vector2.zero;
            image2.rectTransform.position = new Vector2(Screen.width / 2, Screen.height - 200);
            image2.color = new Color(.2f, .2f, .2f, .5f);

            var textObject2 = new GameObject("Text");
            textObject2.transform.parent = backingObject.transform;
            var text2 = textObject2.AddComponent<Text>();
            text2.rectTransform.sizeDelta = Vector2.zero;
            text2.rectTransform.anchorMin = Vector2.zero;
            text2.rectTransform.anchorMax = Vector2.one;
            text2.rectTransform.anchoredPosition = new Vector2(.5f, .5f);
            text2.text = _conversation.Junctures[_juncture].Speach;
            text2.font = Resources.FindObjectsOfTypeAll<Font>()[0];
            text2.fontSize = 20;
            text2.color = Color.yellow;
            text2.alignment = TextAnchor.MiddleCenter;

        }

        public static void close()
        {
            GameObject.Destroy(_canvasObject);
        }
    }
}
