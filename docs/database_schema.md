# Database Schema

## 1. Entity-Relationship Diagram (ERD)
*The native structural database models and detailed diagrams can be accessed through the dedicated workspace:*

[Click here to open the ERD directory](diagrams/erd/.)

## 2. Tables List
*List the main tables in your database as structured in the Entity Relationship Diagram:*

| Table Name | Purpose / Description |
| :--- | :--- |
| PATIENT | Stores essential demographic information including Patient ID, Name, Gender, and Birth Date. |
| EMERGENCY_VISIT | Manages active and discharged emergency department visits, tracking arrival timestamp and visit status. |
| TRIAGE | Logs vital triage classification sessions, tracking urgency levels (Critical, Moderate, Simple) and assessment timestamps. |
| STAFF | Holds record files for active emergency personnel, filtering by system roles such as Triage Officer or Administrator. |
| DECISION_AND_ACTION | Tracks clinical pathways and operation outcomes, including bed routing, staff alerts, and triage re-ordering. |
| BED_ASSIGNMENT | Handles the temporary lifecycle allocation of emergency beds, managing assignment and discharge timestamps. |
| BED | Maintains physical inventory tracking for emergency room beds, identifying specific room numbers and live availability status. |
| BED_ASSIGNMENT_EMERGENCY_VISIT | Associative bridge table mapping the relationship records between emergency visits and specific bed allocations. |
| DECISION_AND_ACTION_EMERGENCY_VISIT | Associative bridge table mapping clinical decisions and action events directly to their respective emergency visits. |

## 3. Shared Data (Integration Points)
*Which tables or data do you share with other teams?*
* Shared Table/ID: Patient_ID (From PATIENT table)
* Shared With: Patient Records Module

* Shared Table/ID: Visit_ID (From EMERGENCY_VISIT table)
* Shared With: Inpatient Admissions Module and Surgery Optimization System
