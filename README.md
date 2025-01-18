# DeveloperCodingTest
Hi! this is my solution for the coding test. In this project, I used the ASP.NET Core Web API template to fetch and retrieve data (best n stories) from the Hacker News API.

Expected response

![image](https://github.com/user-attachments/assets/b4f010d5-9900-45f5-9221-bb1767d4ccab)

For more stories they've been ordering because of the score value

![image](https://github.com/user-attachments/assets/5700d5d6-dcc8-47fa-a505-46eee6319c78)

## Documentation
To run and test the application, I configured it to use HTTP (to avoid issues with invalid or self-signed certificates). For testing purposes, I relied on Swagger UI, which provides a user-friendly interface to explore and test the API endpoints.

Running the app:

![gif1](https://github.com/user-attachments/assets/44a6dbd2-4077-48e3-ae1d-51da5dbf9785)

Testing the app:

![gif2](https://github.com/user-attachments/assets/f58b6825-87b7-4b43-9f3a-c47504c34dcf)

## Issues
The following are a list of issues that I couldn't solve in time:
1. Some labels are incorrect (eg. "by" instead of "postedBy")
2. I had to use an extra property to show the date in the expected format ("time" and "unixTimeToDateTime")
3. I didn't add the "commentCount" property because I didn't know what it refers to :'(

## Enhancements
1. Even if it works for the 200 best stories in a considerable time, it seems would take much longer for large numbers of stories, so even if I'm not sure how to do that right now, I would make a better manage of the data to improve time and resources.
2. Similar to the last point, I didn't add a validator of using a larger input than the number of stories 
