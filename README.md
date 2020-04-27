# UHMCyberDefense

## Installation

- Windows: Double Click on UHMCD_Setup.exe. Follow installer directions.

## Technical Notes

## Security

- User generated data (user name, password, scores) are stored in aAES encrypted files.
- AES key is removed from system memory once program no longer needs it.
- Additonal SHA256 password hashing.
- Security features cause a 0.5-1.0 second hang on data access.

### Minimum Specifications

#### Windows

- x86/x64 CPU with SSE2 Support
- DX10/DX11/DX12 capable GPU

#### Mac OS

- x64 CPU with SSE2 Support
- Metal Capable Intel and AMD GPUs

## Developer Thoughts

### Ken Townsend

- Making even simple games is hard, even with an SDK to do all the heavy lifting.
- One challenge was to findout what we can make secure
- Another was getting our application to the point where we could work on the security aspect.
- Even though the C# scripting was pretty simple in the end, figuring out what worked and how in Unity took time.
- Checking and rechecking how it all connected in Unity to avoid small mistakes was tedious.
- It is very easy to envision a games project that is beyond scope of your abilities and time constraints.

## Repository

- https://github.com/UHM-Cyber-Defense/UHMCyberDefense

## Documentation

## Final Release

## Wiki

- https://github.com/UHM-Cyber-Defense/UHMCyberDefense/wiki

## 04/12/2020 - 04/26/2020

### Michael Boyle

#### Worked on:

- Additional User Data Encryption
- Security Analysis
- Game Balance
- Wiki
- Report

#### Handling next:

### Kenneth Yamaguchi-Townsend

#### Worked on:

- Bug Fixing
- Ingame Scoreboard
- Updating Art Assets
- Game Balance
- Wiki
- Report

#### Handling next:

### Joshua Ducey

#### Worked on:

- Security Analysis
- QA Testing
- Game Balance
- Wiki
- Report

#### Handling next:

### Pauline Wu

#### Worked on:

- SFX
- Security Analysis
- QA Testing
- Game Balance
- Wiki
- Report

#### Handling next:

## 03/15/2020 - 04/12/2020

### Michael Boyle

#### Worked on:

- Begin User Data Encryption
- Fuzz Testing
- Report

#### Handling next:

- Improved File Security

### Kenneth Yamaguchi-Townsend

#### Worked on:

- Full Menu Implementation (Back End)
- Basic User Account System (Back End)
- Scoreboard Saving (Back End)

#### Handling next:

- Increased Validation Checks
- Ingame Scoreboard
- UI/HUD Improvements

### Joshua Ducey

#### Worked on:

- Static Analysis
- Report

#### Handling next:

- Projectile effects
- SFX

### Pauline Wu

#### Worked on:

- Fuzz Testing
- Report

#### Handling next:

- Improved File Security

## 02/25/2020 - 03/15/2020

### Michael Boyle

#### Worked on:

- Main Menu: Outline and working scene change
- Login System: Text field and variables

#### Handling next:

- Main Menu
- Login System

### Kenneth Yamaguchi-Townsend

#### Worked on:

- Enemy NPC movement
- Enemy NPC Spawning
- Wave System
- Enemy Shooting

#### Handling next:

- Play Environment
- UI/HUD
- Game Over State
- Not Going Insane from how much it takes to make even a simple game.

### Joshua Ducey

#### Worked on:

- Attack Surface Review
- README file

#### Handling next:

- UI
- SFX

### Pauline Wu

#### Worked on:

- Pause Menu
- README file

#### Handling next:

- Options
- Scoreboard

## 02/04/2020 - 02/23/2020

### Michael Boyle

#### Worked on:

- NPC movement
- README file

#### Handling next:

- Spawn system
- Options

### Kenneth Yamaguchi-Townsend

#### Worked on:

- Placeholder models
- Payer ship
- NPC ship
- Projectile
- Firewall

#### Handling next:

- Collision physics
- Health system

### Joshua Ducey

#### Worked on:

- SCM setup
- README file

#### Handling next:

- Projectile effects
- UI
- Scoreboard

### Pauline Wu

#### Worked on:

- Main Scene

#### Handling next:

- Main Menu
- Pause Menu

## Link to Our GitHub Repository:

- https://github.com/UHM-Cyber-Defense/UHMCyberDefense
