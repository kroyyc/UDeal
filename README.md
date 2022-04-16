# UDeal

UDeal is a post-sedondary student only second-hand buy and sell platform

UDeal is built using ASP.NET and it requires an installation of .NET 5.0. It is most easily ran using Visual Studio:

1. Open Visual Studio and select "Clone a repository"

![image](https://user-images.githubusercontent.com/47361247/163654323-2a772e61-be46-4447-9517-a11a171ae2d3.png)
  
2. Copy and paste the link for the repo here and click clone

![image](https://user-images.githubusercontent.com/47361247/163654378-e1c018f1-f7a0-4fb6-9d7b-4de3cfcfdb6d.png)

3. Double click `UDeal.sln` in your Solution Explorer

![image](https://user-images.githubusercontent.com/47361247/163654427-a6c11496-34a1-4ee3-98ed-a7616706c384.png)

4. Switch branches to 'demo' which comes with a pre-seeded database

![image](https://user-images.githubusercontent.com/47361247/163654492-958d5f3b-d6f0-4c4e-a1df-e6299d5b91e0.png)

6. Run the project by clicking the play button at the top of the IDE

![image](https://user-images.githubusercontent.com/47361247/163654475-c9298e0a-afcf-4f7d-9b39-d1d634dae858.png)

7. You should see a web broswer open with the UDeal UI

![image](https://user-images.githubusercontent.com/47361247/163657026-946d554b-8738-4d50-85e0-d5e3408791c1.png)

You will see the seeded posts and can begin searching through. If you wish to view the details of the posts (contact info, description, etc) you must be logged in. We have provided a couple accounts of different roles, otherwise you can create a new account.

 
Admin account - who can manage which schools, campuses, and posts are within the system.
```
admin@email.local
Admin123!
```

Moderator account - who have the ability to delete posts made by their classmates. i.e this moderator can only manage UCalgary posts.
```
moderator@ucalgary.ca
Moderator123!
```

Student account - who can only create, edit and delte their own posts.
```
student@ucalgary.ca
Test123!
```

To create an account, you must provide an email which matches the port-secondary institution domain. For example, a UCalgary account must end in '@ucalgary.ca'

![image](https://user-images.githubusercontent.com/47361247/163658188-f279be0c-30c4-4c0d-a931-1a93e93daa95.png)

Once you register you need to click the "confirm email" link. In a production system, UDeal would send a verification email so for demo purposes you can use a fake email.

![image](https://user-images.githubusercontent.com/47361247/163658250-c5a2f0ca-8779-4acb-9fe3-872b08e9305c.png)

After confirming, you must login again with your newly created username and paassword. You can now begin browsing and posting on UDeal as it is meant to be. A collection of fair priced second-hand items for sale amongst fellow students. 

You have the option to create posts for items you are selling and looking for.

![image](https://user-images.githubusercontent.com/47361247/163658344-3904520d-f8aa-4c65-ad9c-d1c28babba53.png)

If you see a post you like, add it to your favourites!

![image](https://user-images.githubusercontent.com/47361247/163658371-4b7dc4c6-ede1-48d0-9e78-be0c4d95447b.png)

You can also manage you profile and specify you contact information so other users can inquire about your ads. Also, if your school has different campuses stored in UDeal's database, you can specify which one you prefer.

![image](https://user-images.githubusercontent.com/47361247/163658412-09c127cd-367e-472b-8dcc-8d9242110a3c.png)
