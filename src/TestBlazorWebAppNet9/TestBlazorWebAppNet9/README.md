# testing-aspnet-blazor-net9
Test project for blazor net9

## Repo steps:

1. Created new project.
1. Add single line to map path base in Project.s
1. Fix up the base tag in App.razor.  I pulled this from httpContext instead of hard coding.  This works correctly.
1. Run project and it (pre) renders correctly in static mode.
1. No interactive functionality.  Can't increment counter page.
1. Interaction shows Blazor 405 (Screenshot attached)
1. Fix that by Add UseRouting()
1. Program appears to work, but will fail behind proxy
1. The Browserlink is retrieved without correctly using pathbase
