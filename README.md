# EditorialService

Welcome to the project EditorialServiceIn this web API you'll find all proposed endpoints
in the technical exam of Zemoga for Backend developers. 

## Prerequirements

- [Visual Studio 2022](https://visualstudio.microsoft.com/es/vs/community/)
- [.NET 6.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- [Postman](https://www.postman.com/)

## How To Run
After install Visual Studio and the SDK:
- clone The project
```bash
> git clone https://github.com/oramirez1512/EditorialService
```
```bash
> git checkout main
```
- Open the file EditorialService
- Right click in the solution folder ->Build the solution
- Run the project

## Endpoints
This API contains 3 Endpoints groups  
### Published:
 Contains all functionalities for pusblished posts:
- GetPublishedPost: Return all approved posts.
- AddComment: add a comment on a approved post.
### Writers:
 Contains all functionalities for Writers:
- GetPostByAuthorId: Return all my posts.
- CreatePost: create a new post.
- EditPost: edit a post without submited.
- SubmitPost: create a new post.
### Editors:
 Contains all functionalities for Editors:
- GetPendingdPosts: Return all pending posts for review.
- AddComment: add a comment on a pending post.
- ApprovePost: Approve a post for be published.
- RejectPost: Reject a post and return for edit.

## Time of development:
This project was begun 09/31/2022 6:00 pm and finished in time of the last commit date in this repo
```bash
Time: 27H AVG.
```
## Deployed:
This app is currently deployed in Heroku with the URL:
```bash
https://editorialservice.herokuapp.com
```
If you can use a deployed service, use postman with the next format:
```bash
https://editorialservice.herokuapp.com/<Controller>/<Action>
```
## Data for test:
> This Api use BasicAuth protocol for authentication.
> Please login in the Authorization option with a registred user. 
> For authenticate, use any of the next credentials:
- For writer: userName: Writer1, Password: 123Writer
- For editor: userName: Editor1, Password: 123Editor
- For commentarist(can??t approve or create post): userName:Commentarist1, Password: 123Commentarist
 