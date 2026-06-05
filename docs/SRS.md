<<<<<<< HEAD
﻿# Software Requirements Specification (SRS)
## Project: Hospital ERP System
## Module: Emergency Flow & Triage Logic
## Responsible Student: Student 03 (Process Modeling)  
**Version:** 1.0  
**Date:** 2026-05-12

---
=======
# Software Requirements Specification (SRS) - ER-FLOW Subsystem
>>>>>>> 09b789782a7748343b9e3cf4b382f5757fe0bc83

## 1. Introduction
### 1.1 Purpose
This document specifies the functional and non-functional requirements for the Emergency Room Flow (ER-FLOW) module. Designed as a core component of the integrated Hospital Management System, this module orchestrates emergency reception, triage tracking, and critical clinical resource assignments.

<<<<<<< HEAD
### 1.2 Scope
Core Goals and Benefits:
The primary goal of the Emergency Flow module is to automate the prioritization of patients based on medical urgency. This ensures life-threatening cases receive immediate attention and optimizes bed allocation through real-time system integration.

System Boundaries:
* The system WILL do:
    * Automated Triage Logic: Reorder the patient queue dynamically based on severity levels (Critical, Moderate, Minor).
    * Real-time Bed Verification: Communicate with the Bed Management module to check for availability and trigger atomic reservations.
    * Emergency Notifications: Dispatch instant alerts to medical staff for "Critical" case arrivals.
    * Performance Tracking: Calculate and log the "Response Time" for auditing purposes.

* The system WILL NOT do:
    * New Patient Registration: Relies on the external Admission Module for digital identity data.
    * Automated Medical Diagnosis: Relies on severity input provided by clinical staff.
    * Billing & Insurance: Handled exclusively by the Finance Module.


### 1.3 Definitions, Acronyms, and Abbreviations
* **Instruction:** Provide a table defining all technical terms, acronyms, or domain-specific language (e.g., medical terms, API, ERP) used in this document so all teams share a common understanding.

### 1.4 References
* **Instruction:** List all referenced documents. This must include:
  * IEEE 830 Standard.
  * Links to shared architectural documents or API contracts agreed upon with the Integration Team.

### 1.5 Overview
* **Instruction:** Briefly explain how the rest of this SRS document is organized.
=======
### 1.2 System Scope
The ER-FLOW subsystem automates the patient lifecycle upon emergency arrival. Its boundaries encompass:
* Patient identity logging and clinical visit activation.
* Vital signs assessment and visual triage color-coding categorization.
* Real-time allocation metrics for emergency beds and staff management.
* Secure outbound synchronization with Inpatient Admissions and Central Records.
>>>>>>> 09b789782a7748343b9e3cf4b382f5757fe0bc83

---

## 2. Overall Description
### 2.1 Product Perspective
The ER-FLOW subsystem operates as an interdependent module within the overarching hospital ecosystem. While it encapsulates its own operational database and application logic, it relies entirely on cross-module communication channels to retrieve global files and broadcast clinical action payloads to external subsystems.

<<<<<<< HEAD
*   **2.1.1 System Interfaces:** [List the exact integration points and APIs your module exposes to, or consumes from, other teams].
*   **2.1.2 User Interfaces:** [Describe the logical characteristics of your UI. Are you following a shared design system?].
*   **2.1.3 Hardware Interfaces:** [List any required hardware, e.g., barcode scanners for labs, or state "None"].
*   **2.1.4 Software Interfaces:** [Specify OS requirements, database dependencies, or third-party libraries].
*   **2.1.5 Communications Interfaces:** [Define networking protocols used, e.g., HTTP/REST, WebSockets].
*   **2.1.6 Memory & Operational Constraints:** [State minimum RAM, storage, and normal operating assumptions].

### 2.2 Product Functions
* **Instruction:** Provide a high-level, bulleted summary of the major functions your software performs. Do not go into deep detail here (save it for Section 3).

### 2.3 User Characteristics
* **Instruction:** Who will use your specific module? (e.g., Lab Technicians, Doctors, System Admins). Describe their technical expertise level.

#### 2.4.1 Constraints
* Logic Constraint (Severity Priority): The system must implement a severity-based sorting algorithm where the Severity Level strictly overrides the Arrival Timestamp (FIFO).
* Operational Constraint: Critical cases must trigger an immediate Emergency Alert if zero beds are available.
* Audit Constraint: Every clinical decision and status change must be logged in a non-volatile audit trail.

#### 2.4.2 Assumptions
* Accurate Severity Input: It is assumed that triage staff will provide correct classifications via the API.
* Real-time Bed Status: It is assumed that the bed database is updated in real-time to prevent double-booking.

