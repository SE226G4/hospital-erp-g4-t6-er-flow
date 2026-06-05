# API Specifications

## 1. Overview
The ER-FLOW module provides real-time emergency traffic orchestration, triage categorization, and clinical resource availability metrics to core hospital ERP modules, including Central Patient Records, Inpatient Admissions, and Surgery Optimization Systems.

## 2. Main Endpoints
*List the functions or endpoints your module shares with others.*

### Endpoint 1: Register Emergency Patient
* Method: POST
* What it does: Registers a new incoming patient at the ER reception and establishes a temporary emergency tracking file.
* Required Data: National ID, Full Name, Date of Birth, Gender, Primary Chief Complaint.
* Returned Data: Patient ID, Admission ID, Registration Timestamp, Triage Queue Status.

### Endpoint 2: Fetch Triage Queue
* Method: GET
* What it does: Retrieves the active list of waiting emergency patients sorted chronologically by arrival time for clinical review.
* Required Data: None (Requires authenticated Staff Session Token).
* Returned Data: Array of patient records containing Patient ID, Name, Arrival Time, and current Triage Urgency Status.

### Endpoint 3: Update Triage Severity Status
* Method: PUT
* What it does: Updates a patient's medical urgency status with an official triage color code based on clinical assessment.
* Required Data: Patient ID, Admission ID, Triage Color Code (Red, Yellow, Green), Vital Signs Payload.
* Returned Data: Triage Record ID, Update Timestamp, Assigned Urgency Level.

### Endpoint 4: Get Emergency Resource Status
* Method: GET
* What it does: Provides real-time availability metrics of emergency department critical beds and minor operating rooms.
* Required Data: None.
* Returned Data: Total Beds, Available Beds count, Occupied Beds count, Minor OR Status (Available/Maintenance/Occupied).

### Endpoint 5: Allocate Emergency Resource
* Method: PUT
* What it does: Assigns a specific available emergency bed or minor operating room to a highly prioritized critical patient.
* Required Data: Patient ID, Admission ID, Resource ID (Bed/Room Number).
* Returned Data: Allocation ID, Resource Status (Allocated), Timestamp.

### Endpoint 6: Get ER Analytics Dashboard
* Method: GET
* What it does: Generates administrative performance analytics regarding patient wait times and emergency department throughput metrics.
* Required Data: Start Date, End Date.
* Returned Data: Average Wait Time (minutes), Total Admissions, Resolution Rate, Outbound Transfer Count.
