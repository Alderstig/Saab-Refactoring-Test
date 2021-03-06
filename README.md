# Refactoring Test

## Assignment
You work within a team and are assigned a ticket created by the product owner as part of your sprint work.
The ticket says:

---

### Refactor Ticket Service
The ticket service functionally works well and the function and logic of it must not change. However it requires refactoring to improve readability. When refactoring, focus on applying clean code principles. The final result should be something ready to merge into the next release of the product and meets the definition of done. You are free to define the definition of done for yourself.
Keep in mind principles such as SOLID, KISS, DRY and YAGNI.

#### Limitations
Due to dependencies in other areas of the larger product, there are a few limitations that must be followed during the refactoring:

1. The contents of Program.cs cannot change at all including using statements.
2. The EmailService project cannot be changed
3. The method signatures in the repositories cannot change
4. The TicketRepository must remain static

---

Please submit your refactored code to us via a method of your choice (repository link, cloud share, zip file, etc.) prior to an interview to allow us to review it.
Note that while you can clone this repository, you cannot create a branch or commit any code to the repository. It is read only.

Try to limit time spent on this exercise to a maximum of 3 hours. If there is anything you don't have time to complete, write it down and we can discuss it during the interview.

Good Luck!

# Performed Test
This test was performed by Philip Alderstig. Gothenburg, Sweden 2022-04-10

##Actions Taken
1. I started by looking through the code to get a general understanding of the project.
2. I then removed comments i thought were ?unneccesary?.
3. I renamed variables i thought were ?unclear? to make the code more easily readable and to make it easier to understand the functionality.
4. I noticed repeated code/functionality and instead made it a method to make the code more easily readable and to reduce lines of code.
5. I made interfaces for userRepository and ticketService (not to ticketRepository due to it being static) to facilitate future expansion of the project according to the Open / Closed principle and the Interface segregation principle.
6. I divided files into corresponding folders to clean up and add structure to working tree.