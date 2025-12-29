# Adventures of the World - Game Design Document

## 1. Game Overview

### High Concept
An auto-scrolling 2D platformer where players ride a cart through diverse world environments, jumping over obstacles and collecting coins while guiding adorable animal companions to safety.

### Genre
- Primary: Side-Scrolling Platformer
- Secondary: Endless Runner / Casual Mobile Game

### Target Platform
PC, Android, iOS

### Unique Selling Points
1. **Simple Yet Engaging**: One-button control scheme with depth through level design
2. **Charming Characters**: Cute animal companions with personality
3. **Diverse Environments**: 5 distinct themed worlds with unique visual styles
4. **Accessible Progression**: Free-to-play with fair monetization
5. **Cross-Platform**: Seamless experience on mobile and PC

## 2. Core Gameplay Loop

### Primary Loop (Single Level)
```
START LEVEL → Navigate Obstacles → Collect Coins → Reach End → LEVEL COMPLETE
     ↑                                                              ↓
     └──────────── RETRY (if death) ←────── Death? ←───────────────┘
```

### Meta Loop (Overall Progression)
```
Complete Level → Earn Coins → Spend in Shop → Unlock Content → Play New Levels
                                    ↓
                         (Characters, Lives, Upgrades)
```

### Engagement Cycle
1. **Play**: Navigate obstacles, collect coins, achieve high score
2. **Progress**: Unlock next level, see new environment
3. **Customize**: Choose character, buy upgrades
4. **Improve**: Retry levels for better scores/ratings
5. **Repeat**: Continue through next world

## 3. Game Mechanics

### 3.1 Core Mechanics

#### Auto-Scrolling Cart
- **Behavior**: Cart moves right automatically at constant speed
- **Speed**:
  - Forest (Levels 1-3): 5 units/second (slow, beginner-friendly)
  - Mountain (Levels 4-6): 6 units/second
  - Desert (Levels 7-9): 7 units/second
  - Underwater (Levels 10-12): 5.5 units/second (slower for visual effect)
  - Ocean (Levels 13-15): 8 units/second (fast, challenging)
- **Player Control**: NONE over horizontal movement (only jump)
- **Wheel Physics**: Wheels rotate, cart bounces slightly on landings

#### Jump Mechanic
- **Input**:
  - PC: Spacebar or Up Arrow
  - Mobile: Tap anywhere on screen
- **Jump Height**: Fixed at 3 units (clears 2-unit tall obstacles)
- **Jump Duration**: 0.8 seconds (arc up and down)
- **Gravity**: Standard Unity gravity (9.81 m/s²)
- **Limitations**:
  - Can only jump when grounded
  - No mid-air jump (no double jump in v1.0)
  - Pressing jump while airborne = no effect
- **Feedback**:
  - Jump SFX
  - Slight visual squash-and-stretch animation
  - Dust particle on takeoff

#### Collision System
**Three Collision Types**:

1. **Hazards** (Deadly)
   - Spikes, rocks, pitfalls, enemies
   - Effect: Lose 1 life, respawn at checkpoint
   - Visual: Cart shakes, character has "hit" animation
   - Audio: Collision sound + grunt

2. **Collectibles** (Beneficial)
   - Coins: +10 points, collect for shop currency
   - Extra Lives: +1 life (rare)
   - Power-ups (future): shields, magnets, speed boosts
   - Effect: Object disappears, counter updates
   - Audio: Pleasant "ding" sound

3. **Platforms** (Neutral)
   - Ground, bridges, ramps
   - Effect: Cart can drive/land on them
   - No special feedback beyond normal movement

### 3.2 Lives System

#### Starting Lives
- Each level starts with **3 lives**
- Lives reset per level (not global)

#### Losing Lives
- Collision with hazard: -1 life
- Falling off the map: -1 life
- Cart destroyed: -1 life

#### Extra Lives
- Pickup items (rare, 1-2 per level)
- Purchase from shop (100 coins = 3 lives)
- Maximum lives: 5 (cap to prevent hoarding)

#### Death and Respawn
- **On death**:
  1. Cart/character "explode" animation (cartoon style)
  2. Screen fades briefly
  3. Lives counter decreases
  4. Respawn at last checkpoint (or level start if no checkpoint)
- **Game Over** (0 lives):
  1. "Game Over" screen displays
  2. Shows level stats (distance, coins collected)
  3. Options: Retry Level, Quit to Menu, Spend Coins to Continue

### 3.3 Scoring System

