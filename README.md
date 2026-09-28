# 🥬 Veggie Platformer (Hackathon Project)

> *A pixel-art 2D action platformer where the vegetables fight back.*

![Unity](https://img.shields.io/badge/Unity-2D-black?logo=unity)
![C#](https://img.shields.io/badge/C%23-239120?logo=csharp&logoColor=white)
![Platforms](https://img.shields.io/badge/platforms-PC%20%7C%20Android-lightgrey)
![Status](https://img.shields.io/badge/status-alpha-orange)


## 🌟 Highlights

- 🍅 **A vegetable rogues' gallery** — bouncing tomatoes, corn that fires kernels, cabbage, lettuce, bananas and a two-part boss
- ⚔️ **Selectable attacks** — pick your weapon before a stage and switch between attack types
- 🗝️ **Puzzle-platforming** — keys, gates, levers, buttons, jump pads and warp holes
- 💾 **Save points** and an HP display, so failing doesn't mean starting over
- 🖥️📱 **PC and Android** — separate scene sets tuned for keyboard and touch
- 🎨 **Pixel-art look** with PixelMplus fonts and the Sunny Land asset pack


## ℹ️ Overview

This was my hackathon entry from early 2021 (January–March), my first sizable Unity project. It's a side-scrolling action game with a title screen, a story scene, stage select, three stages, a pause menu and a clear screen. Enemies share an object-oriented base class (`Enemies.cs`), so adding a new vegetable only takes a small subclass.


### ✍️ Author

Made by [Yuki Ishihara](https://github.com/pe-tanman).


## 🚀 Controls (PC)

| Key | Action |
| --- | --- |
| `A` / `D` | Move left / right |
| `Space` | Jump |
| `1` / `2` | Switch weapon |


## ⬇️ Opening the Project

This repository contains the project's **`Assets`** folder: scenes, scripts, art and asset-store packages.

1. Create a new **2D** project in Unity Hub (Unity 2020 LTS or newer).
2. Copy the contents of this repository into that project's `Assets/` folder.
3. Open `Scenes/PC/TitleScene 1.unity` (or `Scenes/Android/TitleScene.unity`) and press **Play**.

```
scripts/
├── player.cs, GM.cs, music.cs        # player, game manager, audio
├── enemy/                            # Tomato, Corn, Cabbage, Lettuce, banana, Boss…
└── map/                              # key, gate, lever, savepoint, warphole, cameras…
```


## 🙏 Credits

- *Sunny Land* art by Ansimuz (Unity Asset Store)
- *PixelMplus* fonts by itouhiro
- SpeedTutor *Full Menu System* and TextMesh Pro from the Unity Asset Store
