# Unity Setup Guide - Adventures of the World

This guide will walk you through setting up the Unity project for development.

---

## Prerequisites

### Required Software

1. **Unity Hub** (Latest version)
   - Download: https://unity.com/download

2. **Unity Editor 2022.3 LTS**
   - Install via Unity Hub
   - Minimum version: 2022.3.0f1
   - Recommended: Latest 2022.3.x patch

3. **IDE** (Choose one)
   - **Visual Studio Community** (Windows/Mac) - https://visualstudio.microsoft.com/
   - **JetBrains Rider** (Cross-platform, paid) - https://www.jetbrains.com/rider/
   - **Visual Studio Code** (Lightweight) - https://code.visualstudio.com/

4. **Git**
   - Download: https://git-scm.com/downloads
   - Verify installation: `git --version`

5. **Git LFS** (Large File Storage) - Optional but recommended
   - Download: https://git-lfs.github.com/
   - Initialize after install: `git lfs install`

### Platform-Specific Requirements

#### For Android Development
- **Android SDK** (installed via Unity Hub)
- **Android NDK** (installed via Unity Hub)
- **JDK** (Java Development Kit)
- Android device or emulator for testing

#### For iOS Development (macOS only)
- **Xcode** (Latest stable version)
- **iOS SDK** (included with Xcode)
- Apple Developer account (for device testing and publishing)
- Mac computer (iOS builds require macOS)

---

## Step 1: Clone the Repository

```bash
# Clone the repository
git clone https://github.com/slimjim96/adventuresoftheworld.git

# Navigate to project directory
cd adventuresoftheworld

# Verify files
ls -la
```

You should see:
- `Assets/` - Unity assets folder
- `Packages/` - Unity package manifest
- `ProjectSettings/` - Unity project settings
- `docs/` - Documentation
- `README.md` - Project readme
- `TODO.md` - Development tasks
- `.gitignore` - Git ignore rules

---

## Step 2: Install Unity 2022.3 LTS

### Using Unity Hub

1. Open **Unity Hub**
2. Go to **Installs** tab
3. Click **Install Editor**
4. Select **2022.3.x LTS** (latest patch)
5. Choose modules to install:

#### Essential Modules
- ✅ **Microsoft Visual Studio Community** (or your preferred IDE)
- ✅ **Documentation**

#### Platform Modules
- ✅ **Android Build Support**
  - ✅ Android SDK & NDK Tools
  - ✅ OpenJDK
- ✅ **iOS Build Support** (macOS only)
- ✅ **Windows Build Support** (if on Mac/Linux)
- ✅ **Mac Build Support** (if on Windows)
- ✅ **Linux Build Support** (if on Windows/Mac)

6. Click **Install** and wait for download to complete

---

## Step 3: Open Project in Unity

### First Time Setup

1. Open **Unity Hub**
2. Click **Add** → **Add project from disk**
3. Navigate to the `adventuresoftheworld` folder
4. Select the folder (it should show Unity version 2022.3.x)
5. Click **Add Project**

### Opening the Project

1. In Unity Hub, click on **Adventures of the World**
2. Unity will open and import all packages (this may take a few minutes)
3. Wait for the import process to complete

### Expected Initial State

After opening for the first time:
- **Console** may show warnings (this is normal initially)
- **Project** window shows `Assets/` folder structure
- **Hierarchy** is empty (no scenes loaded yet)
- **Inspector** is empty

---

## Step 4: Configure Unity Settings

### Project Settings

1. Go to **Edit → Project Settings**

#### Player Settings
- **Company Name**: Your name or studio
- **Product Name**: Adventures of the World
- **Version**: 0.1.0
- **Default Icon**: (will set later with game icon)

#### Resolution and Presentation
- **Fullscreen Mode**: Fullscreen Window (PC)
- **Default Screen Width**: 1920
- **Default Screen Height**: 1080
- **Run in Background**: Enabled (for debugging)

#### Quality Settings
- **V Sync Count**: Every V Blank (for 60 FPS)
- Review presets: Low, Medium, High, Ultra

#### Physics 2D
- **Gravity**: (0, -9.81) - Standard gravity
- **Default Material**: (create later for cart physics)

#### Tags and Layers
Add custom tags:
- `Player`
- `Obstacle`
- `Hazard`
- `Coin`
- `ExtraLife`
- `FinishLine`

Add custom layers:
- `Ground`
- `Obstacles`
- `Collectibles`
- `Player`
- `UI`

#### Input Manager (Legacy)
We'll use the **New Input System**, so:
1. Go to **Player Settings → Other Settings**
2. Under **Active Input Handling**, select **Both** (for compatibility)
3. Restart Unity when prompted

---

## Step 5: Install Required Packages

Unity packages are defined in `Packages/manifest.json` and should auto-install.

### Verify Installed Packages

1. Go to **Window → Package Manager**
2. Verify these packages are installed:

#### Essential Packages
- ✅ **2D Animation** (9.0.4+)
- ✅ **2D Pixel Perfect** (5.0.3+)
- ✅ **2D Sprite** (1.0.0)
- ✅ **TextMesh Pro** (3.0.6+)
- ✅ **Input System** (1.6.3+)
- ✅ **Vector Graphics** (2.0.0-preview.24+)

#### Monetization & Analytics
- ✅ **Unity Purchasing** (4.9.3+)
- ✅ **Unity Analytics** (3.8.1+)

If any are missing:
1. Click **+ (Plus)** → **Add package by name**
2. Enter package name (e.g., `com.unity.vectorgraphics`)
3. Click **Add**

---

## Step 6: Configure IDE Integration

### Visual Studio (Recommended for Windows)

