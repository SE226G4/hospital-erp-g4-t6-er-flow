# Software Requirements Specification (SRS) - ER-FLOW Subsystem

## 1. Introduction
### 1.1 Purpose
This document specifies the functional and non-functional requirements for the Emergency Room Flow (ER-FLOW) module. Designed as a core component of the integrated Hospital Management System, this module orchestrates emergency reception, triage tracking, and critical clinical resource assignments.

### 1.2 System Scope
The ER-FLOW subsystem automates the patient lifecycle upon emergency arrival. Its boundaries encompass:
* Patient identity logging and clinical visit activation.
* Vital signs assessment and visual triage color-coding categorization.
* Real-time allocation metrics for emergency beds and staff management.
* Secure outbound synchronization with Inpatient Admissions and Central Records.

---

## 2. Overall Description
### 2.1 Product Perspective
The ER-FLOW subsystem operates as an interdependent module within the overarching hospital ecosystem. While it encapsulates its own operational database and application logic, it relies entirely on cross-module communication channels to retrieve global files and broadcast clinical action payloads to external subsystems.

### 2.2 System Memory and Entities
The subsystem’s data persistence structure maps the following architectural entities derived from the core ERD framework:
* `PATIENT` and `EMERGENCY_VISIT` for logging admission status.
* `TRIAGE` and `DECISION_AND_ACTION` for clinical severity categorization.
* `BED` and `BED_ASSIGNMENT` for physical department resource optimization.

---

## 3. Specific Requirements (Functional Requirements)

### 3.1 Patient Reception and Registration
* **Requirement ID:** FR-ER-01
* **Description:** The system must accept basic demographic payloads to open a new emergency encounter.
* **Input Data:** Full Name, Gender, Birth Date, National ID.
* **Output Action:** Generate a distinct `Visit_ID` with an active status timestamp.

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
