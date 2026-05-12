# Software Requirements Specification (SRS)
## Project: Hospital ERP System
## Module: Emergency Flow & Triage Logic
## Responsible Student: Student 03 (Process Modeling)  
**Version:** 1.0  
**Date:** 2026-05-12

---

## 1. Introduction
### 1.1 Purpose
* **Instruction:** Describe the specific purpose of this document. Who is the intended audience? If you are a subsystem team, explain how this document defines your specific module. If you are the Integration Team (Team Leaders), explain how this document governs the entire system.

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

---

## 2. Overall Description
### 2.1 Product Perspective
* **Instruction:** Explain how your software fits into the bigger picture. 
  * **For Subsystem Teams:** State clearly that your module is a component of a larger system. How does it interact with the master database or other modules?
  * **For the Integration Team:** Provide the high-level block diagram showing all subsystems and their connection points.

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

---

## 3. Specific Requirements (Agile Approach)
* **Instruction:** This section translates traditional functional requirements into Agile User Stories. Every feature must be traceable to the project management board.

### 3.1 External Interface Requirements
* **Instruction:** Detail the exact data formats, API endpoints, and UI layouts needed for the interfaces mentioned in section 2.1.

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