#### Score Components
| Action | Points | Notes |
|--------|--------|-------|
| Distance traveled | 1 point/meter | Tracks how far player got |
| Coin collected | 10 points | Encourages collection |
| Level completion | 500 points | Flat bonus |
| Time bonus | 1-300 points | Faster = more points |
| Perfect run (no deaths) | 500 points | Skill reward |

#### Star Rating (Per Level)
- **1 Star**: Complete the level
- **2 Stars**: Score > 70% of max possible
- **3 Stars**: Score > 90% of max possible + no deaths

#### Leaderboards (Future)
- High score per level (local only in v1.0)
- Global leaderboards (post-launch update)

### 3.4 Coin Economy

#### Earning Coins
- Collect during gameplay (persistent across attempts)
- Level completion bonuses
- Star rating bonuses (50/100/150 coins for 1/2/3 stars)

#### Spending Coins
| Item | Cost | Description |
|------|------|-------------|
| Extra Lives (3-pack) | 100 | Add 3 lives to current run |
| Character Unlock | 500-1000 | Unlock new animal |
| Cart Skin | 250-500 | Cosmetic upgrade |
| Continue Token | 50 | Respawn with full lives once |

#### Balance Targets
- Average coins per level: 50-100
- Unlock first new character: ~5 levels of play
- Encourage replaying levels for better scores

## 4. Level Design

### 4.1 Level Structure

#### Standard Level Length
- **Duration**: 60-90 seconds per level
- **Distance**: 300-600 meters (varies by speed)
- **Sections**:
  1. Intro (easy, 20% of level)
  2. Ramp-up (medium, 40%)
  3. Challenge (hard, 30%)
  4. Finale (varied, 10%)

#### Obstacle Placement Philosophy
- **Telegraphing**: Visual cues before difficult sections
- **Rhythm**: Patterns that players can learn and master
- **Breather Moments**: Safe zones between intense sections
- **Risk/Reward**: Coins placed in risky locations

### 4.2 Obstacle Types

#### Static Obstacles
1. **Gaps** (0.5 - 2 units wide)
   - Small: Can be jumped easily
   - Medium: Requires well-timed jump
   - Large: Requires running start

2. **Barriers** (1-2 units tall)
   - Logs, rocks, fences
   - Must jump to clear

3. **Hazards** (Deadly)
   - Spikes: Low obstacles that hurt
   - Pits: Instant death if fall in
   - Boulders: Large hazards

#### Dynamic Obstacles (Later Levels)
4. **Moving Platforms**
   - Vertical or horizontal movement
   - Must time jump to land safely

5. **Pendulums**
   - Swinging hazards
   - Timing challenge

6. **Collapsing Platforms**
   - Break after stepping on them
   - Creates urgency

### 4.3 Environment Themes

#### 1. Forest (Levels 1-3)
**Visual Theme**: Lush green, trees, sunlight filtering through leaves

**Obstacles**:
- Fallen logs
- Small gaps in path
- Tree roots
- Berry bushes (coins)

**Difficulty**: Easy (tutorial-like)
- Level 1: Introduction to jumping
- Level 2: Gaps and timing
- Level 3: Multiple obstacles in sequence

**Color Palette**: Greens, browns, yellow sunlight

---

#### 2. Mountain Range (Levels 4-6)
**Visual Theme**: Rocky cliffs, snow-capped peaks, thin air

**Obstacles**:
- Rock formations
- Wider gaps (cliffs)
- Falling rocks
- Ice patches (slippery)

**Difficulty**: Medium
- Level 4: Longer gaps
- Level 5: Moving obstacles introduced
- Level 6: Combination challenges

**Color Palette**: Grays, whites, blue sky

---

#### 3. Desert (Levels 7-9)
**Visual Theme**: Sand dunes, cacti, ancient ruins, intense heat

**Obstacles**:
- Cacti (hazards)
- Sand pits
- Tumbleweeds
- Crumbling ruins

**Difficulty**: Medium-Hard
- Level 7: Faster cart speed
- Level 8: More hazards
- Level 9: Precision timing required

**Color Palette**: Yellows, oranges, tan, sunset colors

---

#### 4. Underwater River (Levels 10-12)
**Visual Theme**: Flowing water, bubbles, aquatic plants, fish

**Obstacles**:
- Rocks in stream
- Water currents (push cart)
- Whirlpools
- Floating logs

**Difficulty**: Hard
- Level 10: Unique underwater physics feel
- Level 11: Strong currents
- Level 12: Complex navigation

