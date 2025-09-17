PROG6212 POE PART1
ST10461617
Tshudufhadzo Themba
 

1. Documentation 

This section provides a detailed explanation of your design choices, database structure, and GUI layout, as required for your POE.  

Project Overview and Design Choices 

The web-based program known as the Contract Monthly Claim System (CMCS) was developed using the ASP.NET Core MVC framework. The Model-View-Controller (MVC) architectural pattern, which encourages a clear separation of concerns and makes the system more structured, scalable, and maintainable, is why this framework was selected. The system's main goal is to automate and expedite independent contractor lecturers' monthly claim filing and approval procedure. 

The design uses Bootstrap for the Graphical User Interface (GUI), or front-end, to produce a responsive and polished user experience. The prototype focuses on the user flow and visual layout for the many user roles, including HR, Academic Manager, Program Coordinator, and Lecturer. According to the POE, this front-end design is non-functional; it only offers a visual representation without any business logic in place. 

Using ASP.NET Identity with its integrated scaffolding is a crucial design decision for user management. This functionality greatly improves the application's security and development efficiency by automatically generating the code required for user registration, login, and account management. I was able to swiftly develop a strong authentication system by scaffolding the identity pages, which is a crucial prerequisite for a multi-user application. 

 

Database Structure 

Entity Framework Core is used to handle data interactions and a relational model is used to build the database structure. A clear schema that connects relevant elements, including users, claims, and supporting documentation, is made possible by this method. This structure is based on the ApplicationUser, Claim, and Document core classes from the supplied code. 

 

User and Role Classes: All user types are based on the User class, which has ASP.NET Identity-managed fields including Username, Email, and PasswordHash. Classes that derive from User are used to represent the various user jobs (Lecturer, Program Coordinator, and Academic Manager). Using the fundamental identity functionality and managing role-specific attributes effectively is possible with this inheritance architecture. 

 

Claim: The core of the system, this class contains all the information pertaining to a lecturer's monthly claim. ClaimId, ClaimMonth, AmountClaimed, and Status are some of its properties. In order to track the claim's lifecycle, it also has nullable attributes for approval dates and denial grounds. Every claim is accurately linked to a particular user thanks to the one-to-many relationship with the Lecturer class. 

 

ApplicationDbContext: This class, which is derived from IdentityDbContext, acts as a link between the SQL database underneath the application and its models. It oversees the ApplicationUser and IdentityRole tables' creation, querying, and updating. 

 

Document: This class is used to associate a particular claim with supporting documentation (such as invoices and receipts). A key component of the database design is the one-to-many link between a claim and its documents, which guarantees that the supporting documentation for each claim is safely kept and readily accessible. 

 

In addition to minimizing redundancy and guaranteeing data integrity, this database design offers a scalable framework for future expansion when new features are added. 

 
The ApplicationDbContext manages the lifecycle of the database tables for ApplicationUser and IdentityRole. The one-to-many relationship between ApplicationUser and Claim ensures that each claim is correctly associated with a specific user. This structure provides a clear data model for the application.
 

 

GUI/UI Layout 

To offer a customized user experience, the program has distinct dashboards for each position. Every dashboard prototype is made to offer a brief, concise summary of pertinent data. 

Dashboard for Lecturers: The lecturer's own assertions are the main emphasis of this dashboard. It shows important statistics like the overall number of claims filed, approved claims, and outstanding claims. A list of recent claims along with their status is displayed in the table below, making it simple for professors to keep track of their submissions. 

 

Coordinator Dashboard: This view, which is intended for the program coordinator, ranks the claims that require examination. It displays the number of claims that are still awaiting approval as well as a list of claims that need to be addressed. They can easily recognize and handle new submissions thanks to this arrangement. 

 

HR Dashboard: The HR dashboard is designed specifically for payment management. Claims that have been accepted and are pending payment processing are highlighted. 

 

Manager Dashboard: With data for PendingClaimsCount, ApprovedClaimsCount, and TotalClaimsCount, this dashboard offers a comprehensive picture of all claims. Claims that are pending manager evaluation are shown in a table. 

Each user may easily access the information and actions most pertinent to their function thanks to this simple, user-friendly interface. 

Assumptions and Constraints 

Non-functional Prototype: According to the POE instructions, the main presumption is that the GUI is only for visual design and lacks any functional back-end features. 

 

Single-tenant System: One server is thought to host the system, which is a single-tenant application. 

 

