# Module Name: Emergency Room Flow Management (ER-FLOW)
## Project: Hospital ERP System
**Module Code:** ER-FLOW-06

---

##  Module Overview
The **ER-FLOW** module automates and manages patient traffic within the hospital's Emergency Department, starting from the moment of arrival and registration at reception. It features an intelligent triage system that prioritizes patients based on medical urgency using a standardized color-coding algorithm. Furthermore, it automatically allocates critical cases to available beds and minor operating rooms to minimize overcrowding and bottlenecking, while providing administrative dashboards for monitoring patient wait times and overall department efficiency.

---

##  Team Members & Responsibilities
*Tasks have been strategically distributed among the 6 team members to cover all analysis and architectural requirements under the team leader's coordination:*

| Member Name | Primary Responsibility | Assigned Tasks (Examples) | GitHub Profile |
| :--- | :--- | :--- | :--- |
| **Jaafar Alfandi (Leader)** | Integration & Architecture | Component Diagrams, API Specs, GitHub Organization, Team Coordination | [Link](https://github.com/jaafaralfandi) |
| **Zynalabdyn Mansour** | Requirements & Analysis | Functional & Non-Functional Requirements, Use Case Diagrams | [Link](https://github.com/zynalabdynmnswr151-byte) |
| **Maya Adanouv** | Process Modeling | Activity Diagrams (BPMN for Triage & Patient Flow), Business Rules | [Link](https://github.com/mayaadanouv) |
| **Nagham Alibrahim** | Data Design | Entity Relationship Diagram (ERD), Database Schema, Class Diagrams | [Link](https://github.com/Nagham-Alibrahim) |
| **Mary Hussain** | Dynamic Modeling | Sequence Diagrams (Patient Registration & Triage Logic Flow) | [Link](https://github.com/maryhussain) |
| **Farah Ageeb** | UI/UX & Frontend | UI Wireframes (Reception, Medical Staff Portal, Admin Dashboard) | [Link](https://github.com/farah-ageeb) |

---

##  Analysis & Design Progress
- [x] **Requirement Elicitation:** Completed list of FRs/NFRs for ER-FLOW.
- [x] **UML Behavioral Diagrams:** Use Case and Activity Diagrams (Triage Flow).
- [x] **UML Structural Diagrams:** ERD, Class Diagrams, and Component Diagram.
- [x] **Dynamic Modeling:** Sequence Diagrams for core emergency processes.
- [x] **Interface Design:** Low-fidelity Wireframes for Emergency Dashboards.

---

##  Architectural Design

### 1. Architectural Description
The architecture of **ER-FLOW** follows a strict 3-tier pattern to guarantee high performance, clear separation of concerns, and rapid system responsiveness essential for emergency environments. The presentation layer (Client Layer) communicates with the backend services through a standardized interface called the `Emergency API`. Data operations are completely isolated within a dedicated `Database Access Component`, ensuring robust security, maintainability, and seamless database schema upgrades.

### 2. Component Diagram
<img width="1030" height="513" alt="ER-FLOW Component Diagram" src="https://github.com/user-attachments/assets/97d00c5b-370a-4d25-86e4-9dc738c2af2a" />

---

##  Integration & API Specifications

### 1. Emergency API Specifications
The following table outlines the core REST API endpoints that connect the client interfaces with the backend services as modeled in the structural architecture:

| HTTP Method | API Endpoint | Description | Component Source |
| :--- | :--- | :--- | :--- |
| **POST** | `/api/patients/register` | Registers a new incoming patient and creates a temporary ER file. | `Reception Dashboard` |
| **GET** | `/api/triage/queue` | Fetches the list of waiting patients sorted by arrival timestamp. | `Medical Staff Portal` |
| **PUT** | `/api/triage/assign-color` | Updates a patient's severity status with a triage color (Red, Yellow, Green). | `Medical Staff Portal` |
| **GET** | `/api/resources/beds/status`| Retrieves real-time availability of ER beds and minor operating rooms. | `Resource & Bed Allocator` |
| **PUT** | `/api/resources/beds/allocate`| Assigns a designated bed or room to a prioritized critical patient. | `Resource & Bed Allocator` |
| **GET** | `/api/admin/analytics` | Generates analytics on patient wait times and performance metrics. | `Admin Dashboard` |

### 2. External Integration Points
*How the ER-FLOW module interacts with other core hospital systems:*
* **Inbound:** Fetches existing demographic data and medical histories from the central [Patient Records Module] to minimize data entry duplication during emergency admissions.
* **Outbound:** Dispatches real-time routing payloads to the [Inpatient Admissions Module] and [Surgery Optimization System] when patients require hospital admission or major operating theatre scheduling.

---
##  Tools Used
* **Modeling:** Visual Paradigm / Draw.io.
* **Documentation:** Markdown (GitHub Readme).
* **Version Control:** GitHub (SE226G4 Organization / G4-Integration Team).