**Color Palette**: Blues, greens, aqua, light rays

**Unique Mechanic**: Visual "buoyancy" effect (cart floats slightly)

---

#### 5. Ocean (Levels 13-15)
**Visual Theme**: Open sea, waves, boats, seagulls, islands

**Obstacles**:
- Wave crests
- Boat wreckage
- Jumping fish
- Moving platforms (boats)

**Difficulty**: Very Hard (final challenge)
- Level 13: All obstacle types
- Level 14: High-speed gauntlet
- Level 15: Epic finale level

**Color Palette**: Deep blues, white foam, golden sunset

---

### 4.4 Difficulty Progression

#### Difficulty Curve Principles
1. **Gradual Increase**: Each level slightly harder than last
2. **Skill Building**: Early levels teach, later levels test
3. **Variety**: Mix obstacle types to avoid repetition
4. **Achievable**: Challenging but fair, no "cheap" deaths

#### Difficulty Factors
| Factor | Early Levels | Mid Levels | Late Levels |
|--------|-------------|------------|-------------|
| Cart Speed | Slow | Medium | Fast |
| Obstacle Frequency | Low | Medium | High |
| Gap Size | Small | Medium | Large |
| Hazard Density | Sparse | Moderate | Dense |
| Moving Obstacles | None | Few | Many |
| Timing Windows | Forgiving | Moderate | Tight |

## 5. Characters & Customization

### 5.1 Playable Characters

All characters are **cosmetic only** (no gameplay differences in v1.0).

#### 1. Lion
- **Appearance**: Golden mane, confident expression
- **Personality**: Brave, bold, leader
- **Unlock**: Default (available from start)
- **Visual**: Slightly larger in cart

#### 2. Bunny
- **Appearance**: White fur, floppy ears, pink nose
- **Personality**: Energetic, quick, cheerful
- **Unlock**: 500 coins
- **Visual**: Bouncy idle animation

#### 3. Duck
- **Appearance**: Yellow feathers, orange beak, sailor hat
- **Personality**: Fun-loving, adventurous
- **Unlock**: 750 coins
- **Visual**: Flaps wings occasionally

#### 4. Mouse
- **Appearance**: Gray fur, big ears, tiny size
- **Personality**: Clever, curious, scrappy
- **Unlock**: 1000 coins
- **Visual**: Smallest character, peeking over cart edge

### 5.2 Cart Customization (Optional)

#### Cart Skins
- **Default Cart**: Wooden cart with wheels
- **Golden Cart**: Shiny gold (250 coins)
- **Rainbow Cart**: Colorful stripes (500 coins)
- **Speed Racer Cart**: Racing stripes (750 coins)

*Note*: Purely cosmetic, no speed/physics changes

## 6. User Interface & Menus

### 6.1 Main Menu

**Layout**:
```
┌─────────────────────────────────┐
│   ADVENTURES OF THE WORLD       │
│   [Cute character animation]    │
│                                  │
│        [PLAY]                    │
│        [CHARACTER SELECT]        │
│        [SHOP]                    │
│        [SETTINGS]                │
│        [EXIT]                    │
└─────────────────────────────────┘
```

**Buttons**:
- **Play**: Go to level select
- **Character Select**: Choose animal
- **Shop**: Spend coins on upgrades
- **Settings**: Volume, controls, credits
- **Exit**: Quit game (PC) or return to home (mobile)

### 6.2 Level Select Screen

**Layout**:
```
WORLD 1: FOREST
┌─────┬─────┬─────┐
│  1  │  2  │  3  │
│ ★★★ │ ★★☆ │ 🔒  │
└─────┴─────┴─────┘

WORLD 2: MOUNTAIN
┌─────┬─────┬─────┐
│  4  │  5  │  6  │
│ 🔒  │ 🔒  │ 🔒  │
└─────┴─────┴─────┘
```

**Features**:
- Visual representation of each world
- Star rating displayed per level
- Lock icon for unavailable levels
- Scroll through all 5 worlds

### 6.3 In-Game HUD

**HUD Elements** (During Gameplay):
```
┌─────────────────────────────────────┐
│ ♥♥♥   Coins: 45   Score: 1,250     │  ← Top bar
└─────────────────────────────────────┘

     [Gameplay area]

┌─────────────────────────────────────┐
│            [PAUSE ⏸]                 │  ← Bottom (mobile only)
└─────────────────────────────────────┘
```

