# Development Phases - Revised Asset-First Approach

**Project**: Adventures of the World
**Timeline**: 3 months
**Focus**: Procedural generation with consistent environmental assets

---

## 🎯 Core Philosophy

**Assets drive procedural generation, not characters.**

Environmental decorations appear repeatedly in dynamic levels and must be:
- ✅ Consistent in style (all trees match, all rocks match)
- ✅ Reusable and tagged with metadata
- ✅ Credit-efficient (get it right the first time)
- ✅ Functional with spawning system

---

## 📅 Development Timeline

### **Phase 1: Foundation - Placeholder Graphics (Weeks 1-5)**

**Goal**: Perfect game mechanics with zero art investment

#### Week 1-2: Core Mechanics ✅
- [x] Unity project setup
- [x] Cart physics (auto-scroll + jump)
- [x] Camera system (Cinemachine)
- [x] Input handling (keyboard + touch)
- [x] Death/respawn system
- **Graphics**: Colored squares/circles only

#### Week 3-4: Lives, Coins, Obstacles
- [ ] Lives system with HUD
- [ ] Coin collection
- [ ] Basic obstacles (spikes, gaps)
- [ ] First complete test level
- **Graphics**: Still placeholders (simple shapes)

#### Week 5: Procedural Foundation
- [ ] ChunkData ScriptableObject system
- [ ] Basic chunk spawner
- [ ] Test procedural generation with 3-5 chunks
- [ ] Background decoration spawner (test with shapes)
- **Graphics**: Test with colored rectangles/circles

**Deliverable**: Fully playable game with placeholder art
**Art Investment**: $0 (all placeholders)

---

### **Phase 2: Asset Generation - Environmental Focus (Weeks 6-8)**

**Goal**: Generate all environmental decorations for procedural system

#### Week 6: Ludo.ai Prompt Testing + Forest Complete

**Day 1-2: Prompt Testing (5-10 credits)**
- Generate 3-5 test assets (1 tree, 1 rock, 1 bush)
- Test different prompt variations
- Find "winning" prompt formula
- Document what works

**Day 3-5: Forest Environment Complete (25-40 credits)**
- Batch generate all Forest decorations in ONE session:
  - 3 far background elements
  - 6 mid background elements
  - 4 near background elements
- Create ScriptableObjects for each
- Import and test in Unity
- Verify procedural spawning works

**Deliverable**: 13 Forest assets ready for procedural use
**Art Investment**: 30-50 credits total

---

#### Week 7: Mountain + Desert Themes

**Day 1-2: Mountain Environment (25-40 credits)**
- Use proven prompts from Forest
- Generate 13 mountain-themed assets
- Import, tag with metadata
- Test in procedural spawner

**Day 3-5: Desert Environment (25-40 credits)**
- Generate 13 desert-themed assets
- Import and configure
- Test spawning variety

**Deliverable**: 3 environments complete (39 assets total)
**Art Investment**: 50-80 credits

---

#### Week 8: Underwater + Ocean Themes

**Day 1-2: Underwater Environment (25-40 credits)**
- Generate 13 underwater-themed assets
- Import and test

**Day 3-5: Ocean Environment (25-40 credits)**
- Generate 13 ocean-themed assets
- Complete all environmental decorations

**Optional: 4 Core Characters (10-15 credits)**
- Static sprites only (Lion, Bunny, Duck, Mouse)
- Simple, no animation needed yet

**Deliverable**: All 5 environments complete (65 assets total)
**Art Investment**: 100-135 credits total

---

### **Phase 3: Content & Polish (Weeks 9-12)**

**Goal**: Finalize game with remaining assets and polish

#### Week 9: Obstacles & Collectibles (15-25 credits)
- Spike variations (5 environments × 1-2 designs)
- Coin sprite (gold/animated if desired)
- Extra life pickup sprite
- Platform textures (if needed)

**Deliverable**: All gameplay sprites complete

---

#### Week 10: Remaining Characters (Optional, 20-30 credits)
- Generate remaining 9 characters if budget allows
- Or keep with 4 core characters for v1.0
- Static sprites sufficient

**Deliverable**: Character roster complete (4-13 characters)

---

#### Week 11: UI & Polish (10-20 credits)
- UI buttons and icons
- HUD elements (hearts, coin icon)
- Menu backgrounds
- Particle effects (if needed)

**Deliverable**: Complete visual package

---

#### Week 12: Final Polish & Export
- Replace any remaining placeholders
- Final testing on all platforms
- Performance optimization
- Build exports

**Deliverable**: Release-ready game

---

## 💰 Credit Budget Breakdown

### **Estimated Total: 150-250 credits**

**Breakdown:**

