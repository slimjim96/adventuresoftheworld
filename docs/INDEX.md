# Adventures of the World - Documentation Index

**Project:** 2D Side-Scrolling Platformer Game
**Engine:** Unity 2022.3 LTS
**Timeline:** 3 months (12 weeks)
**Last Updated:** 2025-12-29

---

## 📖 How to Use This Documentation

This index organizes all documentation by **development phase**. Start at the beginning and work through sequentially, or jump to specific guides as needed.

**Quick Links:**
- [Project Planning](#-01-project-planning) - Requirements, scope, timeline
- [Unity Setup](#-02-unity-basics-weeks-1-2) - Getting started with Unity
- [Core Gameplay](#%EF%B8%8F-03-core-gameplay-weeks-3-4) - Lives, coins, obstacles
- [Procedural Generation](#-04-procedural-generation-week-5) - Dynamic levels
- [Art Assets](#-05-art-assets-weeks-6-8) - Ludo.ai graphics

---

## 📋 01. Project Planning

**Purpose:** Understand the game vision, scope, and development roadmap.

| Document | Description | Status |
|----------|-------------|--------|
| [requirements.md](01-project-planning/requirements.md) | Technical & functional requirements for all platforms | ✅ Complete |
| [project-scope.md](01-project-planning/project-scope.md) | 3-month timeline, deliverables, success criteria | ✅ Complete |
| [game-design.md](01-project-planning/game-design.md) | Gameplay mechanics, 13 characters, 5 worlds | ✅ Complete |
| [development-phases-revised.md](01-project-planning/development-phases-revised.md) | Week-by-week plan with asset-first approach | ✅ Complete |
| [TODO.md](01-project-planning/TODO.md) | Task breakdown by month (1-3) | ✅ Complete |

**Start here if:** You're beginning the project or need to understand the overall vision.

---

## 🎮 02. Unity Basics (Weeks 1-2)

**Purpose:** Set up Unity, create basic scenes, configure project settings.

| Document | Description | When to Use | Status |
|----------|-------------|-------------|--------|
| [unity-setup-guide.md](02-unity-basics/unity-setup-guide.md) | Install Unity 2022.3, IDE setup, project creation | Week 1 | ✅ Complete |
| [unity-scene-setup.md](02-unity-basics/unity-scene-setup.md) | Create MainMenu & Gameplay scenes, camera, player cart | Week 1-2 | ✅ Complete |
| [unity-configuration-checklist.md](02-unity-basics/unity-configuration-checklist.md) | Verify project settings, packages, layers, tags | Week 2 | ✅ Complete |
| [placeholder-assets-guide.md](02-unity-basics/placeholder-assets-guide.md) | Use Unity built-in sprites for prototyping | Week 2-5 | ✅ Complete |

**Start here if:** You're setting up Unity for the first time or need to configure a new project.

---

## 🕹️ 03. Core Gameplay (Weeks 3-4)

**Purpose:** Implement lives, coins, obstacles, and build first playable level.

| Document | Description | What You'll Build | Status |
|----------|-------------|-------------------|--------|
| [hud-setup-guide.md](03-week-3-4-core-gameplay/hud-setup-guide.md) | Lives HUD (hearts) & coin counter UI | LivesHUD.cs, CoinHUD.cs | ✅ Complete |
| [obstacles-setup-guide.md](03-week-3-4-core-gameplay/obstacles-setup-guide.md) | Spikes, barriers, moving obstacles, gaps | Hazard.cs, MovingObstacle.cs | ✅ Complete |
| [test-level-guide.md](03-week-3-4-core-gameplay/test-level-guide.md) | First complete level with all mechanics | FinishLine.cs, test level scene | ✅ Complete |

**Start here if:** Core mechanics (cart, jump) are working and you need to add lives/coins/obstacles.

**Prerequisites:**
- Unity project set up (Week 1-2)
- CartController.cs working (auto-scroll + jump)
- LivesManager.cs and CoinManager.cs in scene

---

## 🎲 04. Procedural Generation (Week 5)

**Purpose:** Create dynamic, replayable levels using pattern chunks and parallax backgrounds.

| Document | Description | What You'll Build | Status |
|----------|-------------|-------------------|--------|
| [procedural-generation-design.md](04-week-5-procedural/procedural-generation-design.md) | Architecture: chunks, seeding, difficulty scaling | System design overview | ✅ Complete |
| [procedural-generation-unity-setup.md](04-week-5-procedural/procedural-generation-unity-setup.md) | Step-by-step Unity implementation | ChunkData, LevelGenerator.cs | 🚧 Rough Draft |
| [parallax-background-setup.md](04-week-5-procedural/parallax-background-setup.md) | 3-layer parallax with dynamic decoration spawning | ParallaxLayer.cs, BackgroundSpawner.cs | 🚧 Rough Draft |

**Start here if:** Core gameplay is complete (Week 3-4) and you're ready for dynamic level generation.

**Prerequisites:**
- Test level working (Week 3-4)
- Understanding of ScriptableObjects
- Prefabs created: Platform, Coin, Spike

**Deliverables:**
- 30-50 ChunkData assets (Easy/Medium/Hard/Expert)
- LevelGenerator spawning random levels
- 3-layer parallax backgrounds with decorations

---

## 🎨 05. Art Assets (Weeks 6-8)

**Purpose:** Generate consistent 2D vector graphics using Ludo.ai and replace placeholder art.

| Document | Description | What's Inside | Status |
|----------|-------------|---------------|--------|
| [character-reference.md](05-art-assets/character-reference.md) | 13 playable characters (Cat, Dog, Elephant, etc.) | Personalities, colors, unlock prices | ✅ Complete |
| [ai-art-generation-guide.md](05-art-assets/ai-art-generation-guide.md) | Ludo.ai workflow for character sprites | Master prompts, batch generation | ✅ Complete |
| [ludo-ai-environmental-prompts.md](05-art-assets/ludo-ai-environmental-prompts.md) | 65+ prompts for backgrounds (trees, rocks, clouds) | Forest, Mountain, Desert, Underwater, Ocean | ✅ Complete |
| [asset-metadata-system.md](05-art-assets/asset-metadata-system.md) | DecorationData ScriptableObject design | Theme, layer, spawn rules for procedural use | ✅ Complete |

**Start here if:** Mechanics are solid with placeholder graphics, ready to generate final art.

**Prerequisites:**
- Ludo.ai account with credits (150-250 credits needed)
- Week 5 procedural system working (to understand asset needs)

**Credit Budget:**
- Week 6: Forest environment (13 assets, ~30-50 credits)
- Week 7: Mountain + Desert (26 assets, ~50-80 credits)
- Week 8: Underwater + Ocean (26 assets, ~50-80 credits)
- **Total:** 65 environmental assets (150-250 credits)
- Characters: 4-13 assets (50-100 credits)

---

## 🗺️ Development Roadmap

### Phase 1: Foundation (Weeks 1-2) ✅
- Unity setup complete
- Basic scenes created
- Cart movement + jumping working
- Camera following player (Cinemachine)

### Phase 2: Core Gameplay (Weeks 3-4) ✅
- Lives system with HUD
- Coin collection
- Obstacles (spikes, gaps)
- First complete test level

### Phase 3: Procedural Systems (Week 5) 🚧
- Pattern chunk library (30-50 chunks)
- LevelGenerator with seeded randomization
- 3-layer parallax backgrounds
- Dynamic decoration spawning

### Phase 4: Art Production (Weeks 6-8) ⏳
- Ludo.ai asset generation
- Replace all placeholder graphics
- Environmental decorations (65 assets)
- Character sprites (4-13 assets)

### Phase 5: Content & Polish (Weeks 9-12) ⏳
- Additional static levels
- Menu systems (main menu, pause, settings)
- Sound effects & music
- Build for PC/Android/iOS

---

## 📝 Notes for Returning to the Project

### If you're picking this up after a break:

1. **Review project status:**
   - Check [development-phases-revised.md](01-project-planning/development-phases-revised.md) to see current week
   - Look at [TODO.md](01-project-planning/TODO.md) for remaining tasks

2. **Test what's working:**
   - Open Unity project
   - Play test level (see [test-level-guide.md](03-week-3-4-core-gameplay/test-level-guide.md))
   - Verify all core mechanics functional

3. **Continue from where you left off:**
   - **Week 3-4:** Follow guides in [03-week-3-4-core-gameplay/](03-week-3-4-core-gameplay/)
   - **Week 5:** Start with [procedural-generation-unity-setup.md](04-week-5-procedural/procedural-generation-unity-setup.md)
   - **Week 6+:** Begin art generation using [ludo-ai-environmental-prompts.md](05-art-assets/ludo-ai-environmental-prompts.md)

---

## 🔧 Troubleshooting

### Common Issues by Phase:

**Unity Setup Issues:**
- See [unity-configuration-checklist.md](02-unity-basics/unity-configuration-checklist.md)

**Gameplay Bugs:**
- Cart not moving/jumping: [test-level-guide.md](03-week-3-4-core-gameplay/test-level-guide.md) Part 12
- Coins/obstacles not working: [obstacles-setup-guide.md](03-week-3-4-core-gameplay/obstacles-setup-guide.md) Part 10

**Procedural Generation:**
- Chunks not spawning: [procedural-generation-unity-setup.md](04-week-5-procedural/procedural-generation-unity-setup.md) Part 8
- Parallax not working: [parallax-background-setup.md](04-week-5-procedural/parallax-background-setup.md) Part 10

**Ludo.ai Art Issues:**
- Getting 3D/isometric instead of 2D: See [ludo-ai-environmental-prompts.md](05-art-assets/ludo-ai-environmental-prompts.md) negative prompts

---

## 📚 Additional Resources

### Unity Documentation
- [Unity 2022.3 LTS Manual](https://docs.unity3d.com/2022.3/Documentation/Manual/)
- [Cinemachine Documentation](https://docs.unity3d.com/Packages/com.unity.cinemachine@2.8/manual/)
- [2D Physics](https://docs.unity3d.com/2022.3/Documentation/Manual/Physics2DReference.html)

### External Tools
- [Ludo.ai](https://ludo.ai/) - AI art generation (requires account + credits)
- [Kenney Assets](https://kenney.nl/) - Free placeholder game assets

---

## 🎯 Quick Start Paths

### "I'm starting fresh"
1. [requirements.md](01-project-planning/requirements.md) → Understand the game
2. [unity-setup-guide.md](02-unity-basics/unity-setup-guide.md) → Install Unity
3. [unity-scene-setup.md](02-unity-basics/unity-scene-setup.md) → Create scenes
4. [test-level-guide.md](03-week-3-4-core-gameplay/test-level-guide.md) → Build first level

### "I have Unity set up, need to implement gameplay"
1. [hud-setup-guide.md](03-week-3-4-core-gameplay/hud-setup-guide.md) → Lives & coins UI
2. [obstacles-setup-guide.md](03-week-3-4-core-gameplay/obstacles-setup-guide.md) → Spikes & hazards
3. [test-level-guide.md](03-week-3-4-core-gameplay/test-level-guide.md) → Complete level

### "Core gameplay works, ready for procedural generation"
1. [procedural-generation-design.md](04-week-5-procedural/procedural-generation-design.md) → Understand system
2. [procedural-generation-unity-setup.md](04-week-5-procedural/procedural-generation-unity-setup.md) → Implement chunks
3. [parallax-background-setup.md](04-week-5-procedural/parallax-background-setup.md) → Add backgrounds

### "Ready to generate final art"
1. [ludo-ai-environmental-prompts.md](05-art-assets/ludo-ai-environmental-prompts.md) → Generate backgrounds
2. [character-reference.md](05-art-assets/character-reference.md) → Character specs
3. [asset-metadata-system.md](05-art-assets/asset-metadata-system.md) → Create metadata for spawning

---

## 📞 Need Help?

**General Unity Questions:**
- Check Unity's official documentation (links above)
- Search Unity Answers forum

**Project-Specific Questions:**
- Review relevant guide's troubleshooting section
- Check console errors in Unity
- Verify prerequisites are completed

**AI Art Generation:**
- [ludo-ai-environmental-prompts.md](05-art-assets/ludo-ai-environmental-prompts.md) has tested prompt templates
- Use negative prompts to avoid 3D/isometric results

---

**Happy developing!** 🚀

*This is a living document - update as project evolves.*