**Elements**:
- **Lives**: Heart icons (filled/empty)
- **Coins**: Counter (current level + total)
- **Score**: Real-time score display
- **Pause Button**: Accessible on mobile (PC uses ESC)

### 6.4 Pause Menu

**Layout**:
```
┌─────────────────────┐
│     PAUSED          │
│                     │
│   [RESUME]          │
│   [RESTART]         │
│   [SETTINGS]        │
│   [QUIT TO MENU]    │
└─────────────────────┘
```

### 6.5 Level Complete Screen

**Layout**:
```
┌────────────────────────────┐
│    LEVEL COMPLETE!         │
│         ★ ★ ★              │
│                            │
│  Score:     2,450          │
│  Coins:       67           │
│  Time:      1:23           │
│  Bonus:    +500            │
│  ─────────────────         │
│  Total:    2,950           │
│                            │
│  [NEXT LEVEL]  [RETRY]     │
└────────────────────────────┘
```

### 6.6 Game Over Screen

**Layout**:
```
┌────────────────────────────┐
│      GAME OVER             │
│                            │
│  You made it to:           │
│  450 meters                │
│                            │
│  Coins collected: 23       │
│                            │
│  [RETRY]   [MENU]          │
│                            │
│  [CONTINUE (50 coins)]     │
└────────────────────────────┘
```

### 6.7 Shop Screen

**Layout**:
```
┌──────────────────────────────────┐
│  SHOP      Your Coins: 1,245     │
├──────────────────────────────────┤
│                                  │
│  [🦁 LION]       Default         │
│  [🐰 BUNNY]      500 coins [BUY] │
│  [🦆 DUCK]       750 coins [BUY] │
│  [🐭 MOUSE]    1,000 coins [BUY] │
│                                  │
│  [❤️ EXTRA LIVES] 100 coins      │
│  [🛒 CART SKIN]   250 coins      │
│                                  │
│  ─── COIN BUNDLES ───            │
│  [500 coins]      $0.99          │
│  [1500 coins]     $2.99          │
│  [5000 coins]     $7.99          │
└──────────────────────────────────┘
```

## 7. Audio Design

### 7.1 Music

#### Music Tracks Needed
1. **Main Menu Theme** (looping, upbeat)
2. **Forest Theme** (light, whimsical, nature sounds)
3. **Mountain Theme** (adventurous, orchestral)
4. **Desert Theme** (exotic, percussion-heavy)
5. **Underwater Theme** (calm, flowing, ethereal)
6. **Ocean Theme** (epic, triumphant)
7. **Victory Jingle** (short, celebratory)
8. **Game Over Music** (short, sympathetic)

#### Music Guidelines
- **Tempo**: Match level speed (faster levels = faster tempo)
- **Loop Points**: Seamless looping for continuous play
- **Volume**: Background music, not overpowering
- **Source**: Royalty-free (Incompetech, FreePD, OpenGameArt)

### 7.2 Sound Effects

#### Essential SFX
| Sound | Trigger | Notes |
|-------|---------|-------|
| Jump | Player presses jump | Quick "boing" sound |
| Land | Cart lands after jump | Soft thud |
| Coin Collect | Touch coin | Pleasant "ding" |
| Death | Collision with hazard | Crash + character grunt |
| Extra Life | Pickup extra life | Magical chime |
| Button Click | UI interaction | Simple click |
| Level Complete | Reach end | Fanfare jingle |
| Star Earn | Star awarded | Sparkle sound |
| Purchase | Buy item in shop | Cash register "cha-ching" |

#### Ambient Sounds (Optional)
- Forest: Birds chirping
- Mountain: Wind howling
- Desert: Wind blowing sand
- Underwater: Bubbles, flowing water
- Ocean: Waves crashing, seagulls

## 8. Progression & Retention

### 8.1 Player Progression

#### Short-Term Goals (Per Session)
- Complete the current level
- Earn 3 stars on a level
- Collect all coins in a level
- Unlock next level

#### Medium-Term Goals (Week 1)
- Complete an entire world (3 levels)
- Unlock a new character
- Earn enough coins for first upgrade
- Master a challenging level

#### Long-Term Goals (Full Game)
- Complete all 15 levels
- Earn 3 stars on every level
- Unlock all 4 characters
- Achieve high scores

### 8.2 Retention Mechanics

#### Session-to-Session
- "Next level unlocked!" hook
- "Just one more try" on failed levels
- Coins persist across sessions (always making progress)

