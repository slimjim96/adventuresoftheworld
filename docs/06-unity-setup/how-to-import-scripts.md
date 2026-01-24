# How to Import Scripts into Unity

## The Problem

The scripts in `/unity-scripts/` are **template files in the repository**. They're not automatically in your Unity project - you need to **copy them manually**.

---

## Solution: Copy Scripts to Unity

### Option 1: Copy All Scripts at Once (Recommended)

**1. Open your Unity project location in file explorer:**
- Windows: `C:/Users/[YourName]/[UnityProjects]/AdventuresOfTheWorld/Assets/Scripts/`
- Mac: `~/UnityProjects/AdventuresOfTheWorld/Assets/Scripts/`

**2. Create folder structure** (if it doesn't exist):
```
Assets/
└── Scripts/
    ├── Managers/
    ├── Player/
    ├── UI/
    ├── Collectibles/
    ├── Obstacles/
    ├── Environment/
    └── ScriptableObjects/
```

**3. Copy scripts from repository to Unity:**

From repository `/unity-scripts/` → To Unity `Assets/Scripts/`:

| Repository File | Copy To Unity Folder |
|----------------|---------------------|
| GameManager.cs | `Assets/Scripts/Managers/` |
| LevelManager.cs | `Assets/Scripts/Managers/` |
| CartController.cs | `Assets/Scripts/Player/` |
| CharacterData.cs | `Assets/Scripts/ScriptableObjects/` |
| LevelData.cs | `Assets/Scripts/ScriptableObjects/` |
| DecorationData.cs | `Assets/Scripts/ScriptableObjects/` |
| StartButton.cs | `Assets/Scripts/UI/` |
| CharacterSlot.cs | `Assets/Scripts/UI/` |
| CharacterSelectManager.cs | `Assets/Scripts/UI/` |
| LevelSlot.cs | `Assets/Scripts/UI/` |
| HUDManager.cs | `Assets/Scripts/UI/` |
| CoinCollector.cs | `Assets/Scripts/Collectibles/` |
| Hazard.cs | `Assets/Scripts/Obstacles/` |
| GoalTrigger.cs | `Assets/Scripts/Obstacles/` |
| ParallaxLayer.cs | `Assets/Scripts/Environment/` |
| BackgroundSpawner.cs | `Assets/Scripts/Environment/` |

**4. Return to Unity** - it will auto-compile the scripts

**5. Check Console** (Window → General → Console) - should be no errors

---

## Option 2: Copy One Script at a Time

**For testing or if you're getting errors:**

1. **Start with ScriptableObjects** (no dependencies):
   - CharacterData.cs
   - LevelData.cs
   - DecorationData.cs

2. **Then GameManager** (required by most scripts):
   - GameManager.cs

3. **Then everything else** (order doesn't matter)

---

## Verify Scripts Imported Correctly

### Check 1: Scripts Show in Project Window

In Unity:
- Open Project window (bottom panel)
- Navigate to `Assets/Scripts/Managers/`
- You should see `GameManager.cs` with C# script icon

### Check 2: Scripts Available in Add Component

1. Select any GameObject in Hierarchy
2. Click "Add Component" in Inspector
3. Search for "GameManager"
4. Should appear in search results

### Check 3: No Compilation Errors

- Open Console (Window → General → Console)
- Should see "All compiler errors have to be fixed" if there are errors
- Should see nothing or just warnings if successful

---

## Why "Hard to Import"?

**Common issues:**

### Issue 1: Scripts are only in repository, not Unity
**Symptom:** Can't find GameManager, CharacterData, etc. in Unity
**Fix:** Copy files from `/unity-scripts/` to `Assets/Scripts/`

### Issue 2: Wrong folder location
**Symptom:** Scripts compile but don't follow organization
**Fix:** Use the folder structure above (Managers/, Player/, UI/, etc.)

### Issue 3: Missing dependencies
**Symptom:** "The type or namespace name 'GameManager' could not be found"
**Fix:** Copy `GameManager.cs` first, then other scripts

### Issue 4: Unity not auto-compiling
**Symptom:** Files copied but Unity doesn't recognize them
**Fix:**
- Click into Unity window to give it focus
- Or: Assets → Refresh
- Or: Assets → Reimport All (slow but thorough)

---

## How Unity Finds Classes (No Namespaces Needed)

**Unity automatically finds all C# classes if:**

✓ File is in `Assets/` folder or subfolders
✓ File extension is `.cs`
✓ Class name matches filename (e.g., `GameManager.cs` contains `public class GameManager`)
✓ No compilation errors

**You DON'T need:**
- ❌ Namespaces
- ❌ Import statements (except for Unity libraries like `using UnityEngine;`)
- ❌ Manual registration
- ❌ Project settings configuration

**Example - this works perfectly:**

```csharp
// GameManager.cs (no namespace)
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    // ...
}
```

```csharp
// CartController.cs (can reference GameManager directly)
using UnityEngine;

public class CartController : MonoBehaviour
{
    void Start()
    {
        // No namespace needed, just use it
        GameManager.Instance.LoadLevel(1);
    }
}
```

---

## Public Methods for Unity Events (IMPORTANT)

**Unity requires methods to be `public` to appear in the Inspector.**

When assigning methods to UI events (like Button.onClick) through the Unity Inspector, only `public` methods are visible. This is a Unity standard.

### The Rule

| Access Modifier | Visible in Inspector? | Can Use with AddListener()? |
|-----------------|----------------------|----------------------------|
| `public void MyMethod()` | ✅ Yes | ✅ Yes |
| `void MyMethod()` (private) | ❌ No | ✅ Yes |
| `private void MyMethod()` | ❌ No | ✅ Yes |

### Why This Matters

**Two ways to wire up button clicks:**

**Option 1: Via Inspector (requires `public`)**
```csharp
// This method MUST be public to show up in Button.onClick dropdown
public void OnStartClicked()
{
    SceneManager.LoadScene("NextScene");
}
```

**Option 2: Via Code (works with private)**
```csharp
void Start()
{
    // AddListener works with private methods
    button.onClick.AddListener(OnStartClicked);
}

void OnStartClicked()  // Can be private when using AddListener
{
    SceneManager.LoadScene("NextScene");
}
```

### Our Convention

**All UI event handler methods should be `public`** for flexibility:

```csharp
/// <summary>
/// Handle button click.
/// Public so it can be assigned to Button.onClick in the Unity Inspector.
/// </summary>
public void OnStartClicked()
{
    // ...
}
```

This allows you to:
- Wire up events in the Inspector (drag & drop)
- OR use AddListener() in code
- OR both (Inspector assignment + code reference)

### Methods That Should Be Public

| Script | Method | Purpose |
|--------|--------|---------|
| StartButton | `OnStartClicked()` | Start button → load character select |
| CharacterSelectManager | `OnConfirmButtonClicked()` | Confirm → load level select |
| CharacterSelectManager | `OnBackButtonClicked()` | Back → return to start menu |
| CharacterSlot | `OnSlotClicked()` | Character slot → select/unlock |
| LevelSlot | `OnLevelClicked()` | Level slot → load level |
| HUDManager | `TogglePause()` | Pause button → toggle pause |
| HUDManager | `Resume()` | Resume button → unpause |
| HUDManager | `RestartLevel()` | Restart button → reload level |
| HUDManager | `ReturnToLevelSelect()` | Return button → level select |

### Quick Fix for "Method Not Showing in Inspector"

If a method doesn't appear in Button.onClick dropdown:

1. Check if the method is `public`
2. Change `void MyMethod()` to `public void MyMethod()`
3. Save the script
4. Return to Unity (it will recompile)
5. Method should now appear in the dropdown

---

## Quick Setup Script

**If you want to automate copying (Bash/Terminal):**

```bash
# From repository root
cd /home/user/adventuresoftheworld

# Copy all scripts to Unity project (adjust path to your Unity project)
UNITY_PROJECT="/path/to/your/UnityProject"

# Create folders
mkdir -p "$UNITY_PROJECT/Assets/Scripts/Managers"
mkdir -p "$UNITY_PROJECT/Assets/Scripts/Player"
mkdir -p "$UNITY_PROJECT/Assets/Scripts/UI"
mkdir -p "$UNITY_PROJECT/Assets/Scripts/Collectibles"
mkdir -p "$UNITY_PROJECT/Assets/Scripts/Obstacles"
mkdir -p "$UNITY_PROJECT/Assets/Scripts/Environment"
mkdir -p "$UNITY_PROJECT/Assets/Scripts/ScriptableObjects"

# Copy scripts
cp unity-scripts/GameManager.cs "$UNITY_PROJECT/Assets/Scripts/Managers/"
cp unity-scripts/LevelManager.cs "$UNITY_PROJECT/Assets/Scripts/Managers/"
cp unity-scripts/CartController.cs "$UNITY_PROJECT/Assets/Scripts/Player/"
cp unity-scripts/CharacterData.cs "$UNITY_PROJECT/Assets/Scripts/ScriptableObjects/"
cp unity-scripts/LevelData.cs "$UNITY_PROJECT/Assets/Scripts/ScriptableObjects/"
cp unity-scripts/DecorationData.cs "$UNITY_PROJECT/Assets/Scripts/ScriptableObjects/"
cp unity-scripts/StartButton.cs "$UNITY_PROJECT/Assets/Scripts/UI/"
cp unity-scripts/CharacterSlot.cs "$UNITY_PROJECT/Assets/Scripts/UI/"
cp unity-scripts/CharacterSelectManager.cs "$UNITY_PROJECT/Assets/Scripts/UI/"
cp unity-scripts/LevelSlot.cs "$UNITY_PROJECT/Assets/Scripts/UI/"
cp unity-scripts/HUDManager.cs "$UNITY_PROJECT/Assets/Scripts/UI/"
cp unity-scripts/CoinCollector.cs "$UNITY_PROJECT/Assets/Scripts/Collectibles/"
cp unity-scripts/Hazard.cs "$UNITY_PROJECT/Assets/Scripts/Obstacles/"
cp unity-scripts/GoalTrigger.cs "$UNITY_PROJECT/Assets/Scripts/Obstacles/"
cp unity-scripts/ParallaxLayer.cs "$UNITY_PROJECT/Assets/Scripts/Environment/"
cp unity-scripts/BackgroundSpawner.cs "$UNITY_PROJECT/Assets/Scripts/Environment/"

echo "Scripts copied! Open Unity and wait for auto-compile."
```

---

## Summary

**Answer to your question:**
- ✅ **NO namespaces needed** - they would make it harder, not easier
- ✅ Unity finds classes automatically in `Assets/` folder
- ✅ All our scripts are designed to work **without namespaces**

**The actual issue:**
- The scripts need to be **physically copied** from `/unity-scripts/` (repository) to your Unity project's `Assets/Scripts/` folder
- Once copied, Unity auto-compiles them and they're available everywhere

**Next step:**
- Copy the scripts using Option 1 above
- Wait for Unity to compile
- Check Console for any errors
- Start using them!

Let me know if you're still having trouble importing after copying the files!
