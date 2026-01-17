# Quick Fix: "The name 'GameManager' does not exist in the current context"

## What This Error Means

When you see **"The name 'GameManager' does not exist"** in other scripts like CartController.cs, it means:

❌ **GameManager.cs has a compilation error**
→ Unity can't compile the GameManager class
→ So other scripts can't find it

---

## How to Fix

### Step 1: Check Unity Console for GameManager Errors

1. **Open Console** in Unity (Window → General → Console)
2. **Look for RED errors** (not warnings)
3. **Find errors from GameManager.cs** specifically
4. **Click on the error** to see what line it's on

**Common errors to look for:**
- Missing semicolon `;`
- Mismatched braces `{` `}`
- Typo in method name or variable
- Missing `using UnityEngine;` at top
- Accidentally deleted a method that other scripts need

---

### Step 2: Verify GameManager.cs Structure

**Your GameManager.cs should look like this at the top:**

```csharp
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // ... rest of code
}
```

**Check for these common mistakes:**

❌ **DON'T add a namespace:**
```csharp
// WRONG - don't do this
namespace AdventuresOfTheWorld
{
    public class GameManager : MonoBehaviour { }
}
```

❌ **DON'T make it private:**
```csharp
// WRONG - must be public
class GameManager : MonoBehaviour { }
```

✅ **CORRECT:**
```csharp
// RIGHT - no namespace, public class
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ...
}
```

---

### Step 3: Common Fix - Replace with Fresh Copy

**If you modified GameManager and broke it:**

1. **Delete** your modified `GameManager.cs` from Unity
2. **Re-copy** the original from repository `/unity-scripts/GameManager.cs`
3. **Paste** into Unity `Assets/Scripts/Managers/`
4. **Wait** for recompile
5. **Check Console** - GameManager errors should be gone
6. **CartController error** should also disappear

---

## Debugging Checklist

**Follow this checklist to find the issue:**

- [ ] Open Unity Console (Window → General → Console)
- [ ] Clear all warnings (right-click → Clear)
- [ ] Look for RED errors only
- [ ] Find error message mentioning "GameManager.cs"
- [ ] Double-click error to open script at problem line
- [ ] Fix the syntax error (missing `;`, `}`, etc.)
- [ ] Save script
- [ ] Wait for Unity to recompile
- [ ] Check if "GameManager does not exist" error is gone

---

## If GameManager Has NO Errors in Console

**But CartController still can't find it:**

### Check 1: Is GameManager.cs in the Assets folder?

**Unity only compiles scripts in:**
- ✅ `Assets/Scripts/Managers/GameManager.cs`
- ❌ `/unity-scripts/GameManager.cs` (repository, not Unity)

**Fix:** Copy from repository to Unity project.

### Check 2: Does the class name match filename?

**Must match exactly:**
- File: `GameManager.cs`
- Class: `public class GameManager`

**Case sensitive!**

### Check 3: Did you add a namespace?

```csharp
// If you have this, REMOVE IT:
namespace Something
{
    public class GameManager : MonoBehaviour { }
}

// Should be this:
using UnityEngine;

public class GameManager : MonoBehaviour { }
```

### Check 4: Force Unity to recompile

1. Click into Unity window (give it focus)
2. Or: Assets → Refresh
3. Or: Assets → Reimport All (slow but thorough)

---

## Copy-Paste This EXACT GameManager.cs

**If you want a clean slate, use this EXACT code:**

```csharp
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Player Selection")]
    public CharacterData selectedCharacter;

    [Header("Level Progress")]
    public int currentLevel = 1;
    public int highestUnlockedLevel = 1;

    [Header("Game Stats")]
    public int totalCoins = 0;
    public int currentLives = 3;
    public int maxLives = 3;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("GameManager initialized");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SelectCharacter(CharacterData character)
    {
        if (character != null && character.isUnlocked)
        {
            selectedCharacter = character;
            Debug.Log($"Character selected: {character.characterName}");
        }
        else
        {
            Debug.LogWarning("Character is locked or null!");
        }
    }

    public void LoadLevel(int levelNumber)
    {
        currentLevel = levelNumber;
        string sceneName = $"Level{levelNumber:00}";
        Debug.Log($"Loading level: {sceneName}");
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void UnlockNextLevel()
    {
        highestUnlockedLevel = Mathf.Max(highestUnlockedLevel, currentLevel + 1);
        Debug.Log($"Level {highestUnlockedLevel} unlocked!");
    }

    public void AddCoins(int amount)
    {
        totalCoins += amount;
        Debug.Log($"Coins collected: {amount}. Total: {totalCoins}");
    }

    public bool TryUnlockCharacter(CharacterData character)
    {
        if (character.isUnlocked)
        {
            Debug.Log($"{character.characterName} already unlocked");
            return true;
        }

        if (totalCoins >= character.unlockCost)
        {
            totalCoins -= character.unlockCost;
            character.isUnlocked = true;
            Debug.Log($"{character.characterName} unlocked for {character.unlockCost} coins!");
            return true;
        }
        else
        {
            Debug.Log($"Not enough coins. Need {character.unlockCost}, have {totalCoins}");
            return false;
        }
    }

    public void LoseLife()
    {
        currentLives--;
        Debug.Log($"Life lost. Lives remaining: {currentLives}");

        if (currentLives <= 0)
        {
            GameOver();
        }
    }

    public void ResetLives()
    {
        currentLives = maxLives;
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelSelectScene");
    }

    public void SaveGame()
    {
        Debug.Log("Game saved (not yet implemented)");
    }

    public void LoadGame()
    {
        Debug.Log("Game loaded (not yet implemented)");
    }
}
```

**Save this as `GameManager.cs` in `Assets/Scripts/Managers/`**

---

## Still Not Working?

**Share these details:**

1. **Full error message** from Unity Console (copy-paste exact text)
2. **First 10 lines** of your GameManager.cs (to check structure)
3. **Unity version** (Help → About Unity)
4. **Where did you put GameManager.cs?** (full path in Unity Project window)

---

**Last Updated:** 2026-01-17
**For:** Unity 2022.3 LTS
