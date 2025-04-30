# TallyApp  

## Project Overview  
Develop an application that **tallies user numeric inputs**, dynamically **adapts to various screen sizes and orientations** and **provides real-time summation** for enhanced usability.  

### Motivation  
Gain experience in **UI resizing techniques** and leverage the **Android Emulator** to test the application across both **phone and tablet** interfaces.  

### Goal  
Build a **responsive numeric tallying system** that ensures **smooth interaction, real-time calculations, and adaptive UI behavior** across multiple device formats.  

### Value Proposition  

## Features
- **Adaptive UI Layout**: Adjusts between portrait and landscape modes using a Grid-based design.
- **Dynamic Number Entry & Summation**: Users enter numbers via an on-screen keypad, which are tallied dynamically.
- **Formatted Numeric Display**: Entered numbers are displayed in a structured format for clarity.
- **Real-Time Updates**: The app updates the total sum instantly as numbers are entered and added.
- **MVVM Architecture**: Implements Model-View-ViewModel for data binding and scalable UI updates.
- **Command-Based Interaction**: User actions are managed via Xamarin.Forms ICommand, ensuring structured event handling.
- **Data Persistence & Reset**: Users can clear the tally, resetting entered numbers instantly.

### Core Functionalities  
- **User Input Handling**: The app processes numeric input via a keypad-driven entry model, binding values dynamically to the UI.
- **Event-Driven Summation**: Summation updates occur in real-time, leveraging data-binding principles in the ViewModel.
- **State Management**: Implements structured persistence, allowing users to reset or continue tally operations without inconsistencies.
- **UI Adaptability**: A responsive Grid-based layout ensures smooth transitions between different screen orientations.

## Architecture  

### Overview  
The system follows the **MVVM architecture**, ensuring modularity and separation of concerns:  
- **View**: UI layer displaying numeric entries and totals.  
- **ViewModel**: Manages UI interaction logic, binding user input dynamically.  
- **Model**: Handles numeric data processing and persistence.  

### Patterns  
- **MVVM**: Improves maintainability by separating UI logic from business logic.  
- **ICommand-Based Event Handling**: Ensures a scalable and structured event model.  

## Tech Stack  

### Programming Languages  
- **C#**  

### Frameworks and Libraries  
- **Xamarin.Forms**: Used for building cross-platform UI with a native-like experience.

### Tools  
- **Visual Studio Code (1.99.0)**: For writing and refining the README file.  
- **Microsoft Visual Studio Community 2022 (17.13.5)**: IDE used for creating and debugging the application.  
- **Git (2.45.1.windows.1)**: Version control system for managing code changes and tracking project history.  
- **GitHub**: Remote repository platform for storing the project and enabling centralized access.

## Installation and Usage

### Pre-requisites
1. Ensure the following are installed on your system:  
   - [.NET SDK](https://dotnet.microsoft.com/download/dotnet) (version 6.0 or later).  
   - Visual Studio 2022 Community Edition or higher with the .NET MAUI workload installed.  
   - Git (version 2.45 or later) for version control.

2. Clone the repository from GitHub:  
   ```bash
   git clone https://github.com/Learner062022/TipCalculator.git
   ```

### Step-by-step Instructions
- **Open the Project**  
  - Launch Visual Studio 2022 Community Edition.  
  - Open the cloned project by navigating to the folder containing the `.csproj` file.  

- **Build the Solution**  
  - In Visual Studio, navigate to *Build* > *Build Solution* (or use the shortcut `Ctrl + Shift + B`).  

- **Run the Application**  
  - Click the *Start* button or press `F5` to debug and run the application.  
  - The app will launch in the specified simulator/emulator or on your connected physical device.  

### Troubleshooting
- **Common Errors**  
  - **Missing Dependencies**  
    Ensure all required NuGet packages are restored by running:  
    ```bash
    dotnet restore
    ```

  - **Build Errors**  
    Confirm that all project references and bindings are correct in the `.csproj` file.  

- **Simulator Issues**  
  - Restart your development environment if the emulator/simulator fails to load.  
  - For physical devices, ensure developer mode is enabled.  

## Testing and Validation

## Limitations

- **Manual Testing Only**: All tests were performed manually.
- **Device-Specific Validation**: The app was tested solely on the emulator, real-world performance on physical devices may differ.

## Contributing

### Guidelines
- Adhere to [Google's Style Guides](https://google.github.io/styleguide/) or [Microsoft's C# Coding Conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions) for clean and maintainable code.
- Provide detailed descriptions of changes and link related issues in all pull requests.

### Branching Strategy
- Follow [Conventional Commits](https://www.conventionalcommits.org/) for commit message formatting. Use branch naming conventions such as:
  - `feature/<description>`: For new features.
  - `fix/<description>`: For bug fixes.
  - `hotfix/<description>`: For critical fixes.
- Refer to [Microsoft's Branching Guidance](https://learn.microsoft.com/en-us/azure/devops/repos/git/git-branching-guidance?view=azure-devops) or [GitKraken's Git Branching Strategies](https://www.gitkraken.com/learn/git/best-practices/git-branch-strategy) for workflows:
  - Branch off from the latest `main`.
  - Regularly sync branches with `main` and ensure thorough testing prior to pull requests.

### Pull Requests
- Submit all pull requests to the `main` branch following [GitHub's Pull Request Guide](https://docs.github.com/en/pull-requests/collaborating-with-pull-requests/getting-started/about-pull-requests).
- Ensure new features or updates are well-documented. Refer to [Atlassian's Pull Request Guide](https://www.atlassian.com/blog/git/written-unwritten-guide-pull-requests) for best practices.

## Known Issues
- Equal bill splitting only; uneven splits or additional charges per diner are not supported.
- Certain inputs, such as excessively large numbers, may not be handled gracefully.
- Limited testing across unique device configurations may result in UI inconsistencies.

## License
The project is licensed under the [GPL-3.0 License](https://www.gnu.org/licenses/gpl-3.0.en.html).