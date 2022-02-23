# Software Development Life Cycle (SDLC)
* It is the process of dividing software development work into distinct phases
* Most different types of SDLC are rigid, meaning you can't skip or move around the stages easily
# 6 stages of SDLC
* Planning/Requirement Analysis
    * Where you plan your project
    * You check if certain functionalities are feasible
    * All potential options you can pursue when doing the project
        * And finding the best option that fits with budget/current resources
* Define the Project Requirements
    * You define and docuement that product requirements of the project and get them approved by the customer/client
* Design Product Architecture
    * Based on the requirements, you design more than one design approach for the product architecture
        * Product architecture is just all the tech stack you will be using to deliver the product
* Building/Developing the product
    * Where you start coding the app!
* Testing the product
    * As the name suggests, this is where you will test your applicaiton to either find bugs or see if it hits all the project requirements.
    * The application must be in the quality standards that you promised with your customer/client
* Deployment and Maintenance
    * This is when you finally deploy your app to the appropriate market
    * After deployment, you maintain the application to make sure there are no interruptions from the daily use of your end-users

# Agile
* It is more of a concept that an actual methodology
* It is all about creating a working software than spending your time creating extensive documentation that may or may not be what your client wants (Looks good on paper but vastly different in the real world app)
* You consistently communicate with the client and stakeholders about what they want in the project (little to no documentation)
## Priorities changes
* An early and continuous delivery and deployment (CI/CD)
* Quick to accept to any changes in the requirements
* Quick delivery of a working project
* Regular sessions of meetings (stand ups)
* Constant adjustment to a dynamic development environment (You have to be flexible)

# Scrum
* Implementation of Agile concept
* It is a framework that helps teams work together
* It encourages collaboration and helping each other to solve problems one person might have during a **sprint**
* It consists of a series of sprints where each team has specific user stories to tackle
    * A user story is a simple description of a feature in laymen's term
    * Ex: "I want my todo app to add emojis automatically depending on the task"
        * But for you, you start thinking the AI capabilities needed to identify a specific task in an english formatted sentence and adding ASCII related to a specific emoji and then tell the client to shove it and it is impossible with your broke budget
## What are Sprints?
* It is a short period that completes a set amount of work
    * We already did a sprint with P0 accomplishment
* Usually lasts around 2-4 weeks of work
* After a sprint, teams will demonstrate what they've accomplished to each other and to the client
    * Any feedback will be used for the next Sprint
* During a sprint
    * Daily, weekly, or bi-weekly standups
    * You specify what you did
    * You specify what you'll do before the next standup
    * What blockers (problems) you have

# What is a Cloud?
* Allows the delivery of computing services over the internet ("The cloud") to offer fast innovation, flexible resources, and scalability.
* End-user doesn't have to worry about maintainence or upkeep of these servers
* Just have to worry about the costs will incur especially when your server needs heavy resources to run
## Pros
* Costs
    * Don't have to worry about infastructure costs or maintenance costs
    * You don't have to worry about utilities costs
    * The manpower required to build and maintain one
* Scaling
    * Very simple to upscale your server as your application grows
    * Can be done automatically (Kurbernetes)
    * Can also be done manually
* Security
    * Provided by the cloud provider
    * Most of them are high level companies that know how to deal with cyber attacks
## Cons
* Costs up to a certain point
    * If your company is getting too large with a lot of users then upscaling your cloud service will be more expensive than making your own infastructure

# Cloud Service Types
* IaaS
    * Infastructure as a Service
    * Instant computing infastructure, provisioned and managed over the internet
    * Configure the actual server themselves 
    * You have the most control over your cloud service
* PaaS
    * Platform as a Service removes the need for the organization to manage the underlying infastructure
    * Allows you to focus on deployment and management of your application
    * Ex: Azure Services
* SaaS
    * Software as a Service
    * You provide the software and the cloud provide will run and manage it with the services
    
# Cloud Deployment Models
* Kind of like the access modifiers in C# but instead of classes it is the organization and the general public
* Private
    * Only accessible by a certain organization or just your organization
* Public
    * Open for use by the general public
    * Ex: Gmail, yahoo mail, google website search engine, etc.
* Hybrid
    * Some resources are private and some resources are public
* Community
    * Sharing resources when you are part of a community
    * Ex: Universities, only their students have access to their cloud services

# DevOps
* It is a culture that you follow in which you continuously develop your application and continuously deploy it
* DevOps are integrated with Agile planning since they have similar ideologies
* There are three main teams that are a part of DevOps
    * Developer Team are responsible for planning, testing (with unit tests), and building the application
    * Operation Team are responsible for deploying, testing (by emulating real world experience), and maintaining the application
    * Business Team verifies that the correct product is created and delivered correctly
        * May or may not also set unrealistic expectations

## Continuous Integration (CI)
* The process of automating the build and testing of your code
* Usually triggered via a pull request/merge on your main branch of your remote repository
* Testing is done through unit tests and will only merge if all unit tests passes
## Continuous Delivery (CD)
* The extension of CI since CI does is checks if your main branch is working properly after a merge
    * Hence we usually denote them as CI/CD since both are usually combined together
* Essentially, it is the automated process of delivering the new changes in the main branch to the people
* However, there is a **release manager that will check on everything before deployment**

## Continous Delivery
* In its essence, it is the combination of both Continuous Integration and Continuous Delivery
* The main difference is there is essentially no human component involved in the entire process. Once you do a merge with the main, it will start deploying it after all the testing are done and passed
    * So no release manager and everything is managed/tested by computers

## YML
* Another mark up language that just tells the computer what to do so it can build, test, and deploy our application to setup a CI/CD pipeline
### Pipeline keywords
* Trigger
    * We set some sort of event that needs to happen to trigger/execute the entire process of CI/CD
* Job
    * This is the actual "work" the computer needs to do to start the entire process
    * You can have multiple jobs that is responsible to do something
    * Ex: Deploy the application job, Dockerize the app job, Code analysis job
* Steps
    * They are the tiny operations required for the computer to finish one job
    * This might be executing a bunch of CLI commands in sequence or installing certain SDKs to do the operation, etc.
* Approval
    * Some sort of a check after a job or multiple jobs to see that everything work as expected

# Introduction to Code Analysis
* A further way for a computer to analyze your code to ensure you are following good coding practices and also gives you a direction on certain things you might want to change
* Does not actually check if the functions are working on your app (that is what unit tests are for) and more about looking at your c# files and ensuring you follow good coding practicies
* It will perform a **static code anaylsis**
    * Just the fancy way of saying, it will check your code without running it and just scanning your c# files and seeing any patterns that might be bad coding practices
    * If done by a human, that is what we call a code review (just for your fun information)

# Specific for Azure DevOps Cloud Services
* A couple features in Azure DevOps that might be useful for us when utilizing that service to create our pipeline
* However, note that we used github actions to do our pipeline and not Azure DevOps
* Packages
    * They are just pre-made files made by someone that another person can come and download and start using it as well
    * Can also be done with pipelines in which we just pre-made pipelines and just change some configuration to tailor it to us
* Artifacts
    * Essentially, it is a market place for many packages
    * Ex: NuGet