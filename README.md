# Fishin’ With Your Hands

## Project Overview
*Fishin’ With Your Hands* is a Unity-based educational game that teaches sign language through a fishing-themed gameplay loop. Players interact with a simple fishing simulator and use sign language input, recognized through the Sign Language Recognizer (SLR), to complete in-game actions. When a fish is caught, the player is prompted to sign specific letters or words, progressing from letters to full words as proficiency increases. The learning experience is fully integrated into gameplay rather than relying on external references. A long-term goal of the project is a first-person, symbol-based motion system that visually guides signing through timing and pacing. The current build represents a bare-minimum playable prototype focused on core mechanics.

---

## Core Gameplay Loop
1. Start on the **Start Screen**
2. Select **Start Game**
3. Enter the fishing pond with fish and a mouse-controlled bobber
4. Bobber collides with a fish
5. Transition to the **Sign Language Recognition (SLR)** sequence
6. Successfully sign the prompted letter or word
7. Return to the pond and continue fishing

---

## Sign Language Recognition (SLR)
- Webcam input is processed by the Sign Language Recognizer
- The system:
  - Selects the highest-probability class
  - Applies a **10% accuracy threshold**
  - Filters results using an allowlist of valid words
- The player submits a sign by pressing **spacebar**
- If the recognized sign does not meet the threshold or match the required word, the attempt fails
- Players may retry indefinitely by re-recording their sign and pressing spacebar
- Player-facing feedback for failed attempts is planned but not yet implemented

---
## Help Perform Tasks
- Go to the [Kanban](https://github.com/users/druiz365/projects/3/views/1)
- Pick a task in either "Backlog" or "Ready"
- Assign yourself to the task and move it to "In Progress"
---


## Setup and Run Instructions

### Requirements
- Unity 6000.0.34f1
- Webcam access enabled
- GitHub LFS

### Project Setup
1. Clone the repository
2. Install Unity 6000.0.34f1 with build support for your platform ([Guide](https://docs.google.com/document/d/1kK3lTXnQqNJA0RKhi0DkrnnzgsVWMNk-maNsgZ1DN-k/edit?tab=t.0))
3. Open the project in Unity
4. Run

### Running the Project
1. Open the `StartScreen` scene from `Assets/Scenes`
2. Press **Play** in the Unity Editor
3. On the **Start Screen**, click **Start Game**
4. Use the mouse to control the fishing bobber
5. Enable webcam-access if prompted
6. Perform the prompted sign and press **spacebar** to submit

> **Note:** The SLR camera view is currently very zoomed in due to a known issue.

---

## Toolkit Integration Summary
- The Sign Language Recognizer (SLR) handles webcam input and sign classification
- Recognition output is evaluated against an accuracy threshold and an allowlist
- Successful recognition advances gameplay; failures require a retry
- Known integration issues include camera framing and limited feedback

---

## Common Issues / Known Bugs
- No explicit UI feedback for failed sign recognition
- UI layout is not yet optimized and may feel cluttered

---

## First Safe Task (Tiny Change)
**Example:** Add a new Unity scene and connect it to an existing scene transition.
- Create a new scene
- Link it using the same scene-loading logic used after fish capture or SLR success
- No core gameplay logic needs to be modified

This task is intended to familiarize new contributors with project structure and scene flow without risking stability.
