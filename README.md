# Module Name: Emergency Room Flow Management (ER-FLOW)
## Project: Hospital ERP System
**Module Code:** ER-FLOW-06

---

## Module Overview
The ER-FLOW module automates and manages patient traffic within the hospital's Emergency Department, starting from the moment of arrival and registration at reception. It features an intelligent triage system that prioritizes patients based on medical urgency using a standardized color-coding algorithm. Furthermore, it automatically allocates critical cases to available beds and minor operating rooms to minimize overcrowding and bottlenecking, while providing administrative dashboards for monitoring patient wait times and overall department efficiency.

---

## Team Members, Task Assignment & Issues
*Tasks have been strategically distributed and tracked via GitHub Issues among the 6 team members under the team leader's coordination:*

| Member Name | Primary Responsibility | Assigned Tasks & Deliverables | GitHub Issue | GitHub Profile |
| :--- | :--- | :--- | :--- | :--- |
| **Jaafar Alfandi (Leader)** | Integration & Architecture | Component Diagrams, API Specs, GitHub Organization | #2 | [Link](https://github.com/jaafaralfandi) |
| **Zynalabdyn Mansour** | Requirements & Analysis | Functional & Non-Functional Requirements, Use Case Diagrams | #3 | [Link](https://github.com/zynalabdynmnswr151-byte) |
| **Maya Adanouv** | Process Modeling | Activity Diagrams (Triage Flow & Patient Routing), Business Rules | #4 | [Link](https://github.com/mayaadanouv) |
| **Nagham Alibrahim** | Data Design | Entity Relationship Diagram (ERD), Database Schema, Class Diagrams | #5 | [Link](https://github.com/Nagham-Alibrahim) |
| **Mary Hussain** | Dynamic Modeling | Sequence Diagrams (Patient Registration & Triage Logic Flow) | #6 | [Link](https://github.com/maryhussain) |
| **Farah Ageeb** | UI/UX & Frontend | UI Wireframes (Reception, Medical Staff Portal, Admin Dashboard) | #7 | [Link](https://github.com/farah-ageeb) |

---

## User Stories & Scope
*The core system requirements mapped out as Agile User Stories tied directly to project tracking issues:*

* **US-01 Architecture & Specs (#2):** As an Architect, I want to map the 3-tier system components and endpoints so that the development team has a clear blueprint for integration.
* **US-02 Scope & Elicitation (#3):** As an Analyst, I want to document the full FRs/NFRs and system boundaries so that the development scope remains clear.
* **US-03 Patient Flow & Rules (#4):** As a Process Modeler, I want to trace the triage process and color-coding logic step-by-step so that clinical staff flow is optimized.
* **US-04 Data Integrity (#5):** As a Data Designer, I want to map the entities and constraints so that ER records are saved securely without data redundancy.
* **US-05 Object Interaction (#6):** As a System Designer, I want to outline object communication during ER checkout so that data flows correctly across architectural layers.
* **US-06 Interface Design (#7):** As a UI/UX Designer, I want to wireframe dashboards so that hospital staff can easily track live ER traffic and metrics.

---

## Analysis & Design Progress (Linked to User Stories)
- [x] **Requirement Elicitation:** Completed list of FRs/NFRs for ER-FLOW. (Tracked in User Story #3)
- [x] **UML Behavioral Diagrams:** Use Case Diagram (Tracked in #3) and Activity Diagrams (Tracked in #4).
- [x] **UML Structural Diagrams:** ERD (Tracked in #5), Class Diagrams (Tracked in #5), and Component Diagram (Tracked in #2).
- [x] **Dynamic Modeling:** Sequence Diagrams for core emergency processes. (Tracked in #6)
- [x] **Interface Design:** Low-fidelity Wireframes for Emergency Dashboards. (Tracked in #7)

---

## Architectural & Technical Specifications

### 1. Architectural Description
The architecture of ER-FLOW follows a strict 3-tier pattern to guarantee high performance, clear separation of concerns, and rapid system responsiveness essential for emergency environments. The presentation layer (Client Layer) communicates with the backend services through a standardized interface called the Emergency API. Data operations are completely isolated within a dedicated Database Access Component, ensuring robust security, maintainability, and seamless database schema upgrades.

### 2. Emergency API Specifications
The following table outlines the core REST API endpoints that connect the client interfaces with the backend services as modeled in the structural architecture:

| HTTP Method | API Endpoint | Description | Component Source |
| :--- | :--- | :--- | :--- |
| **POST** | `/api/patients/register` | Registers a new incoming patient and creates a temporary ER file. | `Reception Dashboard` |
| **GET** | `/api/triage/queue` | Fetches the list of waiting patients sorted by arrival timestamp. | `Medical Staff Portal` |
| **PUT** | `/api/triage/assign-color` | Updates a patient's severity status with a triage color (Red, Yellow, Green). | `Medical Staff Portal` |
| **GET** | `/api/resources/beds/status`| Retrieves real-time availability of ER beds and minor operating rooms. | `Resource & Bed Allocator` |
| **PUT** | `/api/resources/beds/allocate`| Assigns a designated bed or room to a prioritized critical patient. | `Resource & Bed Allocator` |
| **GET** | `/api/admin/analytics` | Generates analytics on patient wait times and performance metrics. | `Admin Dashboard` |

### 3. External Integration Points
*How the ER-FLOW module interacts with other core hospital systems:*
* **Inbound:** Fetches existing demographic data and medical histories from the central [Patient Records Module] to minimize data entry duplication during emergency admissions.
* **Outbound:** Dispatches real-time routing payloads to the [Inpatient Admissions Module] and [Surgery Optimization System] when patients require hospital admission or major operating theatre scheduling.

---

## Project Deliverables & Source Directories
*Click on the folder links below to open each team member's dedicated GitHub directory containing all native source files (.vpp, .drawio, .xml, and images) for individual evaluation:*

* **[Download Use Case Workspace - Assigned to Zynalabdyn Mansour](./docs/diagrams/use_case/)**
* **[Download Activity Workspace - Assigned to Maya Adanouv](./docs/diagrams/activity/)**
* **[Download ERD & Class Diagrams Workspace - Assigned to Nagham Alibrahim](./docs/diagrams/erd/)**
* **[Download Component Workspace - Assigned to Jaafar Alfandi](./docs/diagrams/component/)**
* **[Download Sequence Workspace - Assigned to Mary Hussain](./docs/diagrams/sequence/)**
* **[Download UI Wireframes Workspace - Assigned to Farah Ageeb](./docs/diagrams/ui/)**

---
## Tools Used
* **Modeling:** Visual Paradigm / Draw.io.
* **Documentation:** Markdown (GitHub Readme).
* **Version Control:** GitHub (SE226G4 Organization / hospital-erp-g4-t6-er-flow).
