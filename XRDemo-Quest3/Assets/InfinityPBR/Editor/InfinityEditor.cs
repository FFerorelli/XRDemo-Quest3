using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace InfinityPBR
{
    public abstract class InfinityEditor : Editor
    {
        public static Texture2D UnityTexture(string textureName) => EditorGUIUtility.FindTexture(textureName);

        public const string symbolInfo = "ⓘ";
        public const string symbolX = "✘";
        public const string symbolCheck = "✔";
        public const string symbolCheckSquare = "☑";
        public const string symbolDollar = "$";
        public const string symbolCent = "¢";
        public const string symbolCarrotRight = "‣";
        public const string symbolCarrotLeft = "◄";
        public const string symbolCarrotUp = "▲";
        public const string symbolCarrotDown = "▼";
        public const string symbolDash = "⁃";
        public const string symbolBulletClosed = "⦿";
        public const string symbolBulletOpen = "⦾";
        public const string symbolHeartClosed = "♥";
        public const string symbolHeartOpen = "♡";
        public const string symbolStarClosed = "★";
        public const string symbolStarOpen = "☆";
        public const string symbolArrowUp = "↑";
        public const string symbolArrowDown = "↓";
        public const string symbolRandom = "↬";
        public const string symbolMusic = "♫";
        public const string symbolImportant = "‼";
        public const string symbolCircleArrow = "➲";
        public const string symbolOneCircleOpen = "➀";
        public const string symbolPneCircleClosed = "➊";
        public const string symbolTwoCircleOpen = "➁";
        public const string symbolTwoCircleClosed = "➋";
        public const string symbolThreeCircleOpen = "➂";
        public const string symbolThreeCircleClosed = "➌";
        public const string symbolFourCircleOpen = "➃";
        public const string symbolFourCircleClosed = "➍";
        public const string symbolFiveCircleOpen = "➄";
        public const string symbolFiveCircleClosed = "➎";
        public const string symbolSixCircleOpen = "➅";
        public const string symbolSixCircleClosed = "➏";
        public const string symbolSevenCircleOpen = "➆";
        public const string symbolSevenCircleClosed = "➐";
        public const string symbolEightCircleOpen = "➇";
        public const string symbolEightCircleClosed = "➑";
        public const string symbolNineCircleOpen = "➈";
        public const string symbolNineCircleClosed = "➒";
        public const string symbolArrowCircleRight = "↺";
        public const string symbolArrowCircleLeft = "↻";
        public const string symbolPlusCircle = "⊕";
        public const string symbolMinusCircle = "⊖";
        public const string symbolMultiplyCircle = "⊗";
        public const string symbolDivideCircle = "⊘";
        public const string symbolEqualCircle = "⊜";
        public const string symbolRecycle = "♻";
        public const string symbolWww = "🌎";
        public const string symbolCircleOpen = "○";
        
        public static Color inactive = new Color(0.75f, .75f, 0.75f, 1f);
        public static Color active = new Color(0.6f, 1f, 0.6f, 1f);
        public static Color active2 = new Color(0.0f, 1f, 0.0f, 1f);
        public static Color dark = new Color(0.25f, 0.25f, 0.25f, 1f);
        public static Color mixed = Color.yellow;
        public static Color red = new Color(1f, 0.25f, 0.25f, 1f);
        public static Color blue = new Color(0.25f, 0.25f, 1f, 1f);

        public static string textMuted = "<color=#777777>";
        public static string textFaded = "<color=#555555>";
        public static string textWarning = "<color=#ffd955>";
        public static string textNormal = "<color=#999999>";
        public static string textHightlight = "<color=#99ffff>";
        public static string textError = "<color=#ff5555>";
        public static string textColorEnd = "</color>";
        
        /*
        * ----------------------------------------------------------------------------------------------
        * BUTTONS, LABELS, ETC
        * ----------------------------------------------------------------------------------------------
        */
        
        // Horizontal Gap
        public static void Gap(int width = 20)
        {
            Label("", width);
        }
        
        
        // Buttons Group Code
        // Open / Close button
        public static bool ButtonOpenClose(string key, bool value = false, bool grabValueFromKey = true)
        {
            if (grabValueFromKey)
                value = GetBool(key);
            ColorsIf(value, Color.green, Color.black, Color.white, Color.grey);
            SetBool(key, ButtonToggleEye(value, 25));
            ResetColor();
            return GetBool(key);
        }

        public static bool ButtonOpenClose(bool value)
        {
            ColorsIf(value, Color.green, Color.black, Color.white, Color.grey);
            var newValue = ButtonToggleEye(value, 25);
            ResetColor();
            return newValue;
        }
        
        public static bool ButtonToggleEye(bool value, int width)
        {
            if (GUILayout.Button(EditorGUIUtility.IconContent("d_ViewToolOrbit On"), GUILayout.Width(width)))
                return !value;
            return value;
        }

        // Buttons
        public static bool ButtonToggle(bool value, string label, int width, bool useColors = false)
        {
            if (useColors)
                ColorsIf(value, Color.green, Color.black, Color.white, Color.grey);
            if (GUILayout.Button(label, GUILayout.Width(width)))
            {
                ResetColor();
                return !value;
            }
            ResetColor();
            return value;
        }
        
        public static bool ButtonToggle(bool value, string label, int width, int height, bool useColors = false)
        {
            if (useColors)
                ColorsIf(value, Color.green, Color.black, Color.white, Color.grey);
            if (GUILayout.Button(label, GUILayout.Width(width), GUILayout.Height(height)))
            {
                ResetColor();
                return !value;
            }
            ResetColor();
            return value;
        }
        
        public static bool ButtonToggle(bool value, string label, string tooltip, int width, bool useColors = false)
        {
            if (useColors)
                ColorsIf(value, Color.green, Color.black, Color.white, Color.grey);
            if (GUILayout.Button(new GUIContent(label, tooltip), GUILayout.Width(width)))
            {
                ResetColor();
                return !value;
            }
            ResetColor();
            return value;
        }
        
        public static bool ButtonToggle(bool value, string label, string tooltip, int width, int height, bool useColors = false)
        {
            if (useColors)
                ColorsIf(value, Color.green, Color.black, Color.white, Color.grey);
            if (GUILayout.Button(new GUIContent(label, tooltip), GUILayout.Width(width), GUILayout.Height(height)))
            {
                ResetColor();
                return !value;
            }
            ResetColor();
            return value;
        }
        
        public static bool Button(string label, string tooltip, int width, int height)
        {
            if (GUILayout.Button(new GUIContent(label, tooltip), GUILayout.Width(width), GUILayout.Height(height)))
                return true;
            return false;
        }
        
        public static bool Button(string label, string tooltip, int width)
        {
            if (GUILayout.Button(new GUIContent(label, tooltip), GUILayout.Width(width)))
                return true;
            return false;
        }
        
        public static bool Button(string label, string tooltip)
        {
            if (GUILayout.Button(new GUIContent(label, tooltip)))
                return true;
            return false;
        }
        
        public static bool Button(string label, int width, int height)
        {
            if (GUILayout.Button(label, GUILayout.Width(width), GUILayout.Height(height)))
                return true;
            return false;
        }

        public static bool Button(string label, int width)
        {
            if (GUILayout.Button(label, GUILayout.Width(width)))
                return true;
            return false;
        }
        
        public static bool ButtonWordWrap(string label, int width, int height, bool richText = false)
        {
            var buttonStyle = new GUIStyle(GUI.skin.button)
            {
                wordWrap = true,
                fixedWidth = width,
                fixedHeight = height,
                richText = richText
            };

            return GUILayout.Button(label, buttonStyle);
        }

        public static bool ButtonBig(string label, int width, int height = 24, int fontSize = 18, bool bold = false)
        {
            var style = new GUIStyle(EditorStyles.miniButton)
            {
                fontSize = fontSize, 
                fixedHeight = height, 
                fixedWidth = width,
                fontStyle = bold ? FontStyle.Bold : FontStyle.Normal
            };
            
            return GUILayout.Button(label, style);
        }

        public static bool Button(string label)
        {
            if (GUILayout.Button(label))
                return true;
            return false;
        }
        
        public static bool OnOffButton(bool isOn, bool colors = true)
        {
            if (colors)
                BackgroundColor(isOn ? Color.green : Color.grey);

            if (GUILayout.Button(EditorGUIUtility.IconContent("d_ViewToolOrbit On"), GUILayout.Width(25)))
            {
                ResetColor();
                return !isOn;
            }
            
            ResetColor();
            return isOn;
        }
        
        public static bool EnabledButton(bool isOn, bool colors = true, int width = 25)
        {
            if (colors)
                BackgroundColor(isOn ? Color.green : Color.grey);

            if (GUILayout.Button(isOn ? symbolCheck : symbolDash, GUILayout.Width(width)))
            {
                ResetColor();
                return !isOn;
            }
            
            ResetColor();
            return isOn;
        }

        public static bool XButton()
        {
            BackgroundColor(Color.red);
        
            if (Button($"{symbolX}", 25))
            {
                ResetColor();
                return true;
            }
            
            ResetColor();
            return false;
        }

        public static void PingButton(Object moduleObject)
        {
            if (Button($"{symbolCircleArrow}", 25))
                PingObject(moduleObject);
        }

        public static void PingObject(Object obj) => EditorGUIUtility.PingObject(obj);

        public static void PingObject<T>(string guid) 
            where T : UnityEngine.Object
            => PingObject(AssetDatabase.LoadAssetAtPath<T>( AssetDatabase.GUIDToAssetPath(guid) ));

        public static bool PingObject<T>(string[] guids, int index = 0)
            where T : UnityEngine.Object
        {
            if (guids.Length == 0)
            {
                Debug.LogWarning("No guids to ping. Returning false.");
                return false;
            }
            if (index >= guids.Length)
            {
                Debug.LogWarning("Index out of range, resetting to 0.");
                index = 0;
            }
            
            PingObject<T>(guids[index]);
            return true;
        }
        
        /*
        public static Object GetObject(string objectName, int index = 0) 
            => AssetDatabase.LoadAssetAtPath<MonoScript>( AssetDatabase.FindAssets(objectName)[index] );

        public static bool PingObjectNamed(string name, int index = 0) 
            => PingObject(AssetDatabase.FindAssets(name), index);
            */
        
        public static Object GetObjectInProject<T>(string objectName, int index = 0) 
            where T : UnityEngine.Object
            => AssetDatabase.LoadAssetAtPath<T>( AssetDatabase.GUIDToAssetPath(AssetDatabase.FindAssets(objectName)[index]) );

        public static bool PingObjectNamed<T>(string name, int index = 0) 
            where T : UnityEngine.Object
            => PingObject<T>(AssetDatabase.FindAssets(name), index);


        public static void ImportantField(string toolTip = "Required", int fontSize = 18, int width = 20)
        {
            ContentColor(Color.yellow);
            LabelBig($"{symbolCircleArrow}", toolTip, 20, fontSize);
            ResetColor();
        }
        
        public static void ImportantFieldIf(bool value, string toolTip = "Required", int fontSize = 18, int width = 20)
        {
            if (!value) return;

            ImportantField(toolTip, fontSize, width);
        }

        // Convenience method for the main, larger, menu toolbar, which also uses an EditorPrefs to handle the selected
        // option
        public static int ToolbarMenuMain(string[] options, string editorPrefString)
        {
            var selected = EditorPrefs.GetInt(editorPrefString, 0);
            selected = ToolbarMenuMain(options, selected);
            EditorPrefs.SetInt(editorPrefString, selected);
            return selected;
        }

        // Convenience method for the main, larger, menu toolbar
        public static int ToolbarMenuMain(string[] options, int selected) =>
            ToolbarMenu(options, selected, 14, true);
        
        public static int ToolbarMenuMainTall(string[] options, int selected, int height = 50, int fontSize = 14) =>
            ToolbarMenu(options, selected, fontSize, true, -1, height);
        
        public static int ToolbarMenuMainTall(string[] options, string[] tooltips, int selected, int height = 50, int fontSize = 14) =>
            ToolbarMenu(options, selected, fontSize, true, -1, height, tooltips);
        
        public static int ToolbarMenuMain(string[] options, int selected, int height) =>
            ToolbarMenu(options, selected, 14, true);
        
        // Used for toolbars that select menu panels in the editor scripts
        public static int ToolbarMenu(string[] options, int selected, int fontSize = 12, bool bold = false, int width = -1, int height = -1, string[] tooltips = null)
        {
            var buttonWidth = width / options.Length;
            var usingTooltips = false;
            if (tooltips != null)
            {
                usingTooltips = tooltips.Length == options.Length;
            }
    
            // Create styles
            var styleBold = new GUIStyle(GUI.skin.button) { fontSize = fontSize, fontStyle = FontStyle.Bold };
            var styleRegular = new GUIStyle(GUI.skin.button) { fontSize = fontSize, fontStyle = FontStyle.Normal };
            
            // Draw the tool bar
            StartRow();
            for (var i = 0; i < options.Length; i++)
            {
                var isPressed = (selected == i);
                var style = bold ? styleBold : styleRegular;
                var lines = options[i].Split('\n');

                // Draw button
                if (width > 0 && height > 20)
                {
                    if (usingTooltips && GUILayout.Toggle(isPressed, new GUIContent(options[i], tooltips[i]), style, GUILayout.Width(buttonWidth), GUILayout.Height(height)) && !isPressed)
                        selected = i; // Set the selected option when a button is pressed
                    else if (!usingTooltips && GUILayout.Toggle(isPressed, options[i], style, GUILayout.Width(buttonWidth), GUILayout.Height(height)) && !isPressed)
                        selected = i; // Set the selected option when a button is pressed
                }
                else if (width > 0 && height <= 20)
                {
                    if (usingTooltips && GUILayout.Toggle(isPressed, new GUIContent(options[i], tooltips[i]), style, GUILayout.Width(buttonWidth)) && !isPressed)
                        selected = i; // Set the selected option when a button is pressed
                    else if (!usingTooltips && GUILayout.Toggle(isPressed, options[i], style, GUILayout.Width(buttonWidth)) && !isPressed)
                        selected = i; // Set the selected option when a button is pressed
                }
                else if (width < 0 && height > 20)
                {
                    if (usingTooltips && GUILayout.Toggle(isPressed, new GUIContent(options[i], tooltips[i]), style, GUILayout.Height(height)) && !isPressed)
                        selected = i; // Set the selected option when a button is pressed
                    else if (!usingTooltips && GUILayout.Toggle(isPressed, options[i], style, GUILayout.Height(height)) && !isPressed)
                        selected = i; // Set the selected option when a button is pressed
                }
                else
                {
                    if (usingTooltips && GUILayout.Toggle(isPressed, new GUIContent(options[i], tooltips[i]), style) && !isPressed)
                        selected = i; // Set the selected option when a button is pressed
                    else if (!usingTooltips && GUILayout.Toggle(isPressed, options[i], style) && !isPressed)
                        selected = i; // Set the selected option when a button is pressed
                }

            }
            EndRow();
            
            return selected;
        }

        
        // Used for toolbars that select options for a value
        public static int ToolbarOptions(string[] options, int selected, bool offColorBlack = true, int fontSize = 12, bool bold = false, int width = -1)
        {
            // Cache original colors
            var originalBackgroundColor = GUI.backgroundColor;
            var originalContentColor = GUI.contentColor;
            
            var buttonWidth = width / options.Length;
            
            // Draw the tool bar
            StartRow();
            for (var i = 0; i < options.Length; i++)
            {
                // Create style
                var style = new GUIStyle(GUI.skin.button);
                style.fontSize = fontSize;
                if (bold)
                    style.fontStyle = FontStyle.Bold;

                // Gather important data
                var isPressed = (selected == i);

                // Update Colors
                GUI.contentColor = isPressed ? Color.white : Color.white; // Yes they're the same!
                var offColor = offColorBlack ? Color.black : Color.white;
                GUI.backgroundColor = isPressed ? new Color(0.0f, 1.0f, 1.0f, 1.0f) : offColor;
                
                // Draw button
                if (width > 0)
                {
                    if (GUILayout.Toggle(isPressed, options[i], style, GUILayout.Width(buttonWidth)) && !isPressed)
                        selected = i; // Set the selected option when a button is pressed
                }
                else
                {
                    if (GUILayout.Toggle(isPressed, options[i], style) && !isPressed)
                        selected = i; // Set the selected option when a button is pressed
                }
                
            }
            EndRow();
            
            // Reset colors
            GUI.backgroundColor = originalBackgroundColor;
            GUI.contentColor = originalContentColor;
            
            return selected;
        }
        
        public static int Toolbar(string[] strings, int value, int width = -1, int fontSize = 12, bool bold = false) 
        {
            var style = new GUIStyle(GUI.skin.button);
            style.fontSize = fontSize;
            if (bold)
                style.fontStyle = FontStyle.Bold;
            
            return width < 0 
                ? GUILayout.Toolbar(value, strings, style) 
                : GUILayout.Toolbar(value, strings, style, GUILayout.Width(width));
        }
        
        public static T Toolbar<T>(T enumValue, int width = -1, int fontSize = 12, bool bold = false) where T : Enum
        {
            var strings = Enum.GetNames(typeof(T));
            var value = Convert.ToInt32(enumValue);

            var style = new GUIStyle(GUI.skin.button)
            {
                fontSize = fontSize
            };
            
            if (bold) style.fontStyle = FontStyle.Bold;

            value = width < 0 
                ? GUILayout.Toolbar(value, strings, style) 
                : GUILayout.Toolbar(value, strings, style, GUILayout.Width(width));

            return (T)Enum.ToObject(typeof(T), value);
        }


        public static void Header1(string label, bool richText = false) => LabelBig(label, 24, true, richText);
        public static void Header1(string label, string toolTip, int width, bool richText = false) => LabelBig(label, toolTip, width, 24, true, richText);
        public static void Header1(string label, int width, bool richText = false) => LabelBig(label, width, 24, true, richText);
        
        public static void Header2(string label, bool richText = false) => LabelBig(label, 18, true, richText);
        public static void Header2(string label, string toolTip, int width, bool richText = false) => LabelBig(label, toolTip, width, 18, true, richText);
        public static void Header2(string label, int width, bool richText = false) => LabelBig(label, width, 18, true, richText);
        
        public static void Header3(string label, bool richText = false) => LabelBig(label, 14, true, richText);
        public static void Header3(string label, string toolTip, int width, bool richText = false) => LabelBig(label, toolTip, width, 14, true, richText);
        public static void Header3(string label, int width, bool richText = false) => LabelBig(label, width, 14, true, richText);

        public static void IconWarning(int width = 20, int height = 20) => GUILayout.Label(EditorGUIUtility.FindTexture("console.warnicon"), GUILayout.Width(width), GUILayout.Height(height));
        public static void IconError(int width = 20, int height = 20) => GUILayout.Label(EditorGUIUtility.FindTexture("console.erroricon"), GUILayout.Width(width), GUILayout.Height(height));
        public static void IconInfo(int width = 20, int height = 20) => GUILayout.Label(EditorGUIUtility.FindTexture("console.infoicon"), GUILayout.Width(width), GUILayout.Height(height));
        public static void IconPlay(int width = 20, int height = 20) => GUILayout.Label(EditorGUIUtility.FindTexture("PlayButton"), GUILayout.Width(width), GUILayout.Height(height));
        public static void IconPause(int width = 20, int height = 20) => GUILayout.Label(EditorGUIUtility.FindTexture("PauseButton"), GUILayout.Width(width), GUILayout.Height(height));
        public static void IconFolder(int width = 20, int height = 20) => GUILayout.Label(EditorGUIUtility.FindTexture("Folder Icon"), GUILayout.Width(width), GUILayout.Height(height));
        public static void IconFavorite(int width = 20, int height = 20) => GUILayout.Label(EditorGUIUtility.FindTexture("d_Favorite"), GUILayout.Width(width), GUILayout.Height(height));
        public static void IconSettings(int width = 20, int height = 20) => GUILayout.Label(EditorGUIUtility.FindTexture("SettingsIcon"), GUILayout.Width(width), GUILayout.Height(height));
        public static void IconRefresh(int width = 20, int height = 20) => GUILayout.Label(EditorGUIUtility.FindTexture("d_RotateTool"), GUILayout.Width(width), GUILayout.Height(height));
        public static void IconTrash(int width = 20, int height = 20) => GUILayout.Label(EditorGUIUtility.FindTexture("TreeEditor.Trash"), GUILayout.Width(width), GUILayout.Height(height));


        // Label Fields
        public static void LabelBig(string label, int fontSize = 18, bool bold = false, bool richText = false)
        {
            GUIStyle style = new GUIStyle(bold ? EditorStyles.boldLabel : EditorStyles.label);
            style.fontSize = fontSize;
            if (richText) style.richText = true;
            EditorGUILayout.LabelField(label, style, GUILayout.Height(fontSize));
        }

        public static void LabelBig(string label, int width, int fontSize = 18, bool bold = false, bool richText = false)
        {
            GUIStyle style = new GUIStyle(bold ? EditorStyles.boldLabel : EditorStyles.label);
            style.fontSize = fontSize;
            if (richText) style.richText = true;
            EditorGUILayout.LabelField(label, style, GUILayout.Width(width), GUILayout.Height(fontSize));
        }
        
        public static void LabelBig(string label, string tooltip, int width, int fontSize = 18, bool bold = false, bool richText = false)
        {
            GUIStyle style = new GUIStyle(bold ? EditorStyles.boldLabel : EditorStyles.label);
            style.fontSize = fontSize;
            if (richText) style.richText = true;
            EditorGUILayout.LabelField(new GUIContent(label, tooltip), style, GUILayout.Width(width), GUILayout.Height(fontSize));
        }
        
        public static void Label(string label, bool bold = false, bool wordwrap = false, bool richText = false)
        {
            GUIStyle style = new GUIStyle(bold ? EditorStyles.boldLabel : EditorStyles.label);
            if (wordwrap) style.wordWrap = true;
            if (richText) style.richText = true;
            EditorGUILayout.LabelField(label, style);
        }
        
        public static void LabelGrey(string label, bool bold = false, bool wordwrap = false, bool richText = false)
        {
            ContentColor(Color.grey);
            GUIStyle style = new GUIStyle(bold ? EditorStyles.boldLabel : EditorStyles.label);
            if (wordwrap) style.wordWrap = true;
            if (richText) style.richText = true;
            EditorGUILayout.LabelField(label, style);
            ContentColor(Color.white);
        }
        
        public static void LabelGrey(string label, int width, bool bold = false, bool wordwrap = false, bool richText = false)
        {
            ContentColor(Color.grey);
            GUIStyle style = new GUIStyle(bold ? EditorStyles.boldLabel : EditorStyles.label);
            if (wordwrap) style.wordWrap = true;
            if (richText) style.richText = true;
            EditorGUILayout.LabelField(label, style, GUILayout.Width(width));
            ContentColor(Color.white);
        }
        
        public static void LabelSized(string label, int fontSize = 18, bool bold = false, bool richText = false)
        {
            GUIStyle style = new GUIStyle(bold ? EditorStyles.boldLabel : EditorStyles.label);
            style.fontSize = fontSize;
            if (richText) style.richText = true;
            EditorGUILayout.LabelField(label, style);
        }
        
        public static void LabelSized(string label, string tooltip, int fontSize = 18, bool bold = false, bool richText = false)
        {
            GUIStyle style = new GUIStyle(bold ? EditorStyles.boldLabel : EditorStyles.label);
            style.fontSize = fontSize;
            if (richText) style.richText = true;
            EditorGUILayout.LabelField(new GUIContent(label, tooltip), style);
        }
        
        public static void LabelSized(string label, int width, int fontSize = 18, bool bold = false, bool richText = false)
        {
            GUIStyle style = new GUIStyle(bold ? EditorStyles.boldLabel : EditorStyles.label);
            style.fontSize = fontSize;
            if (richText) style.richText = true;
            EditorGUILayout.LabelField(label, style, GUILayout.Width(width));
        }
        
        public static void LabelSized(string label, string tooltip, int width, int fontSize = 18, bool bold = false, bool richText = false)
        {
            GUIStyle style = new GUIStyle(bold ? EditorStyles.boldLabel : EditorStyles.label);
            style.fontSize = fontSize;
            if (richText) style.richText = true;
            EditorGUILayout.LabelField(new GUIContent(label, tooltip), style, GUILayout.Width(width));
        }

        public static void Label(string label, int width, bool bold = false, bool wordwrap = false, bool richText = false)
        {
            GUIStyle style = new GUIStyle(bold ? EditorStyles.boldLabel : EditorStyles.label);
            if (wordwrap) style.wordWrap = true;
            if (richText) style.richText = true;
            EditorGUILayout.LabelField(label, style, GUILayout.Width(width));
        }
        
        public static void Label(string label, int width, int height, bool bold = false, bool wordwrap = false, bool richText = false)
        {
            GUIStyle style = new GUIStyle(bold ? EditorStyles.boldLabel : EditorStyles.label);
            if (wordwrap) style.wordWrap = true;
            if (richText) style.richText = true;
            EditorGUILayout.LabelField(label, style, GUILayout.Width(width), GUILayout.Height(height));
        }
        
        public static void Label(string label, string tooltip, bool bold = false, bool wordwrap = false, bool richText = false)
        {
            GUIStyle style = new GUIStyle(bold ? EditorStyles.boldLabel : EditorStyles.label);
            if (wordwrap) style.wordWrap = true;
            if (richText) style.richText = true;
            EditorGUILayout.LabelField(new GUIContent(label, tooltip), style);
        }
        
        public static void Label(string label, string tooltip, int width, bool bold = false, bool wordwrap = false, bool richText = false)
        {
            GUIStyle style = new GUIStyle(bold ? EditorStyles.boldLabel : EditorStyles.label);
            if (wordwrap) style.wordWrap = true;
            if (richText) style.richText = true;
            EditorGUILayout.LabelField(new GUIContent(label, tooltip), style, GUILayout.Width(width));
        }
        
        public static void LabelNormal(string label, int width = 150, bool bold = false, bool wordwrap = false, bool richText = true) 
            => Label($"{textNormal}{label}{textColorEnd}", width, bold, wordwrap, richText);
        
        public static void LabelWarning(string label, int width = 150, bool bold = false, bool wordwrap = false, bool richText = true) 
            => Label($"{textWarning}{label}{textColorEnd}", width, bold, wordwrap, richText);
        
        public static void LabelError(string label, int width = 150, bool bold = false, bool wordwrap = false, bool richText = true) 
            => Label($"{textError}{label}{textColorEnd}", width, bold, wordwrap, richText);
        
        public static void LabelFaded(string label, int width = 150, bool bold = false, bool wordwrap = false, bool richText = true) 
            => Label($"{textFaded}{label}{textColorEnd}", width, bold, wordwrap, richText);
        
        public static void LabelMuted(string label, int width = 150, bool bold = false, bool wordwrap = false, bool richText = true) 
            => Label($"{textMuted}{label}{textColorEnd}", width, bold, wordwrap, richText);
        
        public static void LabelHighlight(string label, int width = 150, bool bold = false, bool wordwrap = false, bool richText = true) 
            => Label($"{textHightlight}{label}{textColorEnd}", width, bold, wordwrap, richText);
        
        public static void LabelNormal(string label, string tooltip, int width = 150, bool bold = false, bool wordwrap = false, bool richText = true) 
            => Label($"{textNormal}{label}{textColorEnd}", tooltip, width, bold, wordwrap, richText);
        
        public static void LabelWarning(string label, string tooltip, int width = 150, bool bold = false, bool wordwrap = false, bool richText = true) 
            => Label($"{textWarning}{label}{textColorEnd}", tooltip, width, bold, wordwrap, richText);
        
        public static void LabelError(string label, string tooltip, int width = 150, bool bold = false, bool wordwrap = false, bool richText = true) 
            => Label($"{textError}{label}{textColorEnd}", tooltip, width, bold, wordwrap, richText);
        
        public static void LabelFaded(string label, string tooltip, int width = 150, bool bold = false, bool wordwrap = false, bool richText = true) 
            => Label($"{textFaded}{label}{textColorEnd}", tooltip, width, bold, wordwrap, richText);
        
        public static void LabelMuted(string label, string tooltip, int width = 150, bool bold = false, bool wordwrap = false, bool richText = true) 
            => Label($"{textMuted}{label}{textColorEnd}", tooltip, width, bold, wordwrap, richText);
        
        public static void LabelHighlight(string label, string tooltip, int width = 150, bool bold = false, bool wordwrap = false, bool richText = true) 
            => Label($"{textHightlight}{label}{textColorEnd}", tooltip, width, bold, wordwrap, richText);
        
        // Sliders

        public static int SliderInt(int value, int min, int max) => Mathf.RoundToInt(EditorGUILayout.Slider(value, min, max));
        public static int SliderInt(string label, int value, int min, int max) => Mathf.RoundToInt(EditorGUILayout.Slider(label, value, min, max));
        public static int SliderInt(int value, int min, int max, int width) => Mathf.RoundToInt(EditorGUILayout.Slider(value, min, max, GUILayout.Width(width)));
        public static int SliderInt(string label, int value, int min, int max, int width) => Mathf.RoundToInt(EditorGUILayout.Slider(label, value, min, max, GUILayout.Width(width)));
        
        public static float SliderFloat(float value, float min, float max) => EditorGUILayout.Slider(value, min, max);
        public static float SliderFloat(string label, float value, float min, float max) => EditorGUILayout.Slider(label, value, min, max);
        public static float SliderFloat(float value, float min, float max, int width) => EditorGUILayout.Slider(value, min, max, GUILayout.Width(width));
        public static float SliderFloat(string label, float value, float min, float max, int width) => EditorGUILayout.Slider(label, value, min, max, GUILayout.Width(width));

        // Text Areas
        public static string TextArea(string text, int width, int height = 50)
        {
            GUIStyle style = new GUIStyle(EditorStyles.textArea);
            style.wordWrap = true;
            return EditorGUILayout.TextArea(text, style, GUILayout.Width(width), GUILayout.Height(height));
        }
        
        public static string TextArea(string text, int height = 50)
        {
            GUIStyle style = new GUIStyle(EditorStyles.textArea);
            style.wordWrap = true;
            return EditorGUILayout.TextArea(text, style, GUILayout.Height(height));
        }
        
        // Text Fields
        public static string TextField(string text, bool bold = false)
        {
            if (bold)
                return EditorGUILayout.TextField(text, EditorStyles.boldLabel);
            return EditorGUILayout.TextField(text);
        }
        
        public static string TextField(string label, string text, bool bold = false)
        {
            if (bold)
                return EditorGUILayout.TextField(label, text, EditorStyles.boldLabel);
            return EditorGUILayout.TextField(label, text);
        }
        
        public static string TextField(string label, string text, int width, bool bold = false)
        {
            if (bold)
                return EditorGUILayout.TextField(label, text, EditorStyles.boldLabel, GUILayout.Width(width));
            return EditorGUILayout.TextField(label, text, GUILayout.Width(width));
        }
        
        public static string TextField(string label, string tooltip, string text, bool bold = false)
        {
            if (bold)
                return EditorGUILayout.TextField(new GUIContent(label, tooltip), text, EditorStyles.boldLabel);
            return EditorGUILayout.TextField(new GUIContent(label, tooltip), text);
        }
        
        public static string TextField(string label, string tooltip, string text, int width, bool bold = false)
        {
            if (bold)
                return EditorGUILayout.TextField(new GUIContent(label, tooltip), text, EditorStyles.boldLabel, GUILayout.Width(width));
            return EditorGUILayout.TextField(new GUIContent(label, tooltip), text, GUILayout.Width(width));
        }
        
        public static string TextField(string text, int width, bool bold = false)
        {
            if (bold)
                return EditorGUILayout.TextField(text, EditorStyles.boldLabel, GUILayout.Width(width));
            return EditorGUILayout.TextField(text, GUILayout.Width(width));
        }
        
        public static string TextField(string text, int width, int height, bool bold = false)
        {
            if (bold)
                return EditorGUILayout.TextField(text, EditorStyles.boldLabel, GUILayout.Width(width), GUILayout.Height(height));
            return EditorGUILayout.TextField(text, GUILayout.Width(width), GUILayout.Height(height));
        }

        // Delayed Text Fields
        public static string DelayedText(string text, bool bold = false)
        {
            if (bold)
                return EditorGUILayout.DelayedTextField(text, EditorStyles.boldLabel);
            return EditorGUILayout.DelayedTextField(text);
        }
        
        public static string DelayedText(string label, string text, bool bold = false)
        {
            if (bold)
                return EditorGUILayout.DelayedTextField(label, text, EditorStyles.boldLabel);
            return EditorGUILayout.DelayedTextField(label, text);
        }
        
        public static string DelayedText(string label, string text, int width, bool bold = false)
        {
            if (bold)
                return EditorGUILayout.DelayedTextField(label, text, EditorStyles.boldLabel, GUILayout.Width(width));
            return EditorGUILayout.DelayedTextField(label, text, GUILayout.Width(width));
        }
        
        public static string DelayedText(string label, string tooltip, string text, bool bold = false)
        {
            if (bold)
                return EditorGUILayout.DelayedTextField(new GUIContent(label, tooltip), text, EditorStyles.boldLabel);
            return EditorGUILayout.DelayedTextField(new GUIContent(label, tooltip), text);
        }
        
        public static string DelayedText(string label, string tooltip, string text, int width, bool bold = false)
        {
            if (bold)
                return EditorGUILayout.DelayedTextField(new GUIContent(label, tooltip), text, EditorStyles.boldLabel, GUILayout.Width(width));
            return EditorGUILayout.DelayedTextField(new GUIContent(label, tooltip), text, GUILayout.Width(width));
        }
        
        public static string DelayedText(string text, int width, bool bold = false)
        {
            if (bold)
                return EditorGUILayout.DelayedTextField(text, EditorStyles.boldLabel, GUILayout.Width(width));
            return EditorGUILayout.DelayedTextField(text, GUILayout.Width(width));
        }

        // Bool Checkboxes
        public static bool LeftCheck(string label, bool value) => EditorGUILayout.ToggleLeft(label, value);
        public static bool LeftCheck(string label, bool value, int width) => EditorGUILayout.ToggleLeft(label, value, GUILayout.Width(width));
        public static bool LeftCheck(string label, string tooltip, bool value) => EditorGUILayout.ToggleLeft(new GUIContent(label, tooltip), value);
        public static bool LeftCheck(string label, string tooltip, bool value, int width) => EditorGUILayout.ToggleLeft(new GUIContent(label, tooltip), value, GUILayout.Width(width));
        
        public static bool Check(string label, string tooltip, bool value) => EditorGUILayout.Toggle(new GUIContent(label, tooltip), value);
        public static bool Check(string label, string tooltip, bool value, int width) => EditorGUILayout.Toggle(new GUIContent(label, tooltip), value, GUILayout.Width(width));
        public static bool Check(string label, bool value) => EditorGUILayout.Toggle(label, value);
        public static bool Check(string label, bool value, int width) => EditorGUILayout.Toggle(label, value, GUILayout.Width(width));
        public static bool Check(bool value) => EditorGUILayout.Toggle(value);

        // Bool checkboxes that set prefs
        public static void LeftCheckSetBool(string boolName, string label) => SetBool(boolName, LeftCheck(label, GetBool(boolName)));
        public static void LeftCheckSetBool(string boolName, string label, string tooltip) => SetBool(boolName, LeftCheck(label, tooltip, GetBool(boolName)));

        public static bool Check(bool value, int width) => EditorGUILayout.Toggle(value, GUILayout.Width(width));

        // Basic FloatSlider without label or tooltip
        public static float FloatSlider(float value, float minValue, float maxValue) => EditorGUILayout.Slider(value, minValue, maxValue);
        public static float FloatSlider(float value, float minValue, float maxValue, int width) => EditorGUILayout.Slider(value, minValue, maxValue, GUILayout.Width(width));

// FloatSlider with just a label
        public static float FloatSlider(string label, float value, float minValue, float maxValue) => EditorGUILayout.Slider(label, value, minValue, maxValue);
        public static float FloatSlider(string label, float value, float minValue, float maxValue, int width) => EditorGUILayout.Slider(label, value, minValue, maxValue, GUILayout.Width(width));

// FloatSlider with both label and tooltip
        public static float FloatSlider(string label, string tooltip, float value, float minValue, float maxValue) => EditorGUILayout.Slider(new GUIContent(label, tooltip), value, minValue, maxValue);
        public static float FloatSlider(string label, string tooltip, float value, float minValue, float maxValue, int width) => EditorGUILayout.Slider(new GUIContent(label, tooltip), value, minValue, maxValue, GUILayout.Width(width));

        
        // Float field
        public static float Float(string label, float value) => EditorGUILayout.FloatField(label, value);
        public static float Float(string label, float value, int width) => EditorGUILayout.FloatField(label, value, GUILayout.Width(width));
        public static float Float(float value) => EditorGUILayout.FloatField(value);
        public static float Float(float value, int width) => EditorGUILayout.FloatField(value, GUILayout.Width(width));
        
        public static float Float(string label, string tooltip, float value) => EditorGUILayout.FloatField(new GUIContent(label, tooltip), value);
        public static float Float(string label, string tooltip, float value, int width) => EditorGUILayout.FloatField(new GUIContent(label, tooltip), value, GUILayout.Width(width));

        public static float DelayedFloat(string label, float value) => EditorGUILayout.DelayedFloatField(label, value);
        public static float DelayedFloat(string label, float value, int width) => EditorGUILayout.DelayedFloatField(label, value, GUILayout.Width(width));
        public static float DelayedFloat(float value) => EditorGUILayout.DelayedFloatField(value);
        public static float DelayedFloat(float value, int width) => EditorGUILayout.DelayedFloatField(value, GUILayout.Width(width));
        public static float DelayedFloat(string label, string tooltip, float value) => EditorGUILayout.DelayedFloatField(new GUIContent(label, tooltip), value);
        public static float DelayedFloat(string label, string tooltip, float value, int width) => EditorGUILayout.DelayedFloatField(new GUIContent(label, tooltip), value, GUILayout.Width(width));
        
        // Int Field
        public static int Int(string label, int value) => EditorGUILayout.IntField(label, value);
        public static int Int(string label, int value, int width) => EditorGUILayout.IntField(label, value, GUILayout.Width(width));
        public static int Int(int value) => EditorGUILayout.IntField(value);
        public static int Int(int value, int width) => EditorGUILayout.IntField(value, GUILayout.Width(width));
        
        public static int DelayedInt(string label, int value) => EditorGUILayout.DelayedIntField(label, value);
        public static int DelayedInt(string label, int value, int width) => EditorGUILayout.DelayedIntField(label, value, GUILayout.Width(width));
        public static int DelayedInt(int value) => EditorGUILayout.DelayedIntField(value);
        public static int DelayedInt(int value, int width) => EditorGUILayout.DelayedIntField(value, GUILayout.Width(width));

        // Object Field
        public static Object Object(Object obj, Type objType, bool allowSceneObjects = false) => EditorGUILayout.ObjectField(obj, objType, allowSceneObjects);
        public static Object Object(Object obj, Type objType, string label, bool allowSceneObjects = false) => EditorGUILayout.ObjectField(label, obj, objType, allowSceneObjects);
        public static Object Object(Object obj, Type objType, string label, int width, bool allowSceneObjects = false) => EditorGUILayout.ObjectField(label, obj, objType, allowSceneObjects, GUILayout.Width(width));
        public static Object Object(Object obj, Type objType, int width, bool allowSceneObjects = false) => EditorGUILayout.ObjectField(obj, objType, allowSceneObjects, GUILayout.Width(width));

        
        // Color Select
        public static Color ColorField(Color color, int width) => EditorGUILayout.ColorField(color, GUILayout.Width(width));
        public static Color ColorField(Color color) => EditorGUILayout.ColorField(color);
        
        public static void ColorValue(Color color, float width = 18, float height = 18)
        {
            // Ensure the color is fully opaque by setting alpha to 1
            color = new Color(color.r, color.g, color.b, 1);

            // Get a rectangle with the specified width and height without expanding
            Rect rect = GUILayoutUtility.GetRect(width, height, GUILayout.Width(width), GUILayout.Height(height));

            // Draw the rectangle with the specified color
            EditorGUI.DrawRect(rect, color);
        }

        // Vector 4 Field
        public static Vector4 Vector4Field(Vector4 value, string label = "") => EditorGUILayout.Vector4Field(label, value);
        public static Vector4 Vector4Field(Vector4 value, int width, string label = "") => EditorGUILayout.Vector4Field(label, value, GUILayout.Width(width));
        
        // Vector 3 Field
        public static Vector3 Vector3Field(Vector3 value, string label = "") => EditorGUILayout.Vector3Field(label, value);
        public static Vector3 Vector3Field(Vector3 value, int width, string label = "") => EditorGUILayout.Vector3Field(label, value, GUILayout.Width(width));

        // Vector 2 Field
        public static Vector2 Vector2Field(Vector2 value, string label = "") => EditorGUILayout.Vector2Field(label, value);
        public static Vector2 Vector2Field(Vector2 value, int width, string label = "") => EditorGUILayout.Vector2Field(label, value, GUILayout.Width(width));

        // Popup
        public static int Popup(int index, string[] options) => Popup(index, options, -1);
        
        public static int Popup(int index, string[] options, int width, int height = -1)
        {
            if (options == null) return default;
            if (options.Length == 0) return default;
            if (width < 0 && height < 0) return EditorGUILayout.Popup(index, options);
            if (height < 0) return EditorGUILayout.Popup(index, options, GUILayout.Width(width));

            // Create a custom popup with a scroll view
            index = Mathf.Clamp(index, 0, options.Length - 1);
            var rect = GUILayoutUtility.GetRect(new GUIContent(options[index]), EditorStyles.popup, GUILayout.Width(width));
            if (!EditorGUI.DropdownButton(rect, new GUIContent(options[index]), FocusType.Keyboard, EditorStyles.popup))
                return index;
            
            var mousePosition = Event.current.mousePosition;
            var listRect = new Rect(mousePosition.x, mousePosition.y, width, height);
            var newIndex = EditorGUI.Popup(listRect, index, options);
            if (newIndex == index) return index;
            
            index = newIndex;
            GUI.changed = true;
            return index;
        }
        
        public static int Popup(string label, int index, string[] options)
        {
            if (options == null) return default;
            if (options.Length == 0) return default;
            return EditorGUILayout.Popup(label, index, options);
        }
        
        public static int Popup(string label, int index, string[] options, int width)
        {
            if (options == null) return default;
            if (options.Length == 0) return default;
            return EditorGUILayout.Popup(label, index, options, GUILayout.Width(width));
        }
        
        // Enum Popup
        public static Enum EnumPopup(Enum selected) => EditorGUILayout.EnumPopup(selected);

        public static Enum EnumPopup(Enum selected, int width) => EditorGUILayout.EnumPopup(selected, GUILayout.Width(width));
        
        /*
        * ----------------------------------------------------------------------------------------------
        * GUI LAYOUTS
        * ----------------------------------------------------------------------------------------------
        */
        
        // Boxes
        public static void StartVerticalBox() => EditorGUILayout.BeginVertical(EditorStyles.helpBox);

        public static void StartVerticalBox(int width) => EditorGUILayout.BeginVertical(EditorStyles.helpBox, GUILayout.Width(width));
        
        public static bool StartVerticalBoxSection(bool value, string label, int fontSize = 14, bool bold = true, string tooltip = "")
        {
            // Create a custom style for the box.
            GUIStyle boxStyle = new GUIStyle(EditorStyles.helpBox);
            boxStyle.padding = new RectOffset(0, 0, 0, 0);  // Remove padding so everything is flush.
            
            var headerStyle = new GUIStyle
            {
                normal =
                {
                    textColor = value ? Color.white : Color.white,
                    background = MakeTex(2, 2, 
                        value 
                            ? new Color(1f,1f,1f, 0.25f) 
                            : new Color(1f, 1f, 1f, 0.0f)),
                },
                fontSize = fontSize,
                fontStyle = bold ? FontStyle.Bold : FontStyle.Normal,
                padding = new RectOffset(0, 0, 3, 3),
                border = new RectOffset(5, 5, 0, 0), // No border
                margin = new RectOffset(1, 1, 1, 0), // No margin
                overflow = new RectOffset(0, 0, 0, 0), // No overflow
                clipping = TextClipping.Clip, // Clip the text to the button's area
                alignment = TextAnchor.MiddleCenter, // Center the text both horizontally and vertically
            };
            
            // Begin a new vertical box with the custom style.
            EditorGUILayout.BeginVertical(boxStyle);

            // Add a button as the header.
            var newValue = value;
            if (string.IsNullOrEmpty(tooltip))
            {
                if (GUILayout.Button(new GUIContent($" {label}", EditorGUIUtility.IconContent("d_ViewToolOrbit On").image), headerStyle))
                    newValue = !value;
            }
            else
            {
                if (GUILayout.Button(new GUIContent($" {label}", EditorGUIUtility.IconContent("d_ViewToolOrbit On").image, tooltip), headerStyle))
                    newValue = !value;
            }
            
            ResetColor();

            return newValue;
        }

        public static Texture2D ScaleTexture(Texture2D source, int maxSize)
        {
            if (source == null)
                return default;
            
            // Determine whether the width or height is the larger dimension
            bool widthIsLarger = source.width > source.height;

            // Compute the target width and height, maintaining aspect ratio
            int targetWidth = widthIsLarger ? maxSize : (int)(source.width / (source.height / (float)maxSize));
            int targetHeight = !widthIsLarger ? maxSize : (int)(source.height / (source.width / (float)maxSize));

            Texture2D result = new Texture2D(targetWidth, targetHeight, source.format, false);
            Color[] rpixels = result.GetPixels(0);
            float incX = ((float)1 / source.width) * ((float)source.width / targetWidth);
            float incY = ((float)1 / source.height) * ((float)source.height / targetHeight);
            for (int px = 0; px < rpixels.Length; px++)
            {
                rpixels[px] = source.GetPixelBilinear(incX * ((float)px % targetWidth),
                    incY * Mathf.Floor(px / targetWidth));
            }
            result.SetPixels(rpixels, 0);
            result.Apply();
            return result;
        }

        
        private static Texture2D MakeBorderTex(int width, int height, Color color, int thickness)
        {
            Color[] pix = new Color[width * height];

            for (int i = 0; i < pix.Length; i++)
            {
                if (i < (width * thickness) || // top
                    i > (width * height) - (width * thickness) || // bottom
                    i % width < thickness || // left
                    i % width > width - thickness - 1)  // right
                {
                    pix[i] = color;
                }
                else
                {
                    pix[i] = Color.clear;
                }
            }

            Texture2D result = new Texture2D(width, height);
            result.SetPixels(pix);
            result.Apply();

            return result;
        }


        static Texture2D MakeTex(int width, int height, Color col)
        {
            Color[] pix = new Color[width * height];
            for (int i = 0; i < pix.Length; i++)
                pix[i] = col;
            Texture2D result = new Texture2D(width, height);
            result.SetPixels(pix);
            result.Apply();
            return result;
        }
        
        public static bool ButtonSectionBig(bool value, string label, int width, int fontSize = 14, bool bold = true)
        {
            // Cache original colors
            var originalBackgroundColor = GUI.backgroundColor;
            var originalContentColor = GUI.contentColor;
            
            // Create style
            var style = new GUIStyle(GUI.skin.button);
            style.fontSize = fontSize;
            if (bold)
                style.fontStyle = FontStyle.Bold;

            // Update Colors
            GUI.contentColor = value ? Color.white : Color.white; // Yes they're the same!
            GUI.backgroundColor = value ? new Color(0.0f, 1.0f, 0.0f, 1.0f) : Color.white;

            var newValue = value;
            
            // Draw button
            if (GUILayout.Button(new GUIContent($" {label}", EditorGUIUtility.IconContent("d_ViewToolOrbit On").image), style, GUILayout.Width(width)))
                newValue = !value; // Set the selected option when a button is pressed
            
            // Reset colors
            GUI.backgroundColor = originalBackgroundColor;
            GUI.contentColor = originalContentColor;

            return newValue;
        }
        
        public static void EndVerticalBox() => EditorGUILayout.EndVertical();
        public static void MessageBox(string content, MessageType messageType = MessageType.None) => EditorGUILayout.HelpBox(content, messageType);

        // Vertical
        public static void StartVertical() => EditorGUILayout.BeginVertical();
        public static void StartVertical(int width) => EditorGUILayout.BeginVertical(GUILayout.Width(width));
        public static void EndVertical() => EditorGUILayout.EndVertical();
        
        // Horizontal
        public static void StartRow() => EditorGUILayout.BeginHorizontal();
        public static void EndRow() => EditorGUILayout.EndHorizontal();
        
        // Space
        public static void Space() => EditorGUILayout.Space();
        public static void Space(int height) => EditorGUILayout.Space(height);

        public static void Line() => EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

        // Foldout Header Group
        public static bool StartFoldoutHeaderGroup(bool value, string text) => EditorGUILayout.BeginFoldoutHeaderGroup(value, text);
        public static void StartFoldoutHeaderGroupSetBool(string boolName, string text) => SetBool(boolName, StartFoldoutHeaderGroup(GetBool(boolName), text));
        public static void EndFoldoutHeaderGroup() => EditorGUILayout.EndFoldoutHeaderGroup();

        /*
        * ----------------------------------------------------------------------------------------------
        * PREFS ETC
        * ----------------------------------------------------------------------------------------------
        */

        public static void ToggleBool(string name) => EditorPrefs.SetBool(name, !EditorPrefs.GetBool(name));
        
        // Set
        public static void SetBool(string name, bool value) => EditorPrefs.SetBool(name, value);
        public static void SetString(string name, string value) => EditorPrefs.SetString(name, value);
        public static void SetFloat(string name, float value) => EditorPrefs.SetFloat(name, value);
        public static void SetInt(string name, int value) => EditorPrefs.SetInt(name, value);
        
        // Get
        public static bool GetBool(string name) => EditorPrefs.GetBool(name);
        public static string GetString(string name) => EditorPrefs.GetString(name);
        public static float GetFloat(string name) => EditorPrefs.GetFloat(name);
        public static int GetInt(string name) => EditorPrefs.GetInt(name);
        
        // Other
        public static bool HasKey(string name) => EditorPrefs.HasKey(name);
        public static void DeleteKey(string name) => EditorPrefs.DeleteKey(name);

        /*
        * ----------------------------------------------------------------------------------------------
        * UTILITIES
        * ----------------------------------------------------------------------------------------------
        */

        public static int TimeSinceStartup => (int) EditorApplication.timeSinceStartup;
        
        // Dialog
        public static bool Dialog(string title, string message, string ok = "Yes", string cancel = "Cancel")
        {
            if (EditorUtility.DisplayDialog(title, message, ok, cancel))
                return true;
            return false;
        }

        // Color

        public static void ColorsFlash(Color background1, Color content1, Color background2, Color content2)
        {
            var isOn = TimeSinceStartup % 2 == 0;
            Colors(isOn ? background1 : background2, isOn ? content1 : content2);
        }
        
        public static void Colors(Color backgroundColor, Color contentColor)
        {
            BackgroundColor(backgroundColor);
            ContentColor(contentColor);
        }

        public static void Colors(Color colors) => Colors(colors, colors);
        public static void ColorsIf(bool boolean, Color backgroundColorTrue, Color backgroundColorFalse, Color contentColorTrue, Color contentColorFalse)
        {
            BackgroundColorIf(boolean, backgroundColorTrue, backgroundColorFalse);
            ContentColorIf(boolean, contentColorTrue, contentColorFalse);
        }
        public static void BackgroundColorIf(bool boolean, Color trueColor, Color falseColor) =>
            BackgroundColor(boolean ? trueColor : falseColor);
        public static void BackgroundColor(Color color) => GUI.backgroundColor = color;
        public static void ContentColor(Color color) => GUI.contentColor = color;
        public static void ContentColorIf(bool boolean, Color trueColor, Color falseColor) => 
            ContentColor(boolean ? trueColor : falseColor);
        public static void ResetColor()
        {
            GUI.backgroundColor = Color.white;
            GUI.contentColor = Color.white;
        }
        
        // Other
        public static void OpenURL(string url) => Application.OpenURL(url);

        public static void ExitGUI() => EditorGUIUtility.ExitGUI();

        public static void IndentPlus() => EditorGUI.indentLevel++;
        public static void IndentMinus() => EditorGUI.indentLevel--;

        // Debug Logs
        public static void Log(string text)
        {
#if UNITY_EDITOR
            Debug.Log(text);
#endif
        }
        
        public static void LogError(string text)
        {
#if UNITY_EDITOR
            Debug.LogError(text);
#endif
        }
        
        public static void LogWarning(string text)
        {
#if UNITY_EDITOR
            Debug.LogWarning(text);
#endif
        }
        
        // Mask Field
        protected static int MaskField(string label, int labelMask, string[] options)
        {
            return EditorGUILayout.MaskField(label, labelMask, options);
        }
        
        protected static int MaskField(string label, int labelMask, string[] options, int width)
        {
            return EditorGUILayout.MaskField(label, labelMask, options, GUILayout.Width(width));
        }
        
        protected static int MaskField(int labelMask, string[] options, int width)
        {
            return EditorGUILayout.MaskField(labelMask, options, GUILayout.Width(width));
        }
        
        public static LayerMask LayerMaskField(string label, LayerMask layerMask, int width)
        {
            var layers = UnityEditorInternal.InternalEditorUtility.layers;
            var layerNumbers = new List<int>();

            for (int i = 0; i < layers.Length; i++)
                layerNumbers.Add(LayerMask.NameToLayer(layers[i]));

            var maskWithoutEmpty = 0;
            for (int i = 0; i < layerNumbers.Count; i++)
            {
                if (((1 << layerNumbers[i]) & layerMask.value) != 0)
                    maskWithoutEmpty |= (1 << i);
            }

            maskWithoutEmpty = EditorGUILayout.MaskField(label, maskWithoutEmpty, layers, GUILayout.Width(width));

            var mask = 0;
            for (int i = 0; i < layerNumbers.Count; i++)
            {
                if ((maskWithoutEmpty & (1 << i)) != 0)
                    mask |= (1 << layerNumbers[i]);
            }

            layerMask.value = mask;

            return layerMask;
        }

        public static LayerMask LayerMaskField(LayerMask layerMask, int width)
        {
            return LayerMaskField("", layerMask, width);
        }
        
        /*
        * ----------------------------------------------------------------------------------------------
        * KEYS PRESSED
        * ----------------------------------------------------------------------------------------------
        */

        public static bool KeyAlt => Event.current.alt;
        public static bool KeyShift => Event.current.shift;
        
        /*
        * ----------------------------------------------------------------------------------------------
        * OTHER METHODS
        * ----------------------------------------------------------------------------------------------
        */

        protected void ProgressBar(string title, string info, float percent) =>
            EditorUtility.DisplayProgressBar(title, info, percent);

        protected void ProgressBar(string title, string info, float index, float total)
        {
            if (total <= 0) return; // Can't do this if total is not > 0
            
            if (index >= total)
            {
                ClearProgressBar();
                return;
            }
            
            ProgressBar(title, info, index / total);
        }
        
        protected void ClearProgressBar() => EditorUtility.ClearProgressBar();

        protected void DrawDefaultInspectorToggle(string key, string label = "Show Default Inspector")
        {
            SetBool(key, LeftCheck(label, GetBool(key)));
            if (!GetBool(key)) return; 
            DrawDefaultInspector();
        }

        public static void LinkToDocs(string url = "https://infinitypbr.gitbook.io/infinity-pbr/", string label = "Docs & Tutorials")
        {
            BackgroundColor(Color.cyan);
            if (Button($"{label} {symbolCircleArrow}"
                    , "This will open the support documentation page in a web browser."))
                Application.OpenURL(url);
            ResetColor();
        }
        
        public static bool CanMoveUp(int index, int total) => index != 0;
        
        public static bool CanMoveDown(int index, int total) => index != total - 1;
        
        /*
        * ----------------------------------------------------------------------------------------------
        * LIST ORDERING ETC
        * ----------------------------------------------------------------------------------------------
        */

        /// <summary>
        /// Moves the item to a new location in the list, by moveValue
        /// </summary>
        /// <param name="thisList"></param>
        /// <param name="index"></param>
        /// <param name="moveValue"></param>
        public static void MoveItem<T>(List<T> thisList, int index, int moveValue)
        {
            if (index + moveValue < 0) return;
            if (index + moveValue >= thisList.Count) return;

            MoveItemTo(thisList, index, index + moveValue);
        }

        public static void MoveItemUp<T>(List<T> thisList, int index) => MoveItem(thisList, index, -1);
        public static void MoveItemDown<T>(List<T> thisList, int index) => MoveItem(thisList, index, 1);

        /// <summary>
        /// Moves the item to a new location in the List() as specified
        /// </summary>
        /// <param name="thisList"></param>
        /// <param name="fromIndex"></param>
        /// <param name="toIndex"></param>
        public static void MoveItemTo<T>(List<T> thisList, int fromIndex, int toIndex)
        {
            if (toIndex < 0) return;
            if (toIndex >= thisList.Count) return;
            
            var item = thisList[fromIndex];
            thisList.RemoveAt(fromIndex);
            thisList.Insert(toIndex, item);
        }
        
        // Animation Curve
        public static AnimationCurve Curve(AnimationCurve curve, float handlePos = -1f, int width = 0, int height = 100)
        {
            var curveRect = GUILayoutUtility.GetRect(width, height, GUILayout.ExpandWidth(width == 0));
            curve = EditorGUI.CurveField(curveRect, curve, Color.red, new Rect(0, 0, 1, 1));
            
            if (handlePos < 0)
                return curve;

            var lastRect = GUILayoutUtility.GetLastRect();
            //lastRect.x += EditorGUIUtility.labelWidth;
            //lastRect.width -= EditorGUIUtility.labelWidth;

            Handles.color = Color.white;
            var x = lastRect.x + lastRect.width * handlePos;
            Handles.DrawLine(new Vector3(x, lastRect.y), new Vector3(x, lastRect.y + lastRect.height));
            
            return curve;
        }
        
        
        public static void DrawUILine(Color color, int thickness = 2, int padding = 10, int width = default)
        {
            GUILayoutOption[] options = { GUILayout.Height(padding + thickness)};
            if(width != default)
                options = new GUILayoutOption[] { GUILayout.Height(padding + thickness), GUILayout.Width(width) };

            var rect = EditorGUILayout.GetControlRect(options);
            rect.height = thickness;
            rect.y += padding / 2;
            rect.x -= 2; // Line thickness

            if (width != default)
                rect.width = width - 4; // Adjusting for line thickness

            EditorGUI.DrawRect(rect, color);
        }
        
        public static void WhiteLine(int thickness = 1, int padding = 15) => DrawUILine(Color.white, thickness, padding);
        public static void BlackLine(int thickness = 1, int padding = 15) => DrawUILine(Color.black, thickness, padding);
        public static void GreyLine(int thickness = 1, int padding = 15) => DrawUILine(Color.grey, thickness, padding);
        
        
    }
}