[33mcommit 691e952a6f0fd6b4bb1aa5884fbe3284051c960f[m[33m ([m[1;36mHEAD -> [m[1;32mmaster[m[33m, [m[1;31morigin/master[m[33m)[m
Author: steveage <mariuszbia@yahoo.com>
Date:   Fri May 15 13:51:04 2020 -0500

    Added new ideas for DataAccess.

[1mdiff --git a/docs/Backlog.txt b/docs/Backlog.txt[m
[1mindex 5e01e9d..cd2c2b5 100644[m
[1m--- a/docs/Backlog.txt[m
[1m+++ b/docs/Backlog.txt[m
[36m@@ -42,8 +42,8 @@[m [mC   Hide members that should be internal. Make them visible to tests and composi[m
 C   Add user data dependency to ItemProvider.[m
 C   Replace EllCoachProvider with UserProvider.[m
 W   Write acceptance tests.[m
[31m-W   Move framework specific classes in Infrastructure to dedicated folders.[m
[31m-S   Redesign entity model to better represent real life objects and remove resemblance to no sql db objects.[m
[32m+[m[32mC   Move framework specific classes in Infrastructure to dedicated folders.[m
[32m+[m[32mC   Redesign entity model to better represent real life objects and remove resemblance to no sql db objects.[m
 -C  Change UserCreatorTests to return modified Students, Instructors, EllCoaches and Assistants.[m
     -   Remove User.Classes - school classes will be queried separately to simplify the model.[m
     -   Remove User.Type - user type such as teacher, ell coach, etc. will be only used in the dtos. The value of Type for the dto will set manually in the adapter layer.[m
[36m@@ -60,8 +60,15 @@[m [mS   Redesign entity model to better represent real life objects and remove resem[m
 -C  Add new classes to the model: Enrollment, SupportAssignment, CourseAssignment, Grade, CourseGrade, Term.[m
 -C  Decide what to do with SchoolClass. Changed SchoolClass to represent real world object and added StudentClass that was needed for many to many relation between Student and SchoolClass.[m
 [m
[31m-W  Create dtos for the corresponding new classes.[m
[31m-S  Fix item creation and assignment once model changes are finished.[m
[32m+[m[32mC  Create dtos for the corresponding new classes.[m
[32m+[m[32mC  Fix item creation and assignment once model changes are finished.[m
 -C  PersonCreator[m
 -C  PersonProvider[m
[31m--W  Convert PersonProvider into a generic class.[m
\ No newline at end of file[m
[32m+[m[32m-C  Convert PersonProvider into a generic class.[m
[32m+[m[32mW   Replace DataAnnotations with FluentValidation in UI.MVC and DataSource as explained in https://wildermuth.com/2019/11/18/Using-FluentValidation-in-ASP-NET-Core[m
[32m+[m[32mW   Make post requests return created entities instead of models.[m
[32m+[m[32mW   Set up CI as explained in https://www.youtube.com/watch?v=nNw5H31nuU0.[m
[32m+[m[32mW   Add ReverseMap() to each profile.[m
[32m+[m[32mW   Add InstructorAssistants, EllCoachInstructors and AssistantInstructor controllers with routes /Faculty/Instructor/{id}/Assistants, ...[m
[32m+[m[32mW   For read only dtos consider using flattening, f.e. add Instructor.AssistantEmail instead of using short dtos. Automapper should handle that automatically.[m
[32m+[m[32mW   Add query strings such as GetInstructors(bool includeAssistants = true)[m
\ No newline at end of file[m