#### Day-to-Day (Future Updates)
- Daily login bonuses
- Daily challenges (e.g., "Complete any level without dying")
- Rotating shop deals

#### Week-to-Week (Future Updates)
- New levels or worlds added
- Seasonal events (holidays)
- Limited-time characters or skins

### 8.3 Onboarding & Tutorials

#### First-Time User Experience (FTUE)
**Level 1 serves as tutorial**:
1. Simple opening: Cart already moving
2. Text prompt: "TAP TO JUMP" (appears when first gap approaches)
3. First obstacle is very easy (small gap)
4. Coin appears after first jump (tutorial for collection)
5. No deaths in first 20 seconds (forgiving design)

**No explicit tutorial needed**: Learn by playing

## 9. Monetization Strategy

### 9.1 Free-to-Play Model

#### Core Principles
- **Fair**: No pay-to-win, all content earnable
- **Generous**: Coins are plentiful through gameplay
- **Optional**: IAP provides convenience, not necessity
- **Transparent**: Clear pricing, no loot boxes or gambling

### 9.2 In-App Purchases

#### Coin Bundles
- **Small**: 500 coins for $0.99 (value: ~2 levels worth)
- **Medium**: 1,500 coins for $2.99 (best value)
- **Large**: 5,000 coins for $7.99 (whale option)

#### Premium Content (Optional)
- **Character Bundle**: Unlock all animals for $4.99
- **Starter Pack**: 1,000 coins + exclusive cart skin for $3.99
- **Remove Ads** (if ads added later): $2.99

### 9.3 Ad Integration (Future)

**NOT in v1.0**, but planned for post-launch:
- **Rewarded Video Ads**: Watch ad for bonus coins or extra life
- **Interstitial Ads**: Between level attempts (skippable after 5 seconds)
- **Banner Ads**: On menu screens only (not during gameplay)

**Ad Frequency Cap**: Max 1 ad per 5 minutes to avoid annoyance

## 10. Technical Design Notes

### 10.1 Architecture

#### Scene Structure
- **MainMenu** scene
- **LevelSelect** scene
- **Gameplay** scene (all levels use same scene, load data)
- **Shop** scene
- **Settings** scene

#### Key Components
- **CartController**: Handles auto-scroll and jump
- **LevelManager**: Spawns obstacles, tracks progress
- **CoinManager**: Handles coin collection and persistence
- **ScoreManager**: Calculates and displays score
- **AudioManager**: Singleton for music/SFX control
- **SaveManager**: Handles PlayerPrefs/JSON saves

### 10.2 Performance Targets

#### Frame Rate
- **PC**: Locked 60 FPS
- **Mobile**: 30 FPS minimum, 60 FPS target

#### Optimization Strategies
- Object pooling for obstacles and coins
- Sprite atlasing for all 2D assets
- Minimal draw calls (batch sprites)
- LOD (Level of Detail) for background elements
- Disable off-screen objects

### 10.3 Save Data Structure

```json
{
  "version": "1.0",
  "playerData": {
    "totalCoins": 1245,
    "selectedCharacter": "lion",
    "unlockedCharacters": ["lion", "bunny"],
    "unlockedLevels": [1, 2, 3, 4, 5],
    "levelScores": {
      "level_1": {"score": 2450, "stars": 3, "coins": 50},
      "level_2": {"score": 1980, "stars": 2, "coins": 45}
    },
    "settings": {
      "musicVolume": 0.8,
      "sfxVolume": 1.0
    }
  }
}
```

## 11. Success Metrics

### Gameplay Metrics
- **Level Completion Rate**: > 40% (indicates good difficulty)
- **Average Session Length**: > 5 minutes
- **Retry Rate**: 2-3 attempts per level (sweet spot)
- **3-Star Rate**: 20-30% (aspirational but achievable)

### Engagement Metrics
- **Day 1 Retention**: > 30%
- **Day 7 Retention**: > 15%
- **Daily Active Users (DAU)**: Track growth
- **Session Frequency**: 2-3 sessions per day (ideal)

### Monetization Metrics
- **IAP Conversion Rate**: > 2%
- **ARPU** (Average Revenue Per User): > $0.50
- **ARPPU** (Average Revenue Per Paying User): > $5.00

---

**Document Version**: 1.0
**Last Updated**: 2025-11-22
**Status**: Living Document (will evolve during development)

**Next Steps**:
- Prototype core mechanics (auto-scroll + jump)
- Create first level in Unity
- Iterate based on playtesting