#### 2.4.3 Dependencies
* Admission Module: Provides mandatory patient risk profiles and identity data.
* Bed Management Module: Provides real-time availability for critical allocations.
=======
### 2.2 System Memory and Entities
The subsystem’s data persistence structure maps the following architectural entities derived from the core ERD framework:
* `PATIENT` and `EMERGENCY_VISIT` for logging admission status.
* `TRIAGE` and `DECISION_AND_ACTION` for clinical severity categorization.
* `BED` and `BED_ASSIGNMENT` for physical department resource optimization.
>>>>>>> 09b789782a7748343b9e3cf4b382f5757fe0bc83

---

## 3. Specific Requirements (Functional Requirements)

### 3.1 Patient Reception and Registration
* **Requirement ID:** FR-ER-01
* **Description:** The system must accept basic demographic payloads to open a new emergency encounter.
* **Input Data:** Full Name, Gender, Birth Date, National ID.
* **Output Action:** Generate a distinct `Visit_ID` with an active status timestamp.

<<<<<<< HEAD
### 3.2 System Features & User Stories

#### 3.2.1 Feature: Smart Triage & Queue Management
* Story 1: As a Triage Nurse, I want to input severity levels so the system re-prioritizes the queue.
    * Acceptance Criteria: Critical cases jump to the top; Entry timestamps are recorded.
    * GitHub Issue: [Link to Issue #21]
* Story 2: As a Doctor, I want to receive immediate alerts for "Critical" status arrivals.
    * GitHub Issue: [Link to Issue #22]

#### 3.2.2 Feature: Dynamic Bed Allocation Logic
* Story 1: As a System Process, I want to query bed availability upon "Critical" classification to ensure assignment.
    * Acceptance Criteria: Successful allocation triggers an atomic update to "Occupied".
    * GitHub Issue: [Link to Issue #25]


### 3.3 Performance Requirements
* Re-calculation Speed: Re-order the queue in < 0.5 seconds after a status change.
* Throughput: Handle up to 50 concurrent triage updates without latency.

### 3.4 Logical Database Requirements
* **Instruction:** Describe the data entities managed by your module. If you are using a shared database, specify which tables your team is responsible for. (Include ERD models in the Appendix).

### 3.5 Software System Attributes (NFRs)
* Reliability: The triage logic must maintain 99.9% availability. If the service fails, the system must default to FIFO to ensure safety.
* Security: Access is restricted to authorized staff via Secure Token Authentication. Sensitive data is encrypted using Standard Industry Encryption Protocols.
* Maintainability: Logic is implemented via a Decoupled Service Layer and follows Clean Coding Standards to allow easy updates to medical protocols.
---

## 4. Appendices
### Appendix A: Glossary & Models
* Emergency Flow Activity Diagram:
![Emergency Flow Activity Diagram](docs/emergency-flow.jpg)
*This diagram illustrates the process logic for Student 03 (Emergency Flow & Triage).*
### Appendix B: GitHub Traceability Checklist
* **Instruction for Team Members:** Before submitting this SRS, ensure that:
  * [ ] Every User Story in Section 3.2 has a corresponding GitHub Issue.
  * [ ] Every GitHub Issue has an appropriate label (e.g., `enhancement`, `requirement`).
  * [ ] Pull Requests reference the Issue IDs (e.g., `Closes #12`). 
=======
### 3.2 Triage Severity Categorization
* **Requirement ID:** FR-ER-02
* **Description:** The system must permit designated triage officers to input physical vital signs and select an official urgency classification.
* **Urgency Levels:** Critical (Red), Moderate (Yellow), Simple (Green).
* **Output Action:** Log a timestamped `Triage_ID` bound directly to the active `Visit_ID`.

### 3.3 Emergency Bed Allocation
* **Requirement ID:** FR-ER-03
* **Description:** The system must track active clinical bed availability states and map specific rooms to high-priority emergency cases.
* **Output Action:** Transform `BED` availability attribute fields to occupied and create a `BED_ASSIGNMENT` bridging log.

---

## 4. System Interface and Integration Requirements

### 4.1 Integration Endpoints (APIs)
The module exposes dedicated REST API endpoints to facilitate interaction with external subsystems:
* `POST /api/er/patient/register` - Establishes incoming temporary encounter records.
* `PUT /api/er/triage/severity` - Commits definitive clinical color-coded classifications.
* `GET /api/er/resource/status` - Exposes live bed inventory metrics to the central hub.

---

## 5. Non-Functional Requirements (NFRs)

### 5.1 Performance & Reliability
* **Response Latency:** Triage status updates and local bed assignment logs must reflect in the system dashboard within less than 1.5 seconds.
* **Availability:** The subsystem interface must support continuous, high-availability operation profiles corresponding to the 24/7 nature of emergency departments.

### 5.2 Security & Data Integrity
* **Access Control:** System interaction modes are strictly bounded by user roles (`Staff_ID`), limiting triage logging to certified Triage Officers and bed tracking to Department Administrators.
* **Interface Protocol:** All cross-module data streams must utilize secure transmission payloads, strictly avoiding direct database mutations across foreign subsystems.
>>>>>>> 09b789782a7748343b9e3cf4b382f5757fe0bc83
