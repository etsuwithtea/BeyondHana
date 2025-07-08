# 🌸 BeyondHana

**A Cross-Platform Visual Novel Game Engine Built with .NET MAUI**

![.NET MAUI](https://img.shields.io/badge/.NET%20MAUI-9.0-purple)
![.NET](https://img.shields.io/badge/.NET-9.0-blue)
![Platform](https://img.shields.io/badge/Platform-Android%20%7C%20iOS%20%7C%20Windows%20%7C%20macOS-lightgrey)
![Language](https://img.shields.io/badge/UI-English-green)
![Content](https://img.shields.io/badge/Story-Thai-orange)

---

## 📖 About

BeyondHana is a modern visual novel game engine and interactive story application built using **.NET MAUI** and **.NET 9**. The application features an **English user interface** for accessibility while delivering **rich Thai narrative content** that showcases Thai storytelling and culture.

### 🎯 Key Highlights

- **Cross-Platform**: Runs seamlessly on Android, iOS, Windows, and macOS
- **Modern Technology**: Built with .NET MAUI and .NET 9 for optimal performance
- **Bilingual Experience**: English interface with authentic Thai storytelling
- **Rich Media**: Full support for background music, sound effects, and character sprites
- **Interactive Storytelling**: Choice-driven narratives with multiple paths

---

## ✨ Features

### 🎮 Core Gameplay
- **Interactive Story System**: Choice-driven narrative with multiple branching paths
- **Character Management**: Rich character system with sprites and dialogue
- **Save/Load System**: Multiple save slots to preserve your progress
- **Settings Customization**: Adjustable text size, music volume, and sound effects

### 🎵 Audio & Visual
- **Background Music**: Immersive soundtracks that adapt to story moments
- **Sound Effects**: Interactive audio feedback for enhanced experience
- **Character Sprites**: Expressive character artwork with multiple poses
- **Background Images**: Beautiful scenes that complement the narrative
- **Custom Fonts**: Carefully selected typography for optimal readability

### 🎨 User Interface
- **Intuitive Navigation**: Clean, user-friendly interface design
- **Responsive Layout**: Optimized for different screen sizes and orientations
- **Accessibility**: Adjustable text size and clear visual hierarchy
- **Smooth Transitions**: Polished animations and scene transitions

### 💾 Data Management
- **SQLite Database**: Efficient local storage for game data
- **Progress Tracking**: Automatic chapter and choice tracking
- **Multiple Characters**: Support for diverse character roster
- **Event System**: Flexible event management for complex narratives

---

## 🛠️ Technology Stack

- **Framework**: .NET MAUI (Multi-platform App UI)
- **Runtime**: .NET 9.0
- **Database**: SQLite with sqlite-net-pcl
- **UI Toolkit**: CommunityToolkit.Maui
- **MVVM**: CommunityToolkit.Mvvm
- **Audio**: Plugin.Maui.Audio
- **Supported Platforms**: 
  - Android (API 21+)
  - iOS (15.0+)
  - Windows (10.0.17763.0+)
  - macOS Catalyst (15.0+)

---

## 🚀 Installation

### Prerequisites

- **.NET 9.0 SDK** or later
- **Visual Studio 2022** (17.8 or later) with MAUI workload
- **Android SDK** (for Android development)
- **Xcode** (for iOS/macOS development, macOS only)

### Build Instructions

1. **Clone the repository**:
   ```bash
   git clone https://github.com/etsuwithtea/BeyondHana.git
   cd BeyondHana
   ```

2. **Restore dependencies**:
   ```bash
   dotnet restore
   ```

3. **Build the project**:
   ```bash
   dotnet build
   ```

4. **Run on specific platform**:
   ```bash
   # Android
   dotnet build -t:Run -f net9.0-android
   
   # iOS (macOS only)
   dotnet build -t:Run -f net9.0-ios
   
   # Windows
   dotnet build -t:Run -f net9.0-windows10.0.19041.0
   
   # macOS
   dotnet build -t:Run -f net9.0-maccatalyst
   ```

### Development Environment Setup

1. Install **Visual Studio 2022** with the following workloads:
   - .NET Multi-platform App UI development
   - Android SDK (if targeting Android)
   - iOS SDK (if targeting iOS, macOS only)

2. Ensure **.NET 9.0 SDK** is installed:
   ```bash
   dotnet --version
   ```

3. For Android development, configure Android SDK path in Visual Studio or via environment variables.

---

## 👥 Team

### Development Team
- **Project Lead**: [Your Name]
- **Developer**: [Team Member Names]
- **Story Writer**: [Content Creator Names]
- **Art Director**: [Artist Names]
- **Audio Designer**: [Sound Designer Names]

### Contributing
We welcome contributions! Please feel free to submit issues and pull requests. For major changes, please open an issue first to discuss what you would like to change.

---

## 📝 Notes

### Language Support
- **User Interface**: English (buttons, menus, settings)
- **Story Content**: Thai (dialogues, narration, character interactions)
- **Target Audience**: Thai speakers and international Visual Novel enthusiasts

### Technical Details
- **Database**: Pre-populated SQLite databases contain story data, character information, and game assets
- **Audio Format**: Supports WAV and MP3 files for background music and sound effects
- **Image Format**: PNG format for character sprites and backgrounds
- **Font Support**: Custom Thai and English fonts included (Itim-Regular, Caveat-Regular)

### File Structure
```
BeyondHana/
├── Models/          # Data models (Character, Dialogue, Event, etc.)
├── Views/           # UI pages and screens
├── ViewModels/      # MVVM view models
├── Data/            # Database helper classes
├── Resources/       # Assets (images, fonts, audio, databases)
│   ├── Images/      # Character sprites and backgrounds
│   ├── Fonts/       # Custom fonts
│   ├── Raw/         # SQLite databases and audio files
│   └── ...
└── ...
```

### Performance Considerations
- **Lazy Loading**: Story content is loaded chapter by chapter for optimal memory usage
- **Audio Streaming**: Background music streams efficiently without loading entire files
- **Image Optimization**: Sprites and backgrounds are optimized for different screen densities
- **Database Indexing**: Efficient queries for fast story navigation

---

## 🔗 Links

- **Repository**: [https://github.com/etsuwithtea/BeyondHana](https://github.com/etsuwithtea/BeyondHana)
- **Issues**: [Report bugs or request features](https://github.com/etsuwithtea/BeyondHana/issues)
- **Documentation**: [.NET MAUI Documentation](https://docs.microsoft.com/en-us/dotnet/maui/)

---

## 📄 License

This project is licensed under the MIT License - see the LICENSE file for details.

---

## 🙏 Acknowledgments

- **Microsoft** for .NET MAUI framework
- **Community Toolkit** for MAUI extensions
- **SQLite** for reliable local storage
- **Thai Visual Novel Community** for inspiration and support
- **All contributors** who help improve BeyondHana

---

*Built with ❤️ using .NET MAUI and .NET 9*