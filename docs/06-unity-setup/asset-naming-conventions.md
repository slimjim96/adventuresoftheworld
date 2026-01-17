# Asset Naming Conventions

**Consistent file naming standards for Adventures of the World**

Following these conventions ensures assets are easy to find, organize, and maintain in Unity.

---

## 🎯 General Rules

1. **Use PascalCase** for all asset names (FirstLetterCapitalized)
2. **No spaces** - Use underscores `_` to separate words
3. **Include theme prefix** when applicable
4. **Include layer suffix** for environment assets (Far, Mid, Near)
5. **Number variations** starting from 01 (not 1)
6. **Be descriptive but concise** (max 30 characters)

---

## 🎨 Sprite Naming

### Characters

**Format:** `[CharacterName]_[Pose].png`

**Examples:**
```
Cat_Riding.png
Dog_Riding.png
Elephant_Riding.png
Bear_Riding.png
Unicorn_Riding.png
Fox_Riding.png
Duck_Riding.png
Lion_Riding.png
Bunny_Riding.png
Mouse_Riding.png
Fish_Riding.png
Snowman_Riding.png
Dragon_Riding.png
Cart_Wooden.png
```

### Character Icons

**Format:** `[CharacterName]_Icon.png`

**Examples:**
```
Cat_Icon.png
Dog_Icon.png
Elephant_Icon.png
Cart_Icon.png
```

### Environment Decorations

**Format:** `[Theme]_[Object]_[Layer]_[Number].png`

**Examples:**
```
Forest_Tree_Mid_01.png
Forest_Tree_Mid_02.png
Forest_Bush_Near_01.png
Forest_Mountain_Far_01.png
Forest_Cloud_Far_01.png

Mountain_Peak_Far_01.png
Mountain_Rock_Mid_01.png
Mountain_Snow_Near_01.png

Desert_Cactus_Mid_01.png
Desert_Dune_Far_01.png
Desert_Skull_Near_01.png

Underwater_Coral_Mid_01.png
Underwater_Seaweed_Near_01.png
Underwater_Submarine_Far_01.png

Ocean_Wave_Near_01.png
Ocean_Ship_Far_01.png
Ocean_Jellyfish_Mid_01.png
```

### Platform Borders

**Format:** `[Theme]_Border_[Variation].png`

**Examples:**
```
Forest_Border_Vines.png
Forest_Border_Moss.png
Forest_Border_Mushroom.png

Mountain_Border_Stone.png
Mountain_Border_Snow.png
Mountain_Border_Ice.png

Desert_Border_Sand.png
Desert_Border_Rock.png
Desert_Border_Cactus.png

Underwater_Border_Coral.png
Underwater_Border_Seaweed.png
Underwater_Border_Bubbles.png

Ocean_Border_Waves.png
Ocean_Border_Shells.png
Ocean_Border_Rope.png
```

### UI Elements

**Format:** `[Type]_[Description]_[Size].png` or `[Type]_[Style].png`

**Examples:**
```
Button_Wooden_Small.png
Button_Wooden_Large.png
Button_Round.png
Button_Play.png
Button_Settings.png

Panel_Wooden.png
Panel_Stone.png
Frame_Decorative.png

WelcomeScreen_Desktop.png
WelcomeScreen_Mobile.png
```

### Obstacles & Collectibles

**Format:** `[ObjectName]_[Variation].png`

**Examples:**
```
Spike_01.png
Spike_02.png
Rock_Small.png
Rock_Large.png
Gap_Pit.png
Coin_Gold.png
PowerUp_Speed.png
```

---

## 🎮 Prefab Naming

### Format: `[ObjectName].prefab`

**Examples:**
```
Cart.prefab
Coin.prefab
Spike.prefab
Rock.prefab

CharacterSlot.prefab
LevelSlot.prefab
HUD.prefab

Forest_Tree_Mid_01.prefab
Mountain_Rock_Mid_01.prefab
Desert_Cactus_Mid_01.prefab
```

**Note:** Prefab names usually match their sprite names (without file extension)

---

## 📦 ScriptableObject Naming

### Character Data

**Format:** `[CharacterName]_Data.asset`

**Examples:**
```
Cat_Data.asset
Dog_Data.asset
Elephant_Data.asset
Bear_Data.asset
Unicorn_Data.asset
Fish_Data.asset
Fox_Data.asset
Duck_Data.asset
Lion_Data.asset
Bunny_Data.asset
Mouse_Data.asset
Snowman_Data.asset
Dragon_Data.asset
```

### Level Data

**Format:** `Level[Number]_Config.asset`

**Examples:**
```
Level01_Config.asset
Level02_Config.asset
Level03_Config.asset
...
Level12_Config.asset
```

### Decoration Data

**Format:** `[Theme]_[Object]_[Number]_Data.asset`

**Examples:**
```
Forest_Tree_01_Data.asset
Mountain_Peak_01_Data.asset
Desert_Cactus_01_Data.asset
```

---

## 🎬 Scene Naming

### Format: `[SceneName].unity` or `Level[Number]_[Theme].unity`

**Examples:**
```
StartScene.unity
CharacterSelectScene.unity
LevelSelectScene.unity

Level01_Forest.unity
Level02_Forest.unity
Level03_Forest.unity
Level04_Mountain.unity
Level05_Mountain.unity
Level06_Mountain.unity
Level07_Desert.unity
Level08_Desert.unity
Level09_Desert.unity
Level10_Underwater.unity
Level11_Underwater.unity
Level12_Ocean.unity
```

**Alternative (simpler):**
```
Level01.unity
Level02.unity
...
Level12.unity
```

