Contract Monthly Claim System (CMCS)
This web-based program, known as the Contract Monthly Claim System (CMCS), was developed using the ASP.NET Core MVC framework. The project's primary goal is to automate and expedite the monthly claim filing and approval process for independent contractor lecturers. The Model-View-Controller (MVC) architectural pattern was chosen for its clear separation of concerns, which makes the system structured, scalable, and maintainable.

The prototype's Graphical User Interface (GUI) is built with Bootstrap for a responsive and polished user experience. As per the POE instructions, this front-end is a non-functional prototype; it offers a visual representation without any underlying business logic.

A key design decision for user management is the use of ASP.NET Identity with its integrated scaffolding. This feature automatically generates the code for user registration, login, and account management, significantly enhancing security and development efficiency.

<hr>

Database Structure
Entity Framework Core is used to manage data interactions, with the database structured using a relational model. This approach ensures a clear schema that links users, claims, and supporting documentation.

User and Role Classes: All user types are based on the base ApplicationUser class, which includes fields managed by ASP.NET Identity (e.g., Username, Email, PasswordHash). Role-specific attributes for Lecturers, Program Coordinators, and Academic Managers are managed through this inheritance structure.

Claim: This is the core of the system, containing all information related to a monthly claim. It includes properties like ClaimId, ClaimMonth, AmountClaimed, and Status. It has a one-to-many relationship with the ApplicationUser class.

ApplicationDbContext: This class, which inherits from IdentityDbContext, acts as a bridge between the application models and the underlying SQL database. It manages the creation, querying, and updating of the user and role tables.

Document: This class is used to link a specific claim with supporting documentation (invoices, receipts, etc.). The one-to-many relationship between a claim and its documents ensures that supporting materials are securely stored and easily accessible.

This database design minimizes redundancy, guarantees data integrity, and provides a scalable framework for future expansion.

<hr>

GUI/UI Layout
The application features distinct dashboards for each user role to provide a customized user experience.

Lecturer Dashboard: This dashboard focuses on a lecturer's personal claims. It displays key statistics such as the total number of claims filed, approved claims, and outstanding claims. A table lists recent claims and their status, allowing for easy tracking.

Coordinator Dashboard: Designed for the program coordinator, this view prioritizes claims that require review. It displays the number of claims pending approval and a list of new claims to be addressed.

HR Dashboard: This dashboard is tailored for payment management, highlighting claims that have been approved and are pending payment processing.

Manager Dashboard: This dashboard provides a comprehensive overview of all claims with a ManagerDashboardViewModel that includes counts for pending, approved, and total claims. It also features a table of claims awaiting manager review.

<hr>

Assumptions and Constraints
Non-functional Prototype: The GUI is for visual design and lacks functional back-end features, as per the POE instructions.

Single-tenant System: The system is assumed to be a single-tenant application hosted on one server.

Security: While security is a design consideration, the prototype's primary focus is on the front-end layout and does not include a complete authentication and authorization system beyond the use of ASP.NET Identity scaffolding.

<hr>

Project Plan
This project plan uses the MVC (.NET Core) framework to create a non-functional front-end GUI prototype. The design will be user-friendly and intuitive, incorporating the following key components:

Phase	Task	Dependencies	Estimated Week
1. Planning & Design	1.1. Review POE Requirements and Rubric	None	Week 1
1.2. Draft Documentation (design choices, database structure, GUI layout, assumptions, and constraints)	Task 1.1	Week 2
1.3. Design UML Class Diagram for Databases	Task 1.1	Week 2
2. Prototype Development	2.1. Set up ASP.NET Core MVC Project with Identity Scaffolding	All tasks from Phase 1	Week 3
2.2. Design and implement the Lecturer Dashboard prototype	Task 2.1	Week 4
2.3. Design and implement the Coordinator/Manager Dashboard prototypes	Task 2.1	Week 5
2.4. Design and implement the HR Dashboard prototype	Task 2.1	Week 6
2.5. Design the navigation bar and layout shared across all views	Task 2.1	Week 6
3. Finalization & Submission	3.1. Write the detailed Project Plan	All tasks from Phase 2	Week 7
3.2. Review and refine all documentation	All tasks from Phase 2	Week 7
3.3. Commit changes to the GitHub repository	Ongoing throughout all phases	Weeks 1-8
3.4. Prepare and submit the final report in Microsoft Word format	All tasks from Phase 2	Week 8
Total Estimated Duration: 2 Months

<hr>

GitHub Repo & References
GitHub Repo Link: https://github.com/ThembaTshudufhadzo/PROG6212-POE-PART1.git

Referencing List

Books and Journals

Freeman, A. and Sandell, J. (2018). Pro ASP.NET Core MVC 2. 7th ed. Berkeley, CA: Apress.

Websites and Online Documentation

GitHub. (2025). Git and GitHub Documentation. Available at: https://docs.github.com/en/ (Accessed: 16 September 2025).

Mermaid. (2025). Mermaid Documentation. Available at: https://mermaid.js.org/ (Accessed: 16 September 2025).

Microsoft. (2023). ASP.NET Core Documentation. Available at: https://docs.microsoft.com/en-us/aspnet/core/ (Accessed: 15 September 2025).

Project, B. (2023). Bootstrap Documentation. Available at: https://getbootstrap.com/docs/5.3/ (Accessed: 15 September 2025).







