# **BetterFacebookWinForms**

## **Overview**
BetterFacebookWinForms is a C# WinForms application developed as part of the **"Practical Programming using Design Patterns"** course. The project integrates with the **Facebook API** and demonstrates the use of **design patterns** to create a modular and maintainable application.

The application allows users to log in to their Facebook accounts and perform various operations, such as analyzing likes, calculating compatibility percentages with friends, displaying statistics, and managing a recycle bin for deleted items.

## **Technologies Used**
- **Programming Language**: C#
- **Libraries & APIs**: Facebook API, Windows Forms
- **MultiThreading**: Improves performance and responsiveness when retrieving data from Facebook
- **Data Binding**: Connects Facebook data to UI components dynamically
- **Design Patterns Implemented**:
  - **Singleton** – Ensures a single instance of the recycle bin
  - **Observer** – Decouples dependencies between the recycle bin and objects that listen for changes
  - **Adapter** – Provides a unified interface for different object types
  - **Iterator** – Enables flexible iteration over the recycle bin's collection

## **Design Patterns Implementation**

### **Singleton – Managing a Single Instance of the Recycle Bin**
- **Purpose:** The recycle bin must be globally accessible throughout the application.
- **Implementation:** The **RecycleBinForm** class maintains a static instance accessible via **Instance**, ensuring all references point to the same object.

### **Observer – Decoupling the Recycle Bin from Listening Objects**
- **Purpose:** The recycle bin handles various object types (friends, pages, events, etc.) and must avoid direct dependencies on them to support scalability.
- **Implementation:**
  - **RecycleBinForm** acts as a **Notifier**, maintaining a list of objects implementing **IRestorableFacebookObjectBase**.
  - Classes that need to track recycle bin changes implement **IRestoreListener**.
  - When an object is restored, the recycle bin triggers **notifyListener()**, updating all registered observers accordingly.
  - This design allows new object types to be added without modifying **RecycleBinForm**.

### **Adapter – Providing a Unified Interface for Different Objects**
- **Purpose:** The application works with various Facebook objects (User, Page, Album, Group, Event) and requires a unified way to access their data.
- **Implementation:**
  - An interface **IRestorableFacebookObjectBase** was created to standardize relevant information.
  - **RestorableFacebookObject** serves as an **Adapter**, wrapping **FacebookObject** to present a consistent API for all object types.
  - **RecycleBinForm** interacts with this interface without needing to know the specific object type.

### **Iterator – Flexible Traversal of the Recycle Bin Collection**
- **Purpose:** Allows generic iteration over the deleted objects while enabling future changes to the underlying data structure.
- **Implementation:**
  - **RecycleBinForm** implements **IEnumerable**, providing an **Enumerator** for iterating over deleted objects.
  - Any class can iterate over objects using **foreach** without knowing how they are stored.
  - This approach allows switching the underlying data structure (e.g., from **List** to **Dictionary**) without modifying dependent code.

## **Conclusion**
BetterFacebookWinForms showcases advanced design pattern usage and best practices for developing modular, scalable, and maintainable software. The integration with **Facebook API** enables real-time data interaction, while the applied design patterns contribute to a structured and extensible system.
