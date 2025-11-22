# Adventures of the World - Development TODO List

## Project Status: Planning Phase ✅ → Development Phase 🚀

**Timeline**: 3 months (12 weeks)
**Current Phase**: Month 1 - Foundation & Core Mechanics
**Last Updated**: 2025-11-22

---

## 📋 Month 1: Foundation & Core Mechanics (Weeks 1-4)

### Week 1: Project Setup & Basic Movement
**Goal**: Get Unity project running with basic cart movement

- [ ] **Project Setup**
  - [ ] Create new Unity project (2022.3 LTS)
  - [ ] Configure project for 2D development
  - [ ] Set up version control (Git/GitHub integration)
  - [ ] Create project folder structure:
    - [ ] `/Assets/Scripts/`
    - [ ] `/Assets/Sprites/`
    - [ ] `/Assets/Audio/`
    - [ ] `/Assets/Scenes/`
    - [ ] `/Assets/Prefabs/`
  - [ ] Add .gitignore for Unity projects
  - [ ] Initial commit and push to GitHub

- [ ] **Core Cart Movement**
  - [ ] Create Cart GameObject with sprite renderer
  - [ ] Implement CartController.cs script
  - [ ] Add constant forward velocity (auto-scroll)
  - [ ] Add Rigidbody2D with gravity
  - [ ] Add wheel rotation animation
  - [ ] Test on simple flat ground

- [ ] **Camera System**
  - [ ] Create follow camera that tracks cart
  - [ ] Set up camera bounds (prevent showing off-level area)
  - [ ] Test smooth camera movement

- [ ] **Basic Ground & Platform**
  - [ ] Create platform prefab (simple rectangular sprite)
  - [ ] Add BoxCollider2D to platform
  - [ ] Test cart driving on platforms
  - [ ] Create basic test level scene

**Milestone**: Cart moves automatically and camera follows

---

### Week 2: Jump Mechanics & Collision

- [ ] **Jump System**
  - [ ] Implement jump input detection (keyboard)
  - [ ] Add jump force to Rigidbody2D
  - [ ] Add ground detection (raycast or trigger)
  - [ ] Prevent mid-air jumps (grounded check)
  - [ ] Add jump animation/squash-stretch
  - [ ] Create jump SFX placeholder
  - [ ] Test jump timing and feel

- [ ] **Collision Detection**
  - [ ] Create hazard prefab (spike, pit)
  - [ ] Implement OnCollisionEnter2D for hazards
  - [ ] Add death mechanic (cart explodes, respawn)
  - [ ] Create simple death animation
  - [ ] Add collision SFX placeholder

- [ ] **Basic Obstacle Design**
  - [ ] Create gap obstacle (missing platform)
  - [ ] Create barrier obstacle (low wall)
  - [ ] Create hazard obstacle (spikes)
  - [ ] Test obstacle placement in test level

**Milestone**: Jump works reliably, collisions detected, death/respawn functional

---

### Week 3: Lives, Coins & First Level

- [ ] **Lives System**
  - [ ] Create LivesManager.cs script
  - [ ] Implement lives counter (start with 3)
  - [ ] Decrement lives on death
  - [ ] Display lives in UI (heart icons)
  - [ ] Game Over condition (0 lives)
  - [ ] Create Game Over screen UI

- [ ] **Coin Collection**
  - [ ] Create coin prefab (sprite + trigger collider)
  - [ ] Implement OnTriggerEnter2D for coin collection
  - [ ] Add CoinManager.cs to track collected coins
  - [ ] Display coin counter in HUD
  - [ ] Add coin collection SFX placeholder
  - [ ] Add coin spin animation

- [ ] **First Level Design (Forest Level 1)**
  - [ ] Create Forest_Level_1 scene
  - [ ] Design level layout (300-400 meters)
  - [ ] Place 3-5 simple obstacles
  - [ ] Place 20-30 coins throughout level
  - [ ] Add level start and end markers
  - [ ] Test level is completable

- [ ] **Level Completion**
  - [ ] Create finish line trigger
  - [ ] Detect when player reaches end
  - [ ] Show "Level Complete" screen
  - [ ] Calculate basic score (coins + completion)

**Milestone**: Playable Level 1 with lives, coins, and completion

---

### Week 4: UI, Controls & Polish

- [ ] **User Interface**
  - [ ] Create MainMenu scene
  - [ ] Add Main Menu UI (Play, Settings, Exit buttons)
  - [ ] Create in-game HUD (lives, coins, score)
  - [ ] Create Pause Menu (Resume, Restart, Quit)
  - [ ] Implement pause functionality (ESC key)
  - [ ] Add Level Complete screen with stats
  - [ ] Add Game Over screen with retry option

