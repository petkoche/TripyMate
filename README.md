# TripyMate
Shared travelling app.

[![Build status](https://ci.appveyor.com/api/projects/status/ytvuwrbqk4h7xpkv?svg=true)](https://ci.appveyor.com/project/petkoche/tripymate)


Who is this for ?

![Image of Main](https://2.bp.blogspot.com/-1i00rUPG70c/WeRQ8rRlkJI/AAAAAAAADEA/rQn-_mF5gxoPoFXXpSDq-pvzUKqPyLRqACLcBGAs/s1600/heading.png)

![Image of Main](https://4.bp.blogspot.com/-8g2FOijqOmQ/WeRSjSNT95I/AAAAAAAADEk/rinRZUKum6kgkv9aTfqEa3mL3SXCdJn7wCLcBGAs/s1600/HomePage.png)

Simple and easy to use.

-public part (accessible without authentication)
You can access the Home page and see the latest 3 posts.
You can also enter the Search page and find posts by StartTown and EndTown.
You can view details about the post.
You can log-in or register an account.

-private part (available for registered users)
You can view your account and change your possword.
Logged users can create/publish posts.
Everything that the public users can do.

-administrative part (available for administrators only)
Admins can do everything that the public users can do.
They can aslo visit the private admin part.
Create - View - Edit - Delete posts.

![Image of Task](https://2.bp.blogspot.com/-SLLOu2mfMZU/WeRVl5-49MI/AAAAAAAADEw/36DUVJW7lsYULtxJzGBFHdMyG53_NFUEACLcBGAs/s1600/herhe.jpg)

-Home Page - short info / call to action / partial view of the latest posts (caching is applied in the home controller)

-Seach Post - ajax unobtrusive, two partial views and one main, loads and visualizes results by two queries in a custom grid.

-Detailed post - shows time passed since the post was published, visualiazes the possible route using google maps' api, gives a brief about the driver and the trip.

-Create post- let's logged users create a post with validations applied.

-Admin func enables you to do all crud operations over the posts, uses Kendo UI.

![Image of Search](https://1.bp.blogspot.com/-4s7wFpcJJW4/WeRQ8yRfl2I/AAAAAAAADEE/8upo2hBoTaMXVSDRmjTMVny3J2OsKgq7QCLcBGAs/s1600/search.png)

![Image of Details](https://2.bp.blogspot.com/-6wieNFfKeC4/WeRSXQEfN0I/AAAAAAAADEg/uL5Vql8fzgwbeXfSBrj4jhQxVyrRFwd0gCLcBGAs/s1600/tripInfo.png)

![Image of Create](https://2.bp.blogspot.com/--PSRD9zRLQ8/WeRQ8crTr9I/AAAAAAAADD8/8rbaOfpi60E0C7s9cWGqawl_YaoCkUakACLcBGAs/s1600/create.png)

![Image of Admin1](https://4.bp.blogspot.com/-5Yx7DpWX0Tw/WeRQ69tXGEI/AAAAAAAADDw/TrhY63EqmfAIhaAb1CxkjQnzCur7deV_ACLcBGAs/s1600/Admin1.png)

![Image of Admin1](https://4.bp.blogspot.com/-NtaOJC9H5Wk/WeRQ6e-MuEI/AAAAAAAADDs/m1VR3Jp9F6sAd-MPVgq4F_gl6kO6a0GuQCLcBGAs/s1600/Admin2.png)

![Image of Validate](https://2.bp.blogspot.com/-IgJ4e-32vyc/WeRQ7qV3zfI/AAAAAAAADD4/JV7zvIH5g-s3uxngwDgBnMYh9GxsBMwAwCLcBGAs/s1600/Validations.png)

