# Documentation

All project documentation is organized in **[INDEX.md](INDEX.md)**.

## Quick Navigation

- **[📖 INDEX.md](INDEX.md)** ← **START HERE** - Complete documentation index
- **[01-project-planning/](01-project-planning/)** - Requirements, scope, timeline
- **[02-unity-basics/](02-unity-basics/)** - Unity setup guides (Weeks 1-2)
- **[03-week-3-4-core-gameplay/](03-week-3-4-core-gameplay/)** - Lives, coins, obstacles
- **[04-week-5-procedural/](04-week-5-procedural/)** - Procedural generation & parallax
- **[05-art-assets/](05-art-assets/)** - Ludo.ai prompts & asset metadata
- **[06-unity-setup/](06-unity-setup/)** - **NEW** Scene architecture & UI setup

## Structure

```
docs/
├── INDEX.md                          ← Master documentation index
├── README.md                         ← This file
│
├── 01-project-planning/              ← Game vision & roadmap
│   ├── requirements.md
│   ├── project-scope.md
│   ├── game-design.md
│   ├── development-phases-revised.md
│   └── TODO.md
│
├── 02-unity-basics/                  ← Getting started (Weeks 1-2)
│   ├── unity-setup-guide.md
│   ├── unity-scene-setup.md
│   ├── unity-configuration-checklist.md
│   └── placeholder-assets-guide.md
│
├── 03-week-3-4-core-gameplay/        ← Core mechanics
│   ├── hud-setup-guide.md
│   ├── obstacles-setup-guide.md
│   └── test-level-guide.md
│
├── 04-week-5-procedural/             ← Dynamic levels
│   ├── procedural-generation-design.md
│   ├── procedural-generation-unity-setup.md
│   └── parallax-background-setup.md
│
├── 05-art-assets/                    ← Ludo.ai graphics (Weeks 6-9)
│   ├── ludo-ai-asset-guide.md        ← Detailed: All 80 gameplay assets
│   ├── character-reference.md
│   └── asset-metadata-system.md
│
├── 06-unity-setup/                   ← Unity scene & UI setup (NEW)
│   ├── scene-architecture-guide.md   ← ⭐ Scene flow, global cart system
│   ├── unity-basics-setup.md         ← Component setup, inspector guide
│   ├── folder-structure.md           ← Complete folder blueprint + auto-creation script
│   ├── asset-naming-conventions.md   ← File naming standards for consistency
│   └── import-checklist.md           ← Step-by-step Ludo.ai asset import workflow
│
├── ../ludo/                          ← Ludo.ai project resources
│   ├── ludo-ai-project-brief.md      ← ⭐ START HERE: Single-page reference
│   ├── prompt-templates.md           ← Copy-paste ready templates
│   ├── ui-assets-guide.md            ← 🎮 NEW: UI & platform assets (39-41 assets)
│   ├── project-concept.txt           ← Original game concept export
│   └── README.md                     ← Ludo.ai resources guide
│
└── ../unity-scripts/                ← **Ready-to-copy C# scripts (16 scripts)**
    ├── README.md                     ← Script library guide
    ├── GameManager.cs                ← Global singleton, persists across scenes
    ├── CartController.cs             ← Cart movement, character loading
    ├── CharacterData.cs              ← ScriptableObject for characters
    ├── LevelData.cs                  ← ScriptableObject for levels
    ├── DecorationData.cs             ← ScriptableObject for decorations
    ├── CharacterSlot.cs              ← Character selection UI slot
    ├── CharacterSelectManager.cs     ← Character selection scene manager
    ├── LevelSlot.cs                  ← Level selection UI slot
    ├── HUDManager.cs                 ← In-game HUD (lives, coins, pause)
    ├── StartButton.cs                ← Main menu start button
    ├── LevelManager.cs               ← Per-level logic & completion
    ├── CoinCollector.cs              ← Collectible coin script
    ├── Hazard.cs                     ← Generic obstacle/hazard
    ├── GoalTrigger.cs                ← Level finish line trigger
    ├── ParallaxLayer.cs              ← Parallax scrolling background
    └── BackgroundSpawner.cs          ← Procedural decoration spawner
```

---

**Always start with [INDEX.md](INDEX.md) for organized navigation.**