- [ ] **Input System**
  - [ ] Implement PC keyboard controls (Space, Up Arrow)
  - [ ] Add mobile touch input detection (tap to jump)
  - [ ] Create InputManager.cs for cross-platform input
  - [ ] Test controls on PC
  - [ ] Test controls on mobile (Android build)

- [ ] **Placeholder Graphics**
  - [ ] Create simple cart sprite (placeholder)
  - [ ] Create platform sprite (textured rectangle)
  - [ ] Create obstacle sprites (basic shapes)
  - [ ] Create coin sprite (circle/star)
  - [ ] Add simple background (solid color gradient)

- [ ] **Audio Integration**
  - [ ] Set up AudioManager.cs (singleton)
  - [ ] Add background music placeholder (forest theme)
  - [ ] Add jump SFX
  - [ ] Add coin collect SFX
  - [ ] Add death/collision SFX
  - [ ] Implement volume controls in Settings

- [ ] **First Build & Test**
  - [ ] Create PC standalone build
  - [ ] Create Android APK test build
  - [ ] Playtest with at least 2 people
  - [ ] Gather feedback on controls and difficulty
  - [ ] Fix critical bugs

**✅ MONTH 1 MILESTONE**: Playable prototype with 1 complete level, all core mechanics working

---

## 📋 Month 2: Content & Features (Weeks 5-8)

### Week 5: Vector Graphics & Environments

- [ ] **Vector Graphics Setup**
  - [ ] Install Unity Vector Graphics package
  - [ ] Test SVG import workflow
  - [ ] If SVG runtime is slow, convert to sprites
  - [ ] Create sprite atlases for performance

- [ ] **Environment 1: Forest (Complete)**
  - [ ] Design and create Forest visual assets
    - [ ] Background layers (parallax scrolling)
    - [ ] Platform textures (grass, wood)
    - [ ] Tree sprites
    - [ ] Foliage decorations
  - [ ] Create Forest Level 2
  - [ ] Create Forest Level 3
  - [ ] Add environment-specific obstacles (logs, roots)

- [ ] **Environment 2: Mountain Range**
  - [ ] Design and create Mountain visual assets
    - [ ] Background (snow-capped peaks)
    - [ ] Platform textures (rocky)
    - [ ] Rock obstacle sprites
  - [ ] Create Mountain Level 4
  - [ ] Create Mountain Level 5
  - [ ] Create Mountain Level 6
  - [ ] Add environment-specific obstacles (falling rocks)

**Milestone**: 6 levels complete with distinct visual themes

---

### Week 6: More Environments & Characters

- [ ] **Environment 3: Desert**
  - [ ] Design and create Desert visual assets
    - [ ] Background (dunes, sunset)
    - [ ] Platform textures (sand)
    - [ ] Cactus sprites
  - [ ] Create Desert Level 7
  - [ ] Create Desert Level 8
  - [ ] Create Desert Level 9
  - [ ] Add environment-specific obstacles (cacti, sandpits)

- [ ] **Character System**
  - [ ] Create animal character sprites:
    - [ ] Lion (default)
    - [ ] Bunny
    - [ ] Duck
    - [ ] Mouse
  - [ ] Implement CharacterManager.cs
  - [ ] Create Character Selection screen UI
  - [ ] Implement character persistence (save selected character)
  - [ ] Display selected character in cart during gameplay

**Milestone**: 9 levels complete, character selection working

---

### Week 7: Final Environments & Advanced Obstacles

- [ ] **Environment 4: Underwater River**
  - [ ] Design and create Underwater visual assets
    - [ ] Background (flowing water, light rays)
    - [ ] Platform textures (rocks, coral)
    - [ ] Bubble particles
  - [ ] Create Underwater Level 10
  - [ ] Create Underwater Level 11
  - [ ] Create Underwater Level 12
  - [ ] Add unique "buoyancy" visual effect

- [ ] **Environment 5: Ocean**
  - [ ] Design and create Ocean visual assets
    - [ ] Background (open sea, waves)
    - [ ] Platform textures (boats, driftwood)
    - [ ] Wave animations
  - [ ] Create Ocean Level 13
  - [ ] Create Ocean Level 14
  - [ ] Create Ocean Level 15 (epic finale)

- [ ] **Advanced Obstacles**
  - [ ] Implement moving platforms (vertical/horizontal)
  - [ ] Create pendulum obstacles
  - [ ] Add collapsing platforms
  - [ ] Test timing and difficulty

**Milestone**: All 15 levels complete with varied obstacles

---

### Week 8: Progression & Shop System

- [ ] **Level Progression**
  - [ ] Implement level unlocking system
  - [ ] Create LevelSelectScreen UI showing all worlds
  - [ ] Add star rating system (1-3 stars per level)
  - [ ] Calculate star rating based on score/performance
  - [ ] Display stars on Level Select screen
  - [ ] Save level progress and stars

