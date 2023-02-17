# PollService
## Setup
1. Run the `PollService.Database`.
2. Fill in the `MailSetting.settings.json` file to use the Share Endpoint.
   
   2.1 You can use https://ethereal.email/create to create an SMTP server to send the emails. It's pretty intuitive to use 😁

3. To test the endpoints, I've attached a Postman collection that you can use.
4. Open the `Microservice.Poll.sln` on Visual Studio, build and run.
5. Now, you should be able to use the microservice.

If you want to change the connection strings for these projects, you can do it on the following files:
- `PollService.Database/App_Config/Database.settings.json`
- `MicroService.Poll.WebApi/App_Config/Database.settings.json`

Feel free to contact me via [LinkedIn](https://www.linkedin.com/in/bruno-santos-1b5699182/) 😉
