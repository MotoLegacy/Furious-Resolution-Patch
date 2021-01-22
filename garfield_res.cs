//
// MIT License
//
// Copyright (c) 2020 MotoLegacy
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
//

using System;
using UnityEngine;
using UnityEngine.UI;
using BepInEx;
using HarmonyLib;
using BepInEx.Harmony;

namespace garfield_res
{
    [BepInPlugin("org.bepinex.plugins.garfieldres", "Furious Racing Resolution Settings", "1.0.0.0")]
    [BepInProcess("Garfield Kart Furious Racing.exe")]
    public class garfield_res : BaseUnityPlugin
    {
        bool ShowMenu;
        bool Fullscreen_Enabled;
        string FSString = "";
        string Width = "";
        string Height = "";

        void Awake()
        {
            Console.WriteLine("[Resolution Patch] Initialized.");
            Cursor.visible = true;

            Width = string.Format("{0}", Screen.width);
            Height = string.Format("{0}", Screen.height);

            //Harmony harmony = new Harmony("com.motolegacy.garfieldres");
            //harmony.PatchAll();
        }

        void OnGUI()
        {
            if (!ShowMenu) {
                if (GUI.Button(new Rect(10, 10, 150, 50), "Show Screen Options")) {
                    ShowMenu = true;
                } 
            } else {
                if (GUI.Button(new Rect(10, 10, 150, 50), "Hide Screen Options")) {
                    ShowMenu = false;
                }

                if (Fullscreen_Enabled)
                    FSString = "Fullscreen: Enabled";
                else
                    FSString = "Fullscreen: Disabled";

                if (GUI.Button(new Rect(10, 75, 150, 50), FSString)) {
                    Fullscreen_Enabled = !Fullscreen_Enabled;
                }

                GUI.Box(new Rect(175, 10, 150, 50), "Window Width");
                GUI.Box(new Rect(350, 10, 150, 50), "Window Height");
                Width = GUI.TextField (new Rect (175, 35, 150, 25), Width, 40);
                Height = GUI.TextField (new Rect (350, 35, 150, 25), Height, 40);

                if (GUI.Button(new Rect(525, 10, 150, 50), "Apply Settings")) {
                    Screen.SetResolution(int.Parse(Width), int.Parse(Height), false);
                    Screen.fullScreen = Fullscreen_Enabled;
                }
            }
        }
    }
}