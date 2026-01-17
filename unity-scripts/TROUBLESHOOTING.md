# Unity Scripts - Troubleshooting Guide

## Common Compilation Errors

### Error: "GameManager does not contain a definition for 'AddCoins'"

**Cause:** Your Unity project has an outdated version of `GameManager.cs` that's missing the `AddCoins` method.

**Fix:**
1. **Delete** the old `GameManager.cs` from your Unity project (`Assets/Scripts/Managers/GameManager.cs`)
2. **Copy** the latest version from `/unity-scripts/GameManager.cs` in this repository
3. Wait for Unity to recompile
4. Error should be resolved

### Error: "GameManager does not contain a definition for [MethodName]"

**Cause:** Similar to above - outdated script version.

**Fix:** Re-copy the latest `GameManager.cs` from this repository.

---

## Script Version Verification

**To verify you have the latest version of GameManager.cs, check it includes these methods:**

```csharp
public class GameManager : MonoBehaviour
{
    // Properties (line 12-21)
    public CharacterData selectedCharacter;
    public int currentLevel = 1;
    public int highestUnlockedLevel = 1;
    public int totalCoins = 0;
    public int currentLives = 3;
    public int maxLives = 3;

    // Methods (should have ALL of these):
    public void SelectCharacter(CharacterData character)      // Line 41
    public void LoadLevel(int levelNumber)                    // Line 57
    public void UnlockNextLevel()                             // Line 69
    public void AddCoins(int amount)                          // Line 78 ⚠️
    public bool TryUnlockCharacter(CharacterData character)   // Line 87
    public void LoseLife()                                    // Line 112
    public void ResetLives()                                  // Line 126
    public void SaveGame()                                    // Line 144
    public void LoadGame()                                    // Line 155
}
```

**Missing `AddCoins` at line 78?** → You have an old version, re-copy the file.

---

## Script Dependencies Quick Check

### Required Scripts for Basic Functionality:

| Script | Depends On | Location in Unity |
|--------|------------|-------------------|
| **GameManager.cs** | CharacterData.cs | `Assets/Scripts/Managers/` |
| **CharacterData.cs** | (none - ScriptableObject) | `Assets/Scripts/ScriptableObjects/` |
| **CartController.cs** | GameManager.cs, CharacterData.cs | `Assets/Scripts/Player/` |
| **CharacterSlot.cs** | GameManager.cs, CharacterData.cs | `Assets/Scripts/UI/` |
| **CharacterSelectManager.cs** | GameManager.cs, CharacterSlot.cs | `Assets/Scripts/UI/` |
| **LevelSlot.cs** | GameManager.cs | `Assets/Scripts/UI/` |
| **LevelManager.cs** | GameManager.cs | `Assets/Scripts/Managers/` |
| **HUDManager.cs** | GameManager.cs | `Assets/Scripts/UI/` |
| **CoinCollector.cs** | GameManager.cs | `Assets/Scripts/Collectibles/` |
| **Hazard.cs** | GameManager.cs | `Assets/Scripts/Obstacles/` |
| **GoalTrigger.cs** | LevelManager.cs | `Assets/Scripts/Obstacles/` |
| **ParallaxLayer.cs** | (none) | `Assets/Scripts/Environment/` |
| **BackgroundSpawner.cs** | (none) | `Assets/Scripts/Environment/` |

### Copy Order (to avoid dependency errors):

1. **First:** ScriptableObjects
   - CharacterData.cs
   - LevelData.cs
   - DecorationData.cs

2. **Second:** Managers
   - GameManager.cs ⚠️ (MUST be copied before most other scripts)
   - LevelManager.cs

3. **Third:** Everything else (order doesn't matter)
   - Player scripts
   - UI scripts
   - Collectibles
   - Obstacles
   - Environment

---

## Common Issues and Solutions

### Issue: "The type or namespace name 'CharacterData' could not be found"

**Fix:** Copy `CharacterData.cs` to `Assets/Scripts/ScriptableObjects/` first.

### Issue: "The name 'GameManager' does not exist in the current context"

**Fix:** Copy `GameManager.cs` to `Assets/Scripts/Managers/` and wait for compilation.

### Issue: Scripts compile but GameManager doesn't work in game

**Symptoms:**
- "GameManager is null" warnings in console
- Characters don't load in cart
- Coin collection doesn't work

**Fix:**
1. Open `StartScene` (or your first scene)
2. Create empty GameObject: Right-click Hierarchy → Create Empty
3. Name it: "GameManager"
4. Attach script: Add Component → GameManager
5. **Important:** GameManager must exist in the first scene only (it persists via `DontDestroyOnLoad`)

### Issue: Character icons/sprites not loading in UI

**Symptoms:**
- Character selection slots are blank
- Cart doesn't show character in level

**Fix:**
1. Verify you've created CharacterData assets (Right-click → Create → Game → Character Data)
2. Verify sprites are assigned in each CharacterData asset Inspector
3. Verify CharacterSelectManager has all CharacterData assets assigned in Inspector

---

## Clean Slate - Start Over

**If you're getting too many errors, start fresh:**

1. **Delete** all copied scripts from Unity `Assets/Scripts/` folder
2. **Create** folder structure (see `folder-structure.md`)
3. **Copy scripts in order** (see "Copy Order" above)
4. **Wait** for Unity to compile after each batch
5. **Fix** errors before moving to next batch

---

## Unity Compilation Tips

1. **Watch the Console** - Bottom-right corner shows compilation status
2. **Wait for spinning icon to stop** - Unity is compiling
3. **Read error messages from bottom up** - Fix the first error, others may auto-resolve
4. **One script at a time** - If getting many errors, copy/fix one script at a time
5. **Clear and Recompile** - Sometimes helps: Assets → Reimport All (takes a while)

---

## Script Update Checklist

**When updating scripts from this repository:**

- [ ] Check git for latest version (git pull)
- [ ] Delete old script from Unity
- [ ] Copy new script to Unity
- [ ] Wait for compilation
- [ ] Check Console for errors
- [ ] Test in Play mode

---

## Getting Help

**Before asking for help, provide:**

1. **Full error message** from Unity Console
2. **Which script** is showing the error (filename:line number)
3. **Unity version** (Help → About Unity)
4. **What you were doing** when error appeared

**Quick diagnostic:**

```csharp
// Add this to any script's Start() method to verify GameManager exists:
void Start()
{
    if (GameManager.Instance == null)
    {
        Debug.LogError("GameManager is NULL! Create GameManager in StartScene.");
    }
    else
    {
        Debug.Log($"GameManager found. Coins: {GameManager.Instance.totalCoins}");
    }
}
```

---

**Last Updated:** 2026-01-17
**Scripts Version:** v1.0 (Initial release)
**Compatible with:** Unity 2022.3 LTS+