1. Go to **Edit → Preferences → External Tools**
2. Set **External Script Editor** to **Visual Studio**
3. Check **Generate .csproj files for**: All options
4. Click **Regenerate project files**

### JetBrains Rider

1. Install Rider Unity plugin in Unity Hub
2. Go to **Edit → Preferences → External Tools**
3. Set **External Script Editor** to **Rider**
4. Rider should automatically detect Unity project

### Visual Studio Code

1. Install **C# extension** in VSCode
2. Install **Unity Code Snippets** extension
3. Go to **Edit → Preferences → External Tools**
4. Set **External Script Editor** to **VSCode**
5. Click **Regenerate project files**

---

## Step 7: Create Initial Scene

### Create Main Menu Scene

1. **File → New Scene**
2. Choose **2D Template** (or Basic and add 2D components)
3. Save as `Assets/Scenes/MainMenu.unity`
4. In Hierarchy, rename "Main Camera" camera settings:
   - **Projection**: Orthographic
   - **Size**: 5 (adjust later for aspect ratio)
   - **Background**: Solid color (e.g., light blue #87CEEB)

### Add to Build Settings

1. Go to **File → Build Settings**
2. Click **Add Open Scenes**
3. `MainMenu` should appear at index 0

---

## Step 8: Test the Project

### Create a Simple Test Object

1. **Right-click in Hierarchy → 2D Object → Sprite → Square**
2. Rename to "TestSprite"
3. Position at (0, 0, 0)
4. Press **Play** ▶️
5. You should see a white square in the Game view
6. Press **Play** again to stop

### Verify Everything Works

✅ No console errors
✅ Play mode works
✅ Scene saves successfully
✅ Scripts can be created and compiled

---

## Step 9: Version Control Setup

### Configure Git Settings

```bash
# Set your name and email (if not already set)
git config user.name "Your Name"
git config user.email "your.email@example.com"

# Verify settings
git config --list
```

### Unity-Specific Git Settings

Unity uses YAML for scene files. Enable text-based serialization:

1. **Edit → Project Settings → Editor**
2. Set **Asset Serialization Mode** to **Force Text**
3. Set **Line Endings For New Scripts** to **Unix** (for cross-platform)

### Enable Git LFS (Optional but Recommended)

```bash
# Initialize Git LFS
git lfs install

# Track large files
git lfs track "*.psd"
git lfs track "*.fbx"
git lfs track "*.wav"
git lfs track "*.mp3"
git lfs track "*.mov"
git lfs track "*.mp4"

# Save LFS settings
git add .gitattributes
git commit -m "Add Git LFS configuration"
```

---

## Step 10: Verify Project Structure

Your project should look like this in Unity:

```
Assets/
├── Scenes/
│   └── MainMenu.unity
├── Scripts/
│   ├── Core/
│   ├── Managers/
│   ├── UI/
│   ├── Characters/
│   ├── Obstacles/
│   ├── Collectibles/
│   └── Utilities/
├── Sprites/
│   ├── Characters/
│   ├── Environments/
│   ├── Obstacles/
│   ├── UI/
│   └── Collectibles/
├── Audio/
│   ├── Music/
│   └── SFX/
├── Prefabs/
│   ├── Characters/
│   ├── Obstacles/
│   ├── Collectibles/
│   ├── UI/
│   └── Effects/
├── Materials/
├── Animations/
├── Resources/
└── Fonts/
```

---

## Common Issues & Troubleshooting

### Issue: Unity won't open the project

**Solution**:
- Ensure you're using Unity 2022.3 LTS (not 2021 or 2023)
- Delete `Library/` folder and reopen project
- Check Unity Hub shows correct version

### Issue: Packages not installing

**Solution**:
- Go to **Window → Package Manager**
- Click refresh icon (top-right)
- Manually add packages if needed
- Check internet connection

### Issue: Scripts don't compile

**Solution**:
- Check **Console** for errors
- Ensure IDE integration is set up correctly
- **Assets → Reimport All**
- Restart Unity

### Issue: Git merge conflicts in .meta files

**Solution**:
- Accept one version of the conflict
- Delete corresponding asset and .meta file
- Re-import asset (Unity will regenerate .meta)

### Issue: Slow Unity performance

**Solution**:
- Close unnecessary windows in Unity
- Reduce **Quality** settings for editor
- Disable **Auto Refresh** (Edit → Preferences → Asset Pipeline)
- Use SSD for project storage

---

## Next Steps

Once your Unity project is set up:

1. ✅ Review [TODO.md](../TODO.md) for Month 1 tasks
2. ✅ Start with **Week 1: Project Setup & Basic Movement**
3. ✅ Create `CartController.cs` script
4. ✅ Implement auto-scrolling cart movement
5. ✅ Build your first playable prototype

---

## Useful Unity Resources

### Documentation
- **Unity Manual**: https://docs.unity3d.com/Manual/
- **Scripting Reference**: https://docs.unity3d.com/ScriptReference/
- **2D Game Development**: https://learn.unity.com/pathway/2d-game-development

### Learning Resources
- **Unity Learn**: https://learn.unity.com/
- **Brackeys YouTube**: https://www.youtube.com/user/Brackeys
- **Code Monkey YouTube**: https://www.youtube.com/c/CodeMonkeyUnity

### Community
- **Unity Forums**: https://forum.unity.com/
- **Unity Discord**: https://discord.com/invite/unity
- **Reddit r/Unity2D**: https://www.reddit.com/r/Unity2D/

---

## Support

If you encounter issues not covered here:

1. Check Unity Console for error messages
2. Search Unity Forums and documentation
3. Review project documentation in `/docs/`
4. Open an issue on GitHub

---

**You're all set! Happy developing! 🎮✨**

*Last Updated: 2025-11-22*