- [ ] **Scoring System**
  - [ ] Implement ScoreManager.cs
  - [ ] Calculate score: distance + coins + time bonus
  - [ ] Add perfect run bonus (no deaths)
  - [ ] Display score during gameplay
  - [ ] Show score breakdown on Level Complete screen
  - [ ] Save high scores per level

- [ ] **Shop System**
  - [ ] Create Shop scene UI
  - [ ] Implement shop inventory (characters, lives, skins)
  - [ ] Add coin spending functionality
  - [ ] Create "Unlock Character" purchase flow
  - [ ] Add "Buy Extra Lives" option
  - [ ] Implement cart skin purchases (cosmetic)
  - [ ] Save purchased items

- [ ] **Extra Lives & Pickups**
  - [ ] Create extra life pickup prefab
  - [ ] Place extra lives in levels (1-2 per level)
  - [ ] Implement pickup collision and effect
  - [ ] Add extra life SFX/visual effect

**✅ MONTH 2 MILESTONE**: Feature-complete beta with all 15 levels, progression, and shop

---

## 📋 Month 3: Polish & Release Prep (Weeks 9-12)

### Week 9: Audio & Visual Polish

- [ ] **Audio Assets**
  - [ ] Find/create royalty-free background music:
    - [ ] Main menu theme
    - [ ] Forest theme
    - [ ] Mountain theme
    - [ ] Desert theme
    - [ ] Underwater theme
    - [ ] Ocean theme
  - [ ] Find/create all required SFX:
    - [ ] Jump, land, coin, death, button click
    - [ ] Extra life, level complete, game over
  - [ ] Integrate all audio into AudioManager
  - [ ] Add audio credits to game

- [ ] **Visual Polish**
  - [ ] Add particle effects:
    - [ ] Dust on jump/land
    - [ ] Coin sparkle
    - [ ] Death explosion
    - [ ] Level complete confetti
  - [ ] Add background parallax scrolling
  - [ ] Improve UI animations (button hover, transitions)
  - [ ] Add screen transitions (fade in/out)
  - [ ] Polish character animations (idle, jump)

- [ ] **Performance Optimization**
  - [ ] Implement object pooling for coins and obstacles
  - [ ] Create sprite atlases for all environments
  - [ ] Optimize draw calls (batching)
  - [ ] Disable off-screen rendering
  - [ ] Test on low-end Android device
  - [ ] Profile and fix frame drops

**Milestone**: Game looks and sounds polished

---

### Week 10: Bug Fixes & Playtesting

- [ ] **Internal Playtesting**
  - [ ] Playtest all 15 levels start to finish
  - [ ] Test all menu screens and transitions
  - [ ] Test character selection and persistence
  - [ ] Test shop purchases
  - [ ] Test save/load functionality
  - [ ] Test on multiple devices (PC, Android, iOS if possible)

- [ ] **Bug Fixing**
  - [ ] Fix all critical bugs (crashes, soft locks)
  - [ ] Fix high-priority bugs (UI issues, audio glitches)
  - [ ] Fix medium-priority bugs (visual inconsistencies)
  - [ ] Document known low-priority bugs (defer to post-launch)

- [ ] **Balance Tuning**
  - [ ] Adjust cart speeds if too fast/slow
  - [ ] Adjust obstacle difficulty based on feedback
  - [ ] Adjust coin placement and economy
  - [ ] Ensure star ratings are achievable but challenging
  - [ ] Test progression pacing (coins needed for unlocks)

**Milestone**: Game is stable and well-balanced

---

### Week 11: IAP & Analytics Integration

- [ ] **In-App Purchases (IAP)**
  - [ ] Set up Unity IAP package
  - [ ] Create IAP products in Unity:
    - [ ] Small coin bundle (500 for $0.99)
    - [ ] Medium coin bundle (1,500 for $2.99)
    - [ ] Large coin bundle (5,000 for $7.99)
    - [ ] Character bundle (all animals for $4.99)
  - [ ] Implement purchase flow and callbacks
  - [ ] Test IAP in sandbox/test mode
  - [ ] Add restore purchases button (iOS requirement)

- [ ] **Analytics Implementation**
  - [ ] Set up Unity Analytics
  - [ ] Track key events:
    - [ ] Level started
    - [ ] Level completed
    - [ ] Player death (location)
    - [ ] Coins collected per level
    - [ ] IAP purchases
    - [ ] Session start/end
  - [ ] Test analytics events are firing
  - [ ] Verify data in Unity Analytics dashboard

- [ ] **Save System Hardening**
  - [ ] Implement save file validation
  - [ ] Add corruption detection and recovery
  - [ ] Test save persistence across app restarts
  - [ ] Test edge cases (app killed during save, low storage)