---

## 📝 Script Naming

### Format: `[ComponentName].cs`

**Examples:**
```
GameManager.cs
CartController.cs
CharacterData.cs
LevelManager.cs
ParallaxLayer.cs
BackgroundSpawner.cs
CharacterSlot.cs
HUDManager.cs
```

**Rules:**
- Match class name exactly
- Use PascalCase
- Be descriptive of function
- Avoid abbreviations unless common (HUD is okay)

---

## 🎵 Audio Naming (Future)

### Music

**Format:** `[SceneOrTheme]_Theme.mp3`

**Examples:**
```
Menu_Theme.mp3
Forest_Theme.mp3
Mountain_Theme.mp3
Desert_Theme.mp3
Underwater_Theme.mp3
Ocean_Theme.mp3
```

### Sound Effects

**Format:** `[Action]_[Variation].wav`

**Examples:**
```
Jump_01.wav
Jump_02.wav
Coin_Collect.wav
Death.wav
Button_Click.wav
Hurt_01.wav
LevelComplete.wav
```

---

## 📁 Folder Naming

### Format: PascalCase, descriptive

**Examples:**
```
Scripts/
Scenes/
Prefabs/
Sprites/
Data/
Audio/
Fonts/
Materials/

Scripts/Managers/
Scripts/Player/
Scripts/UI/
Scripts/Collectibles/
Scripts/Obstacles/
Scripts/Environment/

Sprites/Characters/
Sprites/Characters/Animals/
Sprites/Characters/Cart/

Sprites/Environment/Forest/
Sprites/Environment/Forest/Far/
Sprites/Environment/Forest/Mid/
Sprites/Environment/Forest/Near/

Data/Characters/
Data/Levels/
Data/Decorations/
```

---

## ✅ Naming Checklist

When naming a new asset, ask:

- [ ] Is it PascalCase?
- [ ] Does it use underscores instead of spaces?
- [ ] Does it include theme prefix (if environment asset)?
- [ ] Does it include layer suffix (Far/Mid/Near for backgrounds)?
- [ ] Are variations numbered starting from 01?
- [ ] Is it descriptive but under 30 characters?
- [ ] Does it match the naming pattern for its category?
- [ ] Will it sort logically in file lists?

---

## 🔍 Finding Assets Quickly

**With consistent naming, you can:**

1. **Search by theme:**
   - Type "Forest_" to find all forest assets
   - Type "Mountain_" to find all mountain assets

2. **Search by layer:**
   - Type "_Far_" to find all far background assets
   - Type "_Mid_" to find all mid-layer assets
   - Type "_Near_" to find all near foreground assets

3. **Search by type:**
   - Type "_Icon" to find all character icons
   - Type "_Border_" to find all platform borders
   - Type "Level" to find all level-related assets

4. **Search by character:**
   - Type "Cat_" to find all cat-related assets
   - Type "Dog_" to find all dog assets

---

## 🎨 Ludo.ai File Naming

**When downloading from Ludo.ai:**

1. Ludo.ai generates names like: `image_1234567890.png`
2. **Immediately rename** using conventions above
3. Rename BEFORE importing to Unity (easier to track)

**Renaming workflow:**
1. Download all assets to a folder
2. Rename each file according to conventions
3. Organize into category subfolders
4. Import entire folder structure to Unity

---

## 📊 Naming Examples by Category

### Complete Character Set
```
Characters/Animals/
  Cat_Riding.png
  Dog_Riding.png
  Elephant_Riding.png
  Bear_Riding.png
  Unicorn_Riding.png
  Fish_Riding.png
  Fox_Riding.png
  Duck_Riding.png
  Lion_Riding.png
  Bunny_Riding.png
  Mouse_Riding.png
  Snowman_Riding.png
  Dragon_Riding.png

Characters/Cart/
  Cart_Wooden.png

UI/Icons/
  Cat_Icon.png
  Dog_Icon.png
  Elephant_Icon.png
  (... 13 total icons)
```

### Complete Forest Theme
```
Environment/Forest/Far/
  Forest_Mountain_Far_01.png
  Forest_Cloud_Far_01.png
  Forest_Cloud_Far_02.png

Environment/Forest/Mid/
  Forest_Tree_Mid_01.png
  Forest_Tree_Mid_02.png
  Forest_Tree_Mid_03.png
  Forest_Hill_Mid_01.png
  Forest_Hill_Mid_02.png

Environment/Forest/Near/
  Forest_Bush_Near_01.png
  Forest_Bush_Near_02.png
  Forest_Rock_Near_01.png
  Forest_Grass_Near_01.png
  Forest_Flower_Near_01.png

Borders/Forest/
  Forest_Border_Vines.png
  Forest_Border_Moss.png
  Forest_Border_Mushroom.png
```

---

## 🔄 Renaming Existing Assets

**If you need to rename assets already in Unity:**

1. **Select asset** in Project window
2. **Right-click → Rename** (or F2)
3. **Enter new name** following conventions
4. **Unity automatically updates** all references

**Warning:** Avoid renaming:
- Assets referenced in scenes (breaks references)
- ScriptableObjects with data (can lose data)

Always prefer renaming BEFORE importing to Unity.

---

## 📚 Related Documentation

- **Folder Structure:** `/docs/06-unity-setup/folder-structure.md`
- **Import Workflow:** Next section in this guide
- **Asset Guide:** `/docs/05-art-assets/ludo-ai-asset-guide.md`

---

**Last Updated:** 2026-01-17
**For:** Adventures of the World - Unity 2022.3 LTS
**Purpose:** Maintain consistent, organized asset naming
