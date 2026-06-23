# Multi-Screen App (Unity 2D)

A simple 2D Unity application with three connected screens, built with Unity UI and persistent data storage using PlayerPrefs.

---

## Screenshots

<table>
  <tr>
    <td align="center" width="33%">
      <img src="https://github.com/user-attachments/assets/0946f4d4-123d-4022-9e7f-702d03cdc8b2" width="280"/><br/>
      <b>Welcome Screen</b>
    </td>
    <td align="center" width="33%">
      <img src="https://github.com/user-attachments/assets/06a28387-6336-4822-a0bd-780724aa3cc2" width="280"/><br/>
      <b>Counter Screen</b>
    </td>
    <td align="center" width="33%">
      <img src="https://github.com/user-attachments/assets/310a9b52-184d-4da5-8523-a49e76099234" width="280"/><br/>
      <b>Congratulations Screen</b>
    </td>
  </tr>
</table>

---

## Overview

A 3-screen flow: Welcome (name entry) → Counter (increment/decrement, persists, auto-advances at 10) → Congratulations (personalized message).

## Features

- Name input with empty-input validation
- Persistent name and counter value using PlayerPrefs
- Auto-skip welcome screen on return visits
- Auto-navigation to congratulations screen at counter value 10
- Custom background image and app icon per screen

## Project Structure

```
Assets/
├─ Scenes/
│  └─ SampleScene.unity  # Main scene containing the Canvas and all 3 panels
├─ Scripts/
│  └─ UIManager.cs       # Handles navigation, input, and persistence logic
├─ Settings/
├─ TextMesh Pro/
└─ UI/
   ├─ Backgrounds/       # Background images for each screen
   └─ Icons/             # App icon used on the welcome screen
```

## How It Works

- `UIManager.cs` is attached to a `GameManager` object in the scene.
- On `Start()`, it checks if a name already exists in PlayerPrefs. If it does, it skips straight to the Counter screen (or Congrats screen, if the saved counter is already at 10). Otherwise, it shows the Welcome screen.
- Continue, Increment, and Decrement button clicks are wired up through `AddListener` in code.
- The counter value and name are saved to PlayerPrefs immediately after every change, so progress is never lost between sessions.

## Running the Project

1. Open the project folder in Unity Hub (Unity 6.x).
2. Open `SampleScene` under `Assets/Scenes`.
3. Press Play.
4. To reset saved data and test as a new user, use **Edit → Clear All PlayerPrefs** in the Unity Editor menu.

---

<p align="center">Built by <b>Shekh Mahdi Mesbah</b></p>