**Milestone**: Monetization and analytics ready for launch

---

### Week 12: Platform Builds & Store Submission

- [ ] **Final Testing**
  - [ ] Final QA pass on all platforms
  - [ ] Test IAP purchases (real money in sandbox)
  - [ ] Verify analytics are working
  - [ ] Check for any remaining crashes
  - [ ] Performance test on minimum spec devices

- [ ] **PC Build (Windows/macOS/Linux)**
  - [ ] Create Windows standalone build
  - [ ] Create macOS standalone build (if available)
  - [ ] Create Linux standalone build
  - [ ] Test all builds
  - [ ] Create installer/zip packages
  - [ ] Upload to itch.io or Steam (optional)

- [ ] **Android Build (Google Play)**
  - [ ] Set up Google Play Developer Console
  - [ ] Configure app signing
  - [ ] Build signed AAB (Android App Bundle)
  - [ ] Create store listing:
    - [ ] App title and description
    - [ ] Screenshots (minimum 2, recommend 8)
    - [ ] Feature graphic (1024x500)
    - [ ] App icon (512x512)
  - [ ] Set up IAP products in Google Play Console
  - [ ] Upload AAB to Google Play (internal testing track)
  - [ ] Test on Google Play internal track
  - [ ] Submit for review

- [ ] **iOS Build (Apple App Store)**
  - [ ] Set up Apple Developer account
  - [ ] Create app in App Store Connect
  - [ ] Build Xcode project from Unity (requires macOS)
  - [ ] Configure app signing and provisioning
  - [ ] Build IPA file
  - [ ] Create store listing:
    - [ ] App title and description
    - [ ] Screenshots (various iPhone/iPad sizes)
    - [ ] App icon (1024x1024)
  - [ ] Set up IAP products in App Store Connect
  - [ ] Upload build via Xcode or Transporter
  - [ ] Submit for App Review

- [ ] **Documentation & Legal**
  - [ ] Write privacy policy (required for app stores)
  - [ ] Create terms of service (if applicable)
  - [ ] Add credits screen (music, SFX, tools used)
  - [ ] Write player guide (optional, in-game help)
  - [ ] Update README.md with release info

- [ ] **Marketing Assets (Optional)**
  - [ ] Create trailer video (30-60 seconds)
  - [ ] Take promotional screenshots
  - [ ] Create social media posts
  - [ ] Set up landing page or website

**✅ MONTH 3 MILESTONE**: Release-ready builds submitted to app stores!

---

## 🎯 Post-Launch (Month 4+)

### Immediate Post-Launch
- [ ] Monitor app store reviews and ratings
- [ ] Track analytics for crash rates and engagement
- [ ] Fix critical bugs reported by users
- [ ] Respond to user feedback
- [ ] Monitor IAP performance

### Future Updates (v1.1, v1.2, etc.)
- [ ] Add daily challenges
- [ ] Implement rewarded video ads
- [ ] Add online leaderboards
- [ ] Create new world (Ice, Volcano, Space)
- [ ] Add endless runner mode
- [ ] Implement cloud saves
- [ ] Add achievements system
- [ ] Localization (Spanish, French, etc.)

---

## 🛠️ Technical Debt & Nice-to-Haves

### Low Priority (If Time Permits)
- [ ] Add settings for graphics quality (low/medium/high)
- [ ] Implement gamepad support for PC
- [ ] Add accessibility options (colorblind mode, etc.)
- [ ] Create level editor tool (for future content)
- [ ] Add replay system (watch your runs)
- [ ] Implement ghost/shadow of best run

### Code Quality
- [ ] Write unit tests for core game logic
- [ ] Add code comments and documentation
- [ ] Refactor messy scripts
- [ ] Set up CI/CD pipeline (automated builds)

---

## 📊 Progress Tracking

### Completion Status
- **Month 1**: ⏳ Not Started (0/4 weeks)
- **Month 2**: ⏳ Not Started (0/4 weeks)
- **Month 3**: ⏳ Not Started (0/4 weeks)

### Overall Progress: 0% Complete

**Next Action**: Set up Unity project and create initial repository structure

---

## 📝 Notes

- **Flexibility**: This TODO list is a living document. Adjust as needed based on progress and feedback.
- **Iteration**: Don't aim for perfection on first pass. Iterate based on playtesting.
- **Scope Management**: If falling behind, cut non-essential features (e.g., advanced obstacles, cart skins).
- **Testing Early**: Test on real devices as early as possible (especially mobile).
- **Version Control**: Commit often with clear messages. Use branches for major features.
- **Backup**: Keep backups of builds and assets.

---

**Good luck, and have fun creating Adventures of the World! 🎮🚀**