Although security is a design issue, the prototype focuses on the front-end layout and does not yet have a complete authentication and authorization system in place, aside from the use of ASP.NET Identity scaffolding. 

 

2. UML Class Diagram for Databases 

This diagram illustrates the relationship between the key database-related classes from your provided code. This represents the data layer of your application. 

 

 

Key Relationships: 

ApplicationDbContext and DbSet: ApplicationUser and IdentityRole are connected to ApplicationDbContext through a composition connection (*--*) that is established using DbSet. This shows that these database tables and their lifecycle are managed by ApplicationDbContext. 

 

ApplicationUser and IdentityRole: The Identity Framework's built-in connection tables give ApplicationUser and IdentityRole a one-to-many relationship. A user can be allocated more than one role thanks to this association, for example, both Coordinator and Lecturer. 

 

Claim and ManagerDashboardViewModel: Data for the manager's dashboard view is stored in the ManagerDashboardViewModel Data Transfer Object (DTO). A list of claims is passed from the controller to the view via Claim objects, and the results are shown in the "Claims to be Reviewed" table. Since a single ManagerDashboardViewModel object might have a list of numerous Claim objects, this relationship is displayed as a one-to-many association. 

 

 

 

3. ProjectPlan 

The MVC (.NET Core) framework will be used to create a non-functional front-end prototype of the GUI. The suggested method will be visually represented by the design, which will be easy to use and intuitive. It will have the following essential components: 

Lecturer View: An interface that allows lecturers to submit their claims with a click of a button. 

 

Coordinator/Manager View: A separate view that enables Programme Coordinators and Academic Managers to easily verify and approve claims. 

 

Document Upload: A feature that visually represents how lecturers can upload supporting documents for their claims. 

 

Claim Tracking: A graphic component that illustrates how the status of a claim may be openly monitored until it is resolved. 

Consistency: The system's architecture will make sure that it seems to deliver accurate and consistent data. 

 

Project plan 

 

Phase 

Task 

Dependencies 

Estimated Week 

Status 

1. Planning & Design 

1.1. Review POE Requirements and Rubric 

None 

Week 1 

Completed 

 

1.2. Draft Documentation (design choices, database structure, GUI layout, assumptions, and constraints) 

Task 1.1 

Week 2 

Completed 

 

 

1.3. Design UML Class Diagram for Databases 

Task 1.1 

Week 2 

Completed 

 

2. Prototype Development 

2.1. Set up ASP.NET Core MVC Project with Identity Scaffolding 

All tasks from Phase 1 

Week 3 

Completed 

 

 

2.2. Design and implement the Lecturer Dashboard prototype 

Task 2.1 

Week 4 

Completed 

 

2.3. Design and implement the Coordinator/Manager Dashboard prototypes 

Task 2.1 

Week 5 

Completed 

 

2.4. Design and implement the HR Dashboard prototype 

Task 2.1 

Week 6 

Completed 

 

2.5. Design the navigation bar and layout shared across all views 

Task 2.1 

Week 6 

Completed 

3. Finalization & Submission 

3.1. Write the detailed Project Plan 

All tasks from Phase 2 

Week 7 

In Progress 

 

3.2. Review and refine all documentation 

All tasks from Phase 2 

Week 7 

In progress 

 

3.3. Commit changes to the GitHub repository 

Ongoing throughout all phases 

Weeks 1-8 

Waiting 

 

3.4. Prepare and submit the final report in Microsoft Word format 

All tasks from Phase 2 

Week 8 

Waiting 

 

Total Estimated Duration 

 

2 Months 

 

 
 

GITHUB Repo link: 

https://github.com/ThembaTshudufhadzo/PROG6212-POE-PART1.git 

Referencing List 

Books and Journals 

Freeman, A. and Sandell, J. (2018). Pro ASP.NET Core MVC 2. 7th ed. Berkeley, CA: Apress. 

Websites and Online Documentation 

GitHub. (2025). Git and GitHub Documentation. Available at: https://docs.github.com/en/ (Accessed: 16 September 2025). 

Mermaid. (2025). Mermaid Documentation. Available at: https://mermaid.js.org/ (Accessed: 16 September 2025). 

Microsoft. (2023). ASP.NET Core Documentation. Available at: https://docs.microsoft.com/en-us/aspnet/core/ (Accessed: 15 September 2025). 

Project, B. (2023). Bootstrap Documentation. Available at: https://getbootstrap.com/docs/5.3/ (Accessed: 15 September 2025). 

 