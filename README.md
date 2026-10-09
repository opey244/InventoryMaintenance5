# Opey Obute Inventory Maintenance Assignment 5

Open InventoryMaintenance.sln in Visual Studio with the .NET desktop development workload and .NET 8 support. Build and run the project.

## Completed features
- LINQ sorting by Description for all four price filters.
- Under $10, inclusive $10 to $50, and over $50 filters.
- LINQ First lookup by selected display text for correct deletion after sorting or filtering.
- Personalized main-form title and name comments above method signatures.
- InventoryItems.txt is Content and copies to the output directory if newer.

The working inventory is stored beside the executable in InventoryItems.txt. Sorting changes only the display order. The source file seeds the output on build; additions and deletions update the output copy. Creeping Phlox was added and deleted during testing; the submitted inventory contains the original four records.

## Verification
Build: zero warnings and errors. UI checks covered adding Creeping Phlox, all filters, correct delete confirmation, canceling deletion, and confirming deletion. Additional checks covered exactly $10 and $50, empty inventory, and preservation of the underlying list order.

## Submission
Upload opey_obute_assignment5.doc to Canvas. Upload this project to your GitHub repository and submit the repository link. Make the repository public or grant the instructor and TA access.
