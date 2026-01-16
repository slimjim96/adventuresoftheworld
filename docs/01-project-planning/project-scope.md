# Adventures of the World - Project Scope Document

## 1. Project Summary

### Project Name
**Adventures of the World**

### Project Type
2D Side-Scrolling Platformer Game

### Project Vision
Create an engaging, casual mobile and PC game where players guide adorable animal characters through diverse world environments, collecting coins and overcoming obstacles in an auto-scrolling cart adventure.

### Target Audience
- Casual gamers (ages 8+)
- Mobile gaming enthusiasts
- Fans of endless runner/platformer games
- Players who enjoy score-based challenges

### Development Timeline
**Total Duration**: 3 months (12 weeks)
**Development Model**: Iterative releases with playable builds every 2-3 weeks
**Target Release**: End of Q1 2026

## 2. Project Objectives

### Primary Objectives
1. Deliver a polished, fun, and addictive side-scrolling platformer
2. Create a game that works seamlessly on PC, Android, and iOS
3. Implement a progression system that encourages replay value
4. Build a foundation for future content updates and monetization
5. Achieve successful launch on Google Play and Apple App Store

### Success Criteria
- Complete game with 5 themed worlds (15-20 levels total)
- Smooth 60 FPS performance on PC, 30+ FPS on mobile
- Positive playtester feedback (> 7/10 average rating)
- Successful builds for all target platforms
- App store submissions ready by end of 3-month period

## 3. Scope Breakdown

### 3.1 Core Gameplay (In Scope)

#### Auto-Scrolling Mechanics
- Cart moves automatically from left to right at constant speed
- Player cannot control horizontal movement (only jump)
- Speed may increase slightly with level progression
- Cart physics: momentum, gravity, bounce on landing

#### Jump System
- Single jump mechanic (press to jump)
- Fixed jump height and arc (physics-based)
- Jump while in air = no effect (no double jump in v1.0)
- Responsive controls (< 50ms input lag)

#### Obstacle Types
1. **Gaps**: Empty spaces in the track (must jump to clear)
2. **Barriers**: Low obstacles (must jump over)
3. **Hazards**: Spikes, rocks, pitfalls (lose life on contact)
4. **Moving Obstacles**: Platforms, pendulums (later levels)

#### Collectibles
- **Coins**: Scattered throughout levels, worth points
- **Extra Lives**: Rare pickups, add +1 life
- **Power-ups (optional)**: Speed boost, shield, magnet (future)

#### Lives System
- Start each level with 3 lives
- Lose 1 life on collision with hazard
- Extra lives can be collected or purchased
- Game over when lives reach 0 (restart level)

### 3.2 Visual Design (In Scope)

#### Art Style
- **Theme**: Hand-Painted 2.5D (Rayman Legends inspired), whimsical, family-friendly
- **Graphics**: 2D sprites with gradient shading and painterly textures
- **Color Palette**: Vibrant, distinct per environment with soft lighting effects
- **Character Design**: Cute animal characters in riding pose (cart+animal separation)

**Art Style Evolution Note (December 2025):**
The visual style evolved from flat cartoon to Hand-Painted 2.5D with gradients to achieve a more polished, sophisticated aesthetic while maintaining family-friendly appeal. See `docs/05-art-assets/ludo-ai-complete-asset-guide-2.5D.md` for details.

#### Characters (In Scope)
**13 playable animal characters** (cart and animals are separate assets):
1. **Cat** 🐱 - Curious and agile (default, FREE)
2. **Lion** 🦁 - Brave and bold (1500 coins)
3. **Bunny** 🐰 - Quick and energetic (700 coins)
4. **Duck** 🦆 - Cheerful and fun (600 coins)
5. **Mouse** 🐭 - Small and clever (500 coins)
... *and 8 more* (Dog, Elephant, Bear, Unicorn, Fish, Fox, Snowman, Dragon)

*Note*: Characters are cosmetic only (no gameplay differences in v1.0). Cart is reusable across all characters.

#### Environments (5 Themed Worlds)
1. **Forest** (Levels 1-3)
   - Green foliage, trees, wooden obstacles
   - Beginner-friendly, tutorial-like

2. **Mountain Range** (Levels 4-6)
   - Rocky terrain, snow caps, cliffs
   - Medium difficulty, gaps increase

3. **Desert** (Levels 7-9)
   - Sand dunes, cacti, ancient ruins
   - Higher speed, more hazards

4. **Underwater River** (Levels 10-12)
   - Flowing water, bubbles, aquatic plants
   - Unique visual style, buoyancy feel

5. **Ocean** (Levels 13-15)
   - Waves, boats, seagulls, islands
   - Highest difficulty, all obstacle types

#### UI/UX Design
- Clean, minimal interface
- Large touch targets for mobile
- Consistent color scheme across menus
- Smooth transitions and animations

### 3.3 Audio Design (In Scope)

#### Music
- Background music per environment (5 tracks minimum)
- Menu music (1 track)
- Upbeat, thematic, looping tracks
- **Source**: Royalty-free/Creative Commons (placeholder)

#### Sound Effects
- Jump sound
- Coin collection
- Collision/death sound
- Level complete jingle
- UI button clicks
- Extra life pickup
- **Source**: Royalty-free libraries (placeholder)

### 3.4 Progression System (In Scope)

#### Level Progression
- Linear unlocking (complete Level 1 to unlock Level 2, etc.)
- 3-star rating per level based on:
  - Score achieved
  - Coins collected
  - Deaths/lives remaining

#### Scoring System
- **Distance traveled**: 1 point per meter
- **Coins collected**: 10 points per coin
- **Time bonus**: Points for fast completion
- **Perfect run bonus**: No deaths = 500 bonus points

#### Upgrade Shop
- Spend collected coins on:
  - **Extra Lives**: Purchase life packs (e.g., 3 lives for 100 coins)
  - **Character Unlocks**: Unlock new animals (500-1000 coins each)
  - **Cart Skins**: Visual upgrades (cosmetic)
  - **Continue Tokens**: Restart from checkpoint (future)

### 3.5 Monetization (In Scope)

#### Free-to-Play Model
- Game is free to download and play
- All content accessible without payment
- IAP provides convenience, not advantage

#### In-App Purchases
1. **Coin Bundles**:
   - Small Pack: 500 coins - $0.99
   - Medium Pack: 1,500 coins - $2.99
   - Large Pack: 5,000 coins - $7.99

2. **Character Bundles**:
   - Unlock all animals - $4.99

3. **Premium Upgrades** (optional):
   - Remove ads (if ads implemented) - $2.99
   - VIP cart skin bundle - $3.99

*Note*: Ensure no pay-to-win; all items earnable through gameplay

### 3.6 Platform-Specific Features (In Scope)

#### PC Features
- Keyboard controls (Space/Up Arrow to jump, ESC to pause)
- Mouse navigation in menus
- Higher resolution support (1080p, 1440p, 4K)
- Windowed and fullscreen modes

#### Mobile Features (Android & iOS)
- Touch controls (tap anywhere to jump)
- On-screen UI buttons (pause, shop)
- Portrait or landscape orientation (recommend landscape)
- Haptic feedback on jump/collision
- Platform-specific optimizations

### 3.7 Data & Persistence (In Scope)

#### Save System
- **Local saves** using Unity PlayerPrefs or JSON
- Auto-save after level completion
- Save data includes:
  - Progress (unlocked levels)
  - High scores per level
  - Total coins collected
  - Selected character
  - Settings (volume, etc.)

#### Analytics (Basic)
- Unity Analytics integration
- Track:
  - Level starts/completions
  - Death locations (heatmap data)
  - Session duration
  - IAP events
- Privacy-compliant (COPPA, GDPR consideration)

## 4. Out of Scope (Version 1.0)

### Deferred Features
The following features are **NOT** included in the initial 3-month scope:

#### Gameplay Features
- ❌ Double jump mechanic
- ❌ Multiple characters with unique abilities
- ❌ Boss battles
- ❌ Endless mode
- ❌ Time trial mode
- ❌ Multiplayer/co-op
- ❌ Daily challenges

#### Technical Features
- ❌ Cloud saves
- ❌ Online leaderboards
- ❌ Social media sharing
- ❌ Account system/login
- ❌ Cross-platform progression sync
- ❌ Advanced particle systems
- ❌ Complex procedural generation

#### Content Features
- ❌ More than 5 environments
- ❌ Cutscenes or story mode
- ❌ Voice acting
- ❌ Localization (multiple languages)
- ❌ Extensive tutorial system
- ❌ Achievement system (beyond basic scores)

#### Monetization Features
- ❌ Ad integration (can be added post-launch)
- ❌ Battle pass system
- ❌ Gacha/loot boxes
- ❌ Subscription model

### Future Roadmap Considerations
Post-launch updates may include:
- Additional worlds (Ice, Volcano, Space themes)
- Endless runner mode
- Online leaderboards
- Daily challenges and events
- More characters and cart customization
- Ad-supported free tier

## 5. Development Phases (3-Month Timeline)

### Month 1: Foundation & Core Mechanics (Weeks 1-4)
**Focus**: Get the game playable

**Week 1-2**:
- Project setup in Unity
- GitHub repository initialization
- Core cart physics and movement
- Jump mechanic implementation
- Basic collision detection
- Placeholder graphics (simple shapes)

**Week 3-4**:
- Lives system
- Coin collection
- First level design (Forest theme)
- Basic UI (HUD, pause menu)
- PC keyboard controls
- **Milestone**: Playable prototype with 1 level

### Month 2: Content & Features (Weeks 5-8)
**Focus**: Expand content and add polish

**Week 5-6**:
- Complete 5 environment themes (vector art)
- Create 3 levels per environment (15 levels total)
- Character selection system (4 animals)
- Mobile touch controls
- Save/load system

**Week 7-8**:
- Upgrade shop implementation
- Scoring system
- Level unlocking progression
- Audio integration (music + SFX)
- Menu screens (main, level select, game over)
- **Milestone**: Feature-complete beta with all levels

### Month 3: Polish & Release Prep (Weeks 9-12)
**Focus**: Optimization, testing, and deployment

**Week 9-10**:
- Performance optimization (mobile focus)
- Bug fixing and playtesting
- UI/UX refinement
- IAP integration (Unity IAP)
- Analytics implementation

**Week 11-12**:
- Platform builds (PC, Android, iOS)
- App store assets (screenshots, descriptions)
- Final testing on target devices
- Google Play and Apple App Store submission
- **Milestone**: Release-ready builds

## 6. Team & Resources

### Development Team
- **Team Size**: Solo developer
- **Role**: Programmer, designer, tester
- **Skill Set**: C# development, Unity experience

### Required Assets
- **Graphics**: SVG vector graphics (create or source)
- **Audio**: Royalty-free music and SFX
- **Tools**: Unity, Git, Visual Studio/Rider

### External Resources
- Unity Asset Store (free assets)
- Royalty-free audio libraries
- Online tutorials/documentation as needed

## 7. Risk Assessment

### High-Risk Items
| Risk | Impact | Mitigation |
|------|--------|------------|
| iOS build requires macOS | High | Plan for cloud build service or partner with Mac user |
| Scope creep (adding features) | High | Strict adherence to scope doc, defer to v2.0 |
| Performance on older devices | Medium | Early testing on low-end devices, optimize continuously |
| SVG rendering performance | Medium | Pre-render sprites if SVG runtime is slow |

### Medium-Risk Items
| Risk | Impact | Mitigation |
|------|--------|------------|
| 3-month timeline too ambitious | Medium | Prioritize MVP, cut non-essential features |
| Art quality (solo developer) | Medium | Use simple, clean vector style; focus on gameplay |
| Monetization balance | Low | Ensure game is fun without IAP, test pricing |

## 8. Deliverables

### End of Month 1
- ✅ Playable prototype (1 level, core mechanics)
- ✅ GitHub repository with clean commit history
- ✅ Technical design document

### End of Month 2
- ✅ Beta build with all 15 levels
- ✅ Character selection and progression systems
- ✅ Full audio integration

### End of Month 3 (Final Release)
- ✅ PC standalone build (Windows/macOS/Linux)
- ✅ Android APK/AAB (Google Play ready)
- ✅ iOS build (Apple App Store ready)
- ✅ Store listings (screenshots, descriptions, trailers)
- ✅ Documentation (player guide, dev notes)

## 9. Acceptance Criteria

### Technical Acceptance
- [ ] Game runs at 60 FPS on mid-range PC
- [ ] Game runs at 30+ FPS on mobile (Android 7.0+, iOS 12+)
- [ ] No critical bugs or crashes
- [ ] All 15 levels playable and completable
- [ ] Save/load system works reliably

### Gameplay Acceptance
- [ ] Controls are responsive and intuitive
- [ ] Progression feels fair and rewarding
- [ ] Difficulty curve is well-balanced
- [ ] Coins and upgrades add value to gameplay

### Content Acceptance
- [ ] All 5 environments visually distinct
- [ ] 4 playable characters unlockable
- [ ] Audio enhances experience (music + SFX)
- [ ] UI is clean and user-friendly

### Business Acceptance
- [ ] IAP implemented and tested
- [ ] Analytics tracking key metrics
- [ ] App store guidelines compliance
- [ ] Privacy policy and legal requirements met

## 10. Sign-Off

This scope document represents the agreed-upon features and timeline for **Adventures of the World v1.0**. Any changes to scope must be evaluated for impact on the 3-month timeline.

**Approved By**: [Developer Name]
**Date**: 2025-11-22
**Version**: 1.0

---

**Next Steps**:
1. Review and approve this scope document
2. Set up Unity project and repository
3. Begin Month 1 development tasks
4. Schedule bi-weekly progress reviews