| Phase | Task | Credits |
|-------|------|---------|
| Week 6 | Prompt testing | 5-10 |
| Week 6 | Forest (13 assets) | 25-40 |
| Week 7 | Mountain (13 assets) | 25-40 |
| Week 7 | Desert (13 assets) | 25-40 |
| Week 8 | Underwater (13 assets) | 25-40 |
| Week 8 | Ocean (13 assets) | 25-40 |
| Week 8 | 4 Characters (optional) | 10-15 |
| Week 9 | Obstacles/Coins | 15-25 |
| Week 10 | 9 More Characters (optional) | 20-30 |
| Week 11 | UI Elements | 10-20 |
| **TOTAL** | **~150-250 credits** | |

**Budget Tiers:**

**Minimum (150 credits):**
- All 5 environments (65 assets)
- Core obstacles and coins
- 4 characters
- Basic UI

**Recommended (200 credits):**
- All environments
- All obstacles/coins
- 13 characters
- Full UI package

**Premium (250 credits):**
- All of the above
- Multiple variations
- Iteration budget for perfection

---

## 🎨 Asset Priority Order

### **Critical Path (Must Have)**
1. ✅ Forest environment (13 decorations)
2. ✅ Mountain environment (13 decorations)
3. ✅ Desert environment (13 decorations)
4. ✅ Underwater environment (13 decorations)
5. ✅ Ocean environment (13 decorations)
6. ✅ Obstacles (spikes, barriers)
7. ✅ Coins and pickups

**Total: 65-70 assets**

### **Important (Should Have)**
8. ⚠️ 4 core characters (Lion, Bunny, Duck, Mouse)
9. ⚠️ UI elements (buttons, icons, HUD)
10. ⚠️ Platform textures (if needed)

**Total: +10-15 assets**

### **Nice to Have (Could Have)**
11. ❓ 9 additional characters
12. ❓ Character variations/animations
13. ❓ Particle effects
14. ❓ Special/seasonal content

---

## 🔧 Technical Workflow Per Asset

### **1. Generate in Ludo.ai**
- Use tested prompt from library
- Export as PNG, 1024x1024 or higher
- Transparent background

### **2. Post-Process (if needed)**
- Verify transparency
- Resize if needed
- Remove artifacts

### **3. Import to Unity**
- Drag to: `Assets/Sprites/Environments/[Theme]/[Layer]/`
- Set import settings (Sprite, 100 PPU)

### **4. Create Metadata**
- Create DecorationData ScriptableObject
- Set theme, layer, category
- Configure spawn rules (size, weight, spacing)

### **5. Add to Spawner**
- Add to BackgroundSpawner decoration pool
- Assign to correct theme and layer

### **6. Test in Play Mode**
- Verify spawning works
- Check visual consistency
- Adjust spawn parameters

### **7. Commit to Git**
- Save asset + metadata
- Document in asset log

---

## ✅ Success Criteria by Phase

### **Phase 1 Complete When:**
- [ ] Cart moves and jumps smoothly
- [ ] Death/respawn works
- [ ] Basic procedural generation functional
- [ ] Test level playable start to finish
- [ ] NO final art needed yet

### **Phase 2 Complete When:**
- [ ] All 5 environments have decorations
- [ ] Procedural spawning produces varied levels
- [ ] Art style consistent across all themes
- [ ] Metadata system working
- [ ] Can generate unlimited dynamic levels

### **Phase 3 Complete When:**
- [ ] All placeholders replaced
- [ ] 4-13 characters available
- [ ] UI polished
- [ ] Game ready for app store submission
- [ ] Performance targets met (60 FPS PC, 30+ FPS mobile)

---

## 🎯 Key Differences from Original Plan

### **OLD Approach (Character-First):**
- ❌ Characters generated first
- ❌ Environments as afterthought
- ❌ Inconsistent generation across sessions
- ❌ Higher credit waste

### **NEW Approach (Environment-First):**
- ✅ Environmental decorations prioritized
- ✅ Batch generation in sessions (consistency)
- ✅ Assets tagged for procedural use
- ✅ Credit-efficient workflow
- ✅ Unlimited replayability through procedural variety

---

## 📊 Why This Works Better

**Procedural Generation Needs:**
1. **Variety** → Many decoration assets
2. **Consistency** → All trees must match style
3. **Metadata** → Assets tagged with spawning rules
4. **Reusability** → Same assets used across many levels

**Characters Need:**
1. **One-time view** → Player picks once, sees in cart
2. **Less critical** → Could launch with 4, add 9 later
3. **No metadata needed** → Just visual selection

**Therefore:** Environmental assets are higher priority! ✅

---

## 🚀 Flexibility & Adaptation

**If credits run low:**
- Complete fewer environments (Forest + Mountain minimum)
- Use 4 characters only
- Skip UI generation (use Unity default UI)

**If credits are plentiful:**
- Add more decoration variations per theme
- Generate all 13 characters
- Create seasonal/special variants

**If time runs short:**
- Skip character variety (4 is enough)
- Focus on making 2-3 environments perfect
- Polish existing rather than adding more

---

*Last Updated: 2025-11-23*
*Optimized for procedural generation workflow*